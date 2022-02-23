using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField] 
    private List<PlayerMissileController> avalibleMissiles;

    private List<PlayerMissileController> activeMissiles = new List<PlayerMissileController>();

    [SerializeField]
    private Transform spawnTarget;

    public void Initialize()
    {
        foreach (var missile in avalibleMissiles)
        {
            missile.InitializeMissile();
        }
    }

    public void UpdateMissiles()
    {
        foreach (var missile in activeMissiles)
        {
            missile.UpdateMovement();
        }
    }

    public void FireMissile(Vector2 target)
    {
        if (avalibleMissiles.Count == 0)
            return;

        activeMissiles.Add(avalibleMissiles[0]);
        avalibleMissiles.RemoveAt(0);
        activeMissiles[activeMissiles.Count - 1].transform.position = spawnTarget.position;
        SetTarget(activeMissiles[activeMissiles.Count - 1], target);
    }

    private void SetTarget(PlayerMissileController missile, Vector2 target)
    {
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
