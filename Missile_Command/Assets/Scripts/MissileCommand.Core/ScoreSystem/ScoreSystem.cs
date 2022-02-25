using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Core
{
    public class ScoreSystem : MonoBehaviour
    {

        private int currentScore;

        public void Initialize()
        {
            currentScore = 0;
        }

        public int GetCurrentScore()
        {
            return currentScore;
        }

        public void UpdateScore(int points)
        {
            currentScore += points;
        }

    } 
}