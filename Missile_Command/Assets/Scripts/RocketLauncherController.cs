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
        if (avalibleMissiles.Count == 0)
            return;

        activeMissiles.Add(avalibleMissiles[0]);
        avalibleMissiles.RemoveAt(0);
        activeMissiles[activeMissiles.Count - 1].transform.position = spawnTarget.position;
        activeMissiles[activeMissiles.Count - 1].SetTarget(target);
        activeMissiles[activeMissiles.Count - 1].SetRotation();
    }

    [ContextMenu("ResetMissiles")]
    public void ResetMissiles()
    {
        List<PlayerMissileController> remainingAvalibleMissiles = new List<PlayerMissileController>();
        remainingAvalibleMissiles.AddRange(avalibleMissiles);
        avalibleMissiles.Clear();

        avalibleMissiles.AddRange(activeMissiles);
        avalibleMissiles.AddRange(remainingAvalibleMissiles);
        activeMissiles.Clear();

        foreach (var missiles in avalibleMissiles)
        {
            missiles.gameObject.SetActive(true);
            missiles.ResetMissile();
        }
    }

    public bool IsEmpty()
    {
        return (avalibleMissiles.Count == 0);
    }
}
