using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MissileController : MonoBehaviour
{
    [SerializeField] private float missileSpeed = 3f;
    protected Vector2 target;
    private Vector2 StartPosition;
    

    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private float explosionDestroyTime = 1f;
    public void SetTarget(Vector2 target)
    {
        this.target = target;
    }

    public void SetRotation()
    {
        float rotationZ = Mathf.Atan2((target.y - transform.position.y), (target.x - transform.position.x)) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ - 90);
    }
    void Start()
    {
        target = transform.position;
        StartPosition = transform.position;
    }
    public virtual void InstantiateMissile() 
    {
        StartPosition = transform.position;
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
    }
    private void ResetRotation()
    {
        transform.rotation = Quaternion.identity;
    }

    private void Update()
    {
        if (target == StartPosition)
            return;

        transform.position = Vector2.MoveTowards(transform.position, target, missileSpeed * Time.deltaTime);

        if (TargetHit() == true)
        {
            DestroyMissile();
        }  
    }

    public virtual void UpdateMovement() 
    {
        transform.position = Vector2.MoveTowards(transform.position, target, missileSpeed * Time.deltaTime);

        if (TargetHit())
            DestroyMissile();
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
    }

}
