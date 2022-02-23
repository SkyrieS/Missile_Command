using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissileSpawner : MonoBehaviour
{
    [SerializeField] private List<EnemyMissileController> avalibleEnemyMissiles;
    private List<EnemyMissileController> activeEnemyMissiles = new List<EnemyMissileController>();

    private GameObject[] targets;

    private Vector2 spawnBoxSize;
    private Vector2 spawnBoxCenter;

    private void Start()
    {
        InstantiateSpawner();
    }
    public void InstantiateSpawner()
    {
        FindTargets();
        spawnBoxCenter = transform.position;

        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();

        spawnBoxSize.x = transform.localScale.x * boxCollider.size.x;
        spawnBoxSize.y = transform.localScale.y * boxCollider.size.y;
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 randomPosition = new Vector2(Random.Range(-spawnBoxSize.x / 2, spawnBoxSize.x / 2), Random.Range(-spawnBoxSize.y / 2, spawnBoxSize.y / 2));
        return spawnBoxCenter + randomPosition;
    }

    [ContextMenu("SpawnEnemyMissile")]
    public void FireEnemyMissile()
    {
        if (avalibleEnemyMissiles.Count == 0)
        {
            Debug.Log("Enemy is out of missiles!");
            return;
        }

        activeEnemyMissiles.Add(avalibleEnemyMissiles[0]);
        avalibleEnemyMissiles.RemoveAt(0);
        activeEnemyMissiles[activeEnemyMissiles.Count - 1].transform.position = GetRandomPosition();
        ChooseRandomTarget(activeEnemyMissiles[activeEnemyMissiles.Count - 1]);
    }

    private void FindTargets()
    {
        targets = GameObject.FindGameObjectsWithTag("Friendly");
    }

    private void ChooseRandomTarget(EnemyMissileController enemyMissile)
    {
        Transform target = targets[Random.Range(0, targets.Length)].transform;
        enemyMissile.SetTarget(target.position);
        enemyMissile.SetRotation();
    }
}
