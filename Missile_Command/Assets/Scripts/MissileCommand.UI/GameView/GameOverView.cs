using UnityEngine;
using UnityEngine.Events;

namespace MissileCommand.UI
{
    public class GameOverView : BaseView
    {
        [SerializeField]
        private CustomButton exitToMainMenu;

        public void OnExitToMainMenuButtonClicked_AddListener(UnityAction listener)
        {
            exitToMainMenu.onClick.AddListener(listener);
        }

        public void OnExitToMainMenuButtonClicked_RemoveListener(UnityAction listener)
        {
            exitToMainMenu.onClick.RemoveListener(listener.Invoke);
        }
    } 
}
