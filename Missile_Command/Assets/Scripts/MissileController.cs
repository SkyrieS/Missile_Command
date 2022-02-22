using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MissileController : MonoBehaviour
{
    [SerializeField] private float missileSpeed;
    private Vector2 target;

    public void SetTarget(Vector2 target)
    {
        this.target = target;
    }
    void Start()
    {
        target = transform.position;
    }
    public virtual void InstantiateMissile() 
    {
        target = transform.position;
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, missileSpeed * Time.deltaTime);

        if (TargetHit())
            DestroyMissile();
    }
    public virtual void UpdateMovement() 
    {
        transform.position = Vector2.MoveTowards(transform.position, target, missileSpeed * Time.deltaTime);

        if (TargetHit())
            DestroyMissile();

    }

    private bool TargetHit()
    {
        return (Vector2.Distance (transform.position, target) < 0.5f);
    }

    public virtual void DestroyMissile()
    {
        
    }

}
