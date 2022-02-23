using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissileController : MissileController
{
    protected override bool TargetHit()
    {
        return false;
    }

    protected override void CollisionTarget(Collider2D collision)
    {
        if (collision.tag == "Friendly")
        {
            //destroy city
            DestroyMissile();
        }

        if (collision.tag == "Explosion")
        {
            //Inform scoreboard
            DestroyMissile();
        }
    }
}
