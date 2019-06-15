using System.Linq;

namespace UnityEngine
{
    public static class RandomExtention
    {
        public static Vector3 RandamShake(this Vector3 self, float shake_max)
        {
            if (shake_max == 0.0f) return self;
            float n1 = Random.value, n2 = Random.value;
            var newDirection = Quaternion.Euler(0, 0, 360f * n2) * Quaternion.Euler(shake_max * n1, 0, 0) * Vector3.forward;
            var direction = Quaternion.FromToRotation(Vector3.forward, self);
            return direction * newDirection;
        }

        public static Vector3 GetOrthogonalUnitVector(this Vector3 self)
        {
            float randomNum = Random.value;
            var newDirection = Quaternion.Euler(0, 0, 360f * randomNum) * Vector3.right;
            return Quaternion.LookRotation(self) * newDirection;
        }

        public static Vector3[] GetOrthogonalUnitVectors(this Vector3[] self)
        {
            float randomNum = Random.value;
            var newDirection = Quaternion.Euler(0, 0, 360f * randomNum) * Vector3.right;
            return self.Select(v => Quaternion.LookRotation(v) * newDirection).ToArray();
        }

        public static Vector3 TransformDirection(this Vector3 self, Vector3 forward)
        {
            return Quaternion.FromToRotation(Vector3.forward, self) * forward;
        }
    }
}
