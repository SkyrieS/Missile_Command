using TMPro;
using UnityEngine;

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

        public override void HideView()
        {
            base.HideView();
            scorePoints.text = "Score: " + 0;
        }
    } 
}
