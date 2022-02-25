using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Core
{
    public class LevelSystem : MonoBehaviour
    {
        [SerializeField] private List<LevelData> levels;

        private LevelData activeLevel;

        private int activeLevelNumber;

        private bool noMoreLevels;
        public bool NoMoreLevels => noMoreLevels;

        public void Initialize()
        {
            activeLevelNumber = 0;
            activeLevel = levels[activeLevelNumber];
            noMoreLevels = false;
        }

        public void NextLevel()
        {
            activeLevelNumber++;
            if (activeLevelNumber >= levels.Count)
            {
                noMoreLevels = true;
                return;
            }
            activeLevel = levels[activeLevelNumber];
        }

        public LevelData CurrentlyActiveLevel()
        {
            return activeLevel;
        }
    } 
}