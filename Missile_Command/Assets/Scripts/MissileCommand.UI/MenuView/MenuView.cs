using UnityEngine;
using UnityEngine.Events;

namespace MissileCommand.UI
{
    public class MenuView : BaseView
    {
        [SerializeField]
        private CustomButton startGameButton;

        [SerializeField]
        private CustomButton exitButton;

        public void InitializeView()
        {
            OnExitButtonClicked_AddListener(Application.Quit);
        }

        public void OnStartButtonClicked_AddListener(UnityAction listener)
        {
            startGameButton.onClick.AddListener(listener);
        }

        public void OnStartButtonClicked_RemoveListener()
        {
            startGameButton.onClick.RemoveAllListeners();
        }

        public void OnExitButtonClicked_AddListener(UnityAction listener)
        {
            exitButton.onClick.AddListener(listener);
        }

        public void OnExitButtonClicked_RemoveListener()
        {
            exitButton.onClick.RemoveAllListeners();
        }
    }
}
