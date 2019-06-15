using Barrage.Iterators;
using UnityEngine;

namespace Barrage.Bullet
{
    public class FunnelBullet : BaseBullet
    {
        public Iterator Iterator;
        protected Transform Origin;
        
        protected Vector3 Acceleration;

        /// <summary>
        /// CurveBulletは基準点を生成時に作成する
        /// </summary>
        protected void Awake()
        {
            Iterator = gameObject.AddComponent<Iterator>();
            Origin = new GameObject("RotateOrigin " + name).transform;
            transform.SetParent(Origin);
        }
        
        public override void Initialize(AttackerType attackerType, Vector3 position, Vector3 velocity, BulletData data, GameObject target, Vector3 offset)
        {
            Iterator.SetUnityAction(attackerType, data.SplitData, gameObject, target);

            Origin.gameObject.SetActive(true);
            Origin.position = position;
            Origin.rotation = Quaternion.identity;
            
            Acceleration = 2 * (data.DeploymentDistance - data.Speed *  data.DeploymentTime) / data.DeploymentTime / data.DeploymentTime * velocity;

            base.Initialize(attackerType, position, velocity, data, target, offset);
        }

        protected override void AdditionalUpdate()
        {
            if (Time.time - InitializeTime < Data.DeploymentTime)
            {
                Velocity += Acceleration * Time.fixedDeltaTime;
            }
            else Velocity = Vector3.zero;
            Origin.rotation *= Quaternion.AngleAxis(Data.AngularSpeed * Time.fixedDeltaTime, Data.Axis);
        }

        protected override void ResetObject()
        {
            base.ResetObject();
            Iterator.RemoveAll();
            Origin.gameObject.SetActive(false);
        }
    }
}
