using UnityEngine;

namespace Barrage.Bullet
{
    public class CurveBullet : BaseBullet
    {
        protected Transform Origin;

        /// <summary>
        /// CurveBulletは基準点を生成時に作成する
        /// </summary>
        protected void Awake()
        {
            Origin = new GameObject("RotateOrigin " + name).transform;
            transform.SetParent(Origin);
        }

        public override void Initialize(AttackerType attackerType, Vector3 position, Vector3 velocity, BulletData data, GameObject target, Vector3 offset)
        {
            Origin.gameObject.SetActive(true);
            Origin.position = position;
            Origin.rotation = Quaternion.identity;

            base.Initialize(attackerType, position, velocity, data, target, offset);
        }

        protected override void AdditionalUpdate()
        {
            Origin.rotation *= Quaternion.AngleAxis(Data.AngularSpeed  * Time.fixedDeltaTime, Data.Axis);
            //transform.rotation *= Quaternion.AngleAxis(Data.AngularSpeed * Time.fixedDeltaTime, -Data.Axis);
        }

        protected override void ResetObject()
        {
            base.ResetObject();
            Origin.gameObject.SetActive(false);
        }
    }
}
