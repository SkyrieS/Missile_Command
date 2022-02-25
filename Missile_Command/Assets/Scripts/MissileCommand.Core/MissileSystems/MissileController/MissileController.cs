using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Core
{
    public abstract class MissileController : MonoBehaviour
    {
        [SerializeField] protected float missileSpeed;
        protected Vector2 target;
        protected Vector2 StartPosition;

        [SerializeField]
        protected GameObject explosionPrefab;
        [SerializeField]
        protected float explosionDestroyTime = 1f;

        protected bool IsDestroyed;
        public void SetTarget(Vector2 target)
        {
            this.target = target;
        }

        public void SetRotation()
        {
            float rotationZ = Mathf.Atan2((target.y - transform.position.y), (target.x - transform.position.x)) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ - 90);
        }
        public void InitializeMissile()
        {
            StartPosition = transform.position;
            target = transform.position;
            IsDestroyed = false;
        }

        public virtual void InitializeMissile(LevelData level)
        {
            StartPosition = transform.position;
            target = transform.position;
            IsDestroyed = false;
            missileSpeed = level.EnemyRocketSpeed;
        }

        public void ResetMissile()
        {
            ResetPosition();
            ResetRotation();
        }

        protected void ResetPosition()
        {
            transform.position = StartPosition;
            target = StartPosition;
            IsDestroyed = false;
        }
        protected void ResetRotation()
        {
            transform.rotation = Quaternion.identity;
        }

        public virtual void UpdateMovement()
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

        protected bool TargetHit()
        {
            return (Vector2.Distance(transform.position, target) < .1f);
        }

        public void DestroyMissile()
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
}