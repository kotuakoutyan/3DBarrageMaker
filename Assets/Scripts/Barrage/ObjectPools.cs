using UnityEngine;
using System.Collections.Generic;
using Barrage.Shot;
using Barrage.Bullet;

namespace Barrage.ObjectPool
{
    public class ObjectPools
    {
        private ObjectPools() { }
        private static ObjectPools instance;
        public static ObjectPools Instance
        {
            get
            {
                if (instance == null) instance = new ObjectPools();
                return instance;
            }
        }
            
        private ObjectPool<NormalBullet> NormalBulletPool = new ObjectPool<NormalBullet>();
        private ObjectPool<CurveBullet> CurveBulletPool = new ObjectPool<CurveBullet>();
        private ObjectPool<SplitBullet> SplitBulletPool = new ObjectPool<SplitBullet>();
        private ObjectPool<ChaseBullet> ChaseBulletPool = new ObjectPool<ChaseBullet>();
        private ObjectPool<FunnelBullet> FunnelBulletPool = new ObjectPool<FunnelBullet>();

        public List<BaseBullet> GetBullet(int num,  BulletType bulletType)
        {
            switch (bulletType)
            {
                case BulletType.Normal:
                    return NormalBulletPool.GetBullet(num);
                case BulletType.Curve:
                    return CurveBulletPool.GetBullet(num);
                case BulletType.Split:
                    return SplitBulletPool.GetBullet(num);
                case BulletType.Chase:
                    return ChaseBulletPool.GetBullet(num);
                case BulletType.Funnel:
                    return FunnelBulletPool.GetBullet(num);
                default:
                    return null;
            }
        }
    }

    /// <typeparam name="T">抽象クラスBulletを継承したクラス</typeparam>
    public class ObjectPool<T> where T : BaseBullet
    {
        private List<T> BulletList = new List<T>();
        [SerializeField] private GameObject Bullet;

        public ObjectPool()
        {
            Bullet = Resources.Load<GameObject>("Sphere");
        }

        public void CreatePool(GameObject bullet, int maxCount)
        {
            for (int i = 0; i < maxCount; i++)
            {
                var newObj = CreateNewObject();
                newObj.gameObject.SetActive(false);
                BulletList.Add(newObj);
            }
        }

        /// <summary>
        /// 使用中でないBulletを探してListで返す
        /// </summary>
        /// <param name="num">必要なBulletの数</param>
        public List<BaseBullet> GetBullet(int num = 1)
        {
            if (num < 1) return null;

            var list = new List<BaseBullet>();
            foreach (var obj in BulletList)
            {
                if (obj.gameObject.activeSelf == false)
                {
                    list.Add(obj);
                    if (list.Count == num) return list;
                }
            }

            // 全て使用中だったら新しく作って返す
            while (list.Count < num)
            {
                var newObj = CreateNewObject();
                newObj.gameObject.SetActive(true);
                BulletList.Add(newObj);
                list.Add(newObj);
            }
            return list;
        }

        /// <summary>
        /// Bulletを作り、それを返すメソッド
        /// </summary>
        private T CreateNewObject()
        {
            var newObj = Object.Instantiate(Bullet).AddComponent<T>();
            newObj.name = Bullet.name + (BulletList.Count + 1);

            return newObj;
        }
    }
}
