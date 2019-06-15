using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    private Counter() { }
    private static Counter instance;
    public static Counter Instance
    {
        get
        {
            if (instance == null) instance = new Counter();
            return instance;
        }
    }

    [SerializeField] private Text TimerText = null;
    [SerializeField] private Text AttackCountText = null;
    [SerializeField] private Text AttackedCountText = null;

    private float timerCount = 60.0f;
    private readonly ReactiveProperty<int> attackCount = new ReactiveProperty<int>(0);
    private readonly ReactiveProperty<int> attackedCount = new ReactiveProperty<int>(0);

    public IReadOnlyReactiveProperty<int> AttackCount => attackCount;
    public IReadOnlyReactiveProperty<int> AttackedCount => attackedCount;

    public void Attack() => attackCount.SetValueAndForceNotify(attackCount.Value + 1);
    public void Attacked() => attackedCount.SetValueAndForceNotify(attackedCount.Value + 1);

    void Start()
    {
        instance = this;

        this.UpdateAsObservable().Subscribe(_ => 
        {
            timerCount -= Time.deltaTime;
            TimerText.text = "Time：" + ((int)timerCount / 60).ToString() + ":" + (timerCount % 60).ToString();
            //if (timerCount < 0) SceneManager.LoadScene("神霊廟");
        });

        attackCount.DistinctUntilChanged().Subscribe(x => AttackCountText.text = "Attack" + x.ToString());
        attackedCount.DistinctUntilChanged().Subscribe(x => AttackedCountText.text = "Attacked" + x.ToString());
    }
}
