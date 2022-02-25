using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

namespace MissileCommand.Core
{
    public class EnemyMissileSpawnerSystem : MonoBehaviour
    {
        [SerializeField]
        private List<EnemyMissileController> avalibleEnemyMissiles;

        private List<EnemyMissileController> activeEnemyMissiles = new List<EnemyMissileController>();

        private int numberOfEnemyMissiles;

        private int numberOfAliveEnemyMissiles;
        public int NumberOfAliveEnemyMissiles => numberOfAliveEnemyMissiles;

        private GameObject[] targets;

        private Vector2 spawnBoxSize;
        private Vector2 spawnBoxCenter;

        private LevelData activeLevel;

        private UnityAction<int> scoreUpdate;

        private float timeToSpawn;

        public void Initialize(LevelData level)
        {
            activeLevel = level;
            numberOfAliveEnemyMissiles = level.NumberOfMissiles;
            numberOfEnemyMissiles = level.NumberOfMissiles;
            InstantiateSpawner();
            foreach (var missile in avalibleEnemyMissiles)
            {
                missile.InitializeMissile(level);
            }
            timeToSpawn = Time.time + activeLevel.TimeToNextMissile;
        }

        public void InitializeScoreSystem(UnityAction<int> scoreUpdate)
        {
            this.scoreUpdate += scoreUpdate;
        }

        public void DestroyScoreSystem()
        {
            this.scoreUpdate = null;
        }

        public void ChangeLevel(LevelData level)
        {
            Initialize(level);
        }

        public void UpdateMissiles()
        {
            foreach (var missile in activeEnemyMissiles)
            {
                missile.UpdateMovement();
                if (missile.GetDestroyedByPlayer())
                {
                    scoreUpdate(activeLevel.PointsForDestroying);
                    numberOfAliveEnemyMissiles--;
                    missile.ResetDestroyedByPlayer();
                }

                if (missile.GetDestroyedByFriendly())
                {
                    numberOfAliveEnemyMissiles--;
                    missile.ResetDestroyedByFriendly();
                }
            }
            if (numberOfAliveEnemyMissiles == 0 || numberOfEnemyMissiles == 0)
                return;

            if (Time.time > timeToSpawn)
            {
                timeToSpawn = Time.time + activeLevel.TimeToNextMissile;
                FireEnemyMissile();
            }
        }

        public void ResetEnemyMissiles()
        {
            List<EnemyMissileController> remainingAvalibleMissiles = new List<EnemyMissileController>();
            remainingAvalibleMissiles.AddRange(avalibleEnemyMissiles);
            avalibleEnemyMissiles.Clear();

            avalibleEnemyMissiles.AddRange(activeEnemyMissiles);
            avalibleEnemyMissiles.AddRange(remainingAvalibleMissiles);
            activeEnemyMissiles.Clear();

            foreach (var missiles in avalibleEnemyMissiles)
            {
                missiles.gameObject.SetActive(true);
                missiles.ResetMissile();
            }
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
                Debug.Log("Out of missile objets on scene!");
                return;
            }

            activeEnemyMissiles.Add(avalibleEnemyMissiles[0]);
            avalibleEnemyMissiles.RemoveAt(0);
            activeEnemyMissiles[activeEnemyMissiles.Count - 1].transform.position = GetRandomPosition();
            ChooseRandomTarget(activeEnemyMissiles[activeEnemyMissiles.Count - 1]);
            numberOfEnemyMissiles--;
        }

        private void FindTargets()
        {
            targets = GameObject.FindGameObjectsWithTag("Friendly");
        }

        public void ResetTargets()
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
}