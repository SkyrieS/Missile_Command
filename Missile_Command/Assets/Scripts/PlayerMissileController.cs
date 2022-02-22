using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissileController : MissileController
{
    public override void InstantiateMissile()
    {
        
    }
    public override void DestroyMissile()
    {
        base.DestroyMissile();
    }
    protected override bool TargetHit()
    {
        // We've reached our target if we reach the height that we initially targeted.
        return base.TargetHit() || (transform.position.y > target.y);
    }
}
