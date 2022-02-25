using MissileCommand.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Core
{
    public class MenuState : BaseState
    {
        private MenuView menuView;

        public MenuState(MenuView menuView)
        {
            this.menuView = menuView;
        }

        public override void InstantiateState()
        {
            base.InstantiateState();
            menuView.ShowView();
            menuView.InitializeView();
        }

        public override void UpdateState()
        {
            base.UpdateState();
        }
        public override void DestroyState()
        {
            menuView.OnExitButtonClicked_RemoveListener();
            menuView.HideView();
            base.DestroyState();
        }
    }

}
