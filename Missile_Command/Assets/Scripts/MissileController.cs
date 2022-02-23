using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MissileController : MonoBehaviour
{
    [SerializeField] private float missileSpeed = 3f;
    protected Vector2 target;
    private Vector2 StartPosition;
    
    [SerializeField] 
    private GameObject explosionPrefab;
    [SerializeField] 
    private float explosionDestroyTime = 1f;

    private bool IsDestroyed;
    public void SetTarget(Vector2 target)
    {
        this.target = target;
    }

    public void SetRotation()
    {
        float rotationZ = Mathf.Atan2((target.y - transform.position.y), (target.x - transform.position.x)) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ - 90);
    }
    public virtual void InitializeMissile()
    {
        StartPosition = transform.position;
        target = transform.position;
        IsDestroyed = false;
    }

    public void ResetMissile()
    {
        ResetPosition();
        ResetRotation();
    }

    private void ResetPosition()
    {
        transform.position = StartPosition;
        target = StartPosition;
        IsDestroyed = false;
    }
    private void ResetRotation()
    {
        transform.rotation = Quaternion.identity;
    }

    public void UpdateMovement()
    {
        if (IsDestroyed)
            return;
        if (target == StartPosition)
            return;

        transform.position = Vector2.MoveTowards(transform.position, target, missileSpeed * Time.deltaTime);

        if (TargetHit() == true)
        {
            DestroyMissile();
        }  
    }

    protected virtual bool TargetHit()
    {
        return (Vector2.Distance (transform.position, target) < .1f);
    }

    public virtual void DestroyMissile()
    {
        GameObject cloneExplosionPrefab = Instantiate(explosionPrefab.gameObject, transform.position, Quaternion.identity);
        cloneExplosionPrefab.GetComponent<DestroyExplosion>().DestroyExplosionPrefab(explosionDestroyTime);
        this.gameObject.SetActive(false);
        IsDestroyed = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollisionTarget(collision);
    }

    protected virtual void CollisionTarget(Collider2D collision)
    {
    }

}
