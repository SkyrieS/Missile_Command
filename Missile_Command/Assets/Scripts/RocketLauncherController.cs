using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncherController : MonoBehaviour
{
    [SerializeField] private List<PlayerMissileController> avalibleMissiles;
    private List<PlayerMissileController> activeMissiles = new List<PlayerMissileController>();
    [SerializeField] private Transform spawnTarget;

    public void FireMissile(Vector2 target)
    {
        activeMissiles.Add(avalibleMissiles[0]);
        avalibleMissiles.RemoveAt(0);
        activeMissiles[activeMissiles.Count - 1].transform.position = spawnTarget.position;
        activeMissiles[activeMissiles.Count - 1].InstantiateMissile();
        activeMissiles[activeMissiles.Count - 1].SetTarget(target);
    }
}
