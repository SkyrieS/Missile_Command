using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "LevelCreator/Level")]
public class LevelData : ScriptableObject
{
    [SerializeField] private int numberOfMissiles;
    public int NumberOfMissiles => numberOfMissiles;

    [SerializeField] private float timeToNextMissile;
    public float TimeToNextMissile => timeToNextMissile;

    [SerializeField] private float enemyRocketSpeed;
    public float EnemyRocketSpeed => enemyRocketSpeed;

    [SerializeField] private int pointsForDestroying;
    public int PointsForDestroying => pointsForDestroying;

    [SerializeField] private int pointsForAliveCity;
    public int PointsForAliveCity => pointsForAliveCity;

    [SerializeField] private int pointsForAvalibeMissile;
    public int PointsForAvalibeMissile => pointsForAvalibeMissile;
}
