using MissileCommand.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand.Core
{
    public class GameState : BaseState
    {
        private GameView gameView;

        private ScoreSystem scoreSystem;

        private ShootingSystem shootingSystem;

        private InputSystem inputSystem;

        private EnemyMissileSpawnerSystem enemyMissileSpawnerSystem;

        private FriendlyBuildingSystem friendlyBuildingSystem;

        private int score;

        public GameState(GameView gameView, ScoreSystem scoreSystem, ShootingSystem shootingSystem, InputSystem inputSystem, EnemyMissileSpawnerSystem enemyMissileSpawnerSystem, FriendlyBuildingSystem friendlyBuildingSystem)
        {
            this.gameView = gameView;
            this.scoreSystem = scoreSystem;
            this.shootingSystem = shootingSystem;
            this.inputSystem = inputSystem;
            this.enemyMissileSpawnerSystem = enemyMissileSpawnerSystem;
            this.friendlyBuildingSystem = friendlyBuildingSystem;
        }

        public override void InstantiateState()
        {
            base.InstantiateState();
            gameView.ShowView();
            scoreSystem.Initialize();
            shootingSystem.Initialize();
            enemyMissileSpawnerSystem.Initialize();
            friendlyBuildingSystem.Initialize(UpdateRandomTargets);
        }

        public override void UpdateState()
        {
            base.UpdateState();
            shootingSystem.UpdateLaunchers();
            inputSystem.UpdateInputs();
            enemyMissileSpawnerSystem.UpdateMissiles();
        }
        public override void DestroyState()
        {
            base.DestroyState();
            shootingSystem.ResetLaunchers();
            gameView.HideView();
            friendlyBuildingSystem.Destroy();
            //Add score
        }

        public void UpdateRandomTargets()
        {
            enemyMissileSpawnerSystem.ResetTargets();
        }

        public void UpdateScore()
        {
            scoreSystem.UpdateScore(score);
            gameView.UpdateScoreText(scoreSystem.GetCurrentScore());
        }
    }

}