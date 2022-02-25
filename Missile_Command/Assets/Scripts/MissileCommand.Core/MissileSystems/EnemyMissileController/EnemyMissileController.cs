using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Core
{
    public class EnemyMissileController : MissileController
    {
        private bool DestroyedByPlayer;
        private bool DestroyedByFriendly;

        public override void InitializeMissile(LevelData level)
        {
            base.InitializeMissile(level);
            DestroyedByPlayer = false;
        }

        public override void UpdateMovement()
        {
            if (IsDestroyed)
                return;
            if (target == StartPosition)
                return;

            transform.position = Vector2.MoveTowards(transform.position, target, missileSpeed * Time.deltaTime);

            if (TargetHit() == true)
            {
                DestroyedByFriendly = true;
                DestroyMissile();
            }
        }
        protected override void CollisionTarget(Collider2D collision)
        {
            if (collision.tag == "Friendly")
            {
                DestroyedByFriendly = true;
                DestroyMissile();
            }

            if (collision.tag == "Explosion")
            {
                DestroyedByPlayer = true;
                DestroyMissile();
            }
        }

        public bool GetDestroyedByPlayer()
        {
            return DestroyedByPlayer;
        }

        public void ResetDestroyedByPlayer()
        {
            DestroyedByPlayer = false;
        }

        public bool GetDestroyedByFriendly()
        {
            return DestroyedByFriendly;
        }

        public void ResetDestroyedByFriendly()
        {
            DestroyedByFriendly = false;
        }
    } 
}