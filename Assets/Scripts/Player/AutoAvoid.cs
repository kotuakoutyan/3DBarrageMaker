using UnityEngine;
using FlyCharacter;
using Barrage.Bullet;

public class AutoAvoid : MonoBehaviour
{
    private AttackerType AttackerType;

    private Vector3 Velocity;
    public Vector3 Result;

    //察知するColliderの半径
    [SerializeField] private float Radius = 2.0f;

    void Start()
    {
        AttackerType = transform.parent.GetComponent<FlyCharacterStatus>().AttackerType;
        GetComponent<SphereCollider>().radius = Radius;
    }

    void FixedUpdate()
    {
        if (Velocity == Vector3.zero) Result = Velocity;
        else Result = Velocity.normalized;
        Velocity = Vector3.zero;
    }

    void OnTriggerStay(Collider col)
    {
        if (col.GetComponent<IAttacker>() != null && col.GetComponent<IAttacker>().GetAttackerType() != AttackerType)
        {
            var vector = transform.position - col.ClosestPointOnBounds(col.transform.position);
            Velocity += vector * (1 + Radius - vector.magnitude);
        }
    }
}
