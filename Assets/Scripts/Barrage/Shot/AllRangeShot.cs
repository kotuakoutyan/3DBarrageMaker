using UnityEngine;
using System.Linq;
using Barrage.Bullet;
using Barrage.ObjectPool;

namespace Barrage.Shot
{
    public enum AllRangeShotShape
    {
        Random, Plane, Tetrahedron = 4, Hexahedron = 8, Octahedron = 6, Dodecahedron = 12, Icosahedron = 20,
        HighDensity10 = 36, HighDensity20 = 143, HighDensity30 = 327, HighDensity40 = 510, HighDensity50 = 912
    }

    public class AllRangeShot : NormalShot
    {

        /// <summary>
        /// 全方位に対して弾を複数打つメソッド
        /// </summary>
        /// <param name="bulletNum">発射する弾数</param>
        /// <param name="attackerType">発射するキャラの所属</param>
        /// <param name="position">発射位置</param>
        /// <param name="shape">弾幕の形</param>
        /// <param name="bulletType">弾の種類</param>
        /// <param name="data">弾の基本データ</param>
        /// <param name="time">連射時の発射角度に影響する時間情報</param>
        /// <param name="angularSpeed">連射時に変化する角速度</param>
        /// <param name="axis">連射時に変化する基準軸</param>
        /// <param name="forward">発射方向(AllRangeShotType.Planeのみ有効)</param>
        public void Shot(int bulletNum, AttackerType attackerType, Vector3 position, AllRangeShotShape shape, BulletType bulletType, BulletData data, GameObject target, float randomNum,  float time = 0.0f, float angularSpeed = 0.0f,  Vector3 axis = default, Vector3 forward = default)
        {
            var bullets = ObjectPools.Instance.GetBullet(bulletNum, bulletType);
            var directions = ShotManager.Instance.GetShotShape(shape, bulletNum, randomNum);
            if (time != 0.0f && RotateByTime(shape)) directions = directions.Select(v => Quaternion.AngleAxis(time * angularSpeed, axis) * v).ToArray();
            if (forward != default &&  RotateForDirection(shape)) for (int i = 0; i < bulletNum; i++) Shot(bullets[i], attackerType, position, directions[i].TransformDirection(forward), data, target);
            else for (int i = 0; i < bulletNum; i++) Shot(bullets[i], attackerType, position, directions[i], data, target);
            
        }
    }
}
