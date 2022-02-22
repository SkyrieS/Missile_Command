using UnityEngine;

public class DestroyExplosion : MonoBehaviour
{
    public void DestroyExplosionPrefab(float destroyTime)
    {
        Destroy(this.gameObject, destroyTime);
    }
}
