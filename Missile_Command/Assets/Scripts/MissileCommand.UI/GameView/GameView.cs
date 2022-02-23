using System.Collections;
using TMPro;
using UnityEngine;
using MissileCommand.Core;
using UnityEngine.UI;

namespace MissileCommand.UI
{
    public class GameView : BaseView
    {
        [SerializeField] 
        private TextMeshProUGUI scorePoints;

        public void UpdateScoreText(int score)
        {
            scorePoints.text = "Score: " + score;
        }
    } 
}
