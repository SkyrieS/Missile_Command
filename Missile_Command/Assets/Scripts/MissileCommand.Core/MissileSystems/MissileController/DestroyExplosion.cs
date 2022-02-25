using UnityEngine;

namespace MissileCommand.Core
{
    public class DestroyExplosion : MonoBehaviour
    {
        public void DestroyExplosionPrefab(float destroyTime)
        {
            Destroy(this.gameObject, destroyTime);
        }
    } 
}
