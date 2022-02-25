using MissileCommand.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MissileCommand.Core
{
    public class GameState : BaseState
    {
        private GameView gameView;

        private GameOverView gameOverView;

        private ScoreSystem scoreSystem;

        private ShootingSystem shootingSystem;

        private InputSystem inputSystem;

        private EnemyMissileSpawnerSystem enemyMissileSpawnerSystem;

        private CitySystem citySystem;

        private LevelSystem levelSystem;

        private UnityAction backToMenu;

        public GameState(GameView gameView,
            GameOverView gameOverView,
            ScoreSystem scoreSystem, 
            ShootingSystem shootingSystem, 
            InputSystem inputSystem, 
            EnemyMissileSpawnerSystem enemyMissileSpawnerSystem, 
            CitySystem citySystem,
            LevelSystem levelSystem,
            UnityAction backToMenu)
        {
            this.gameView = gameView;
            this.gameOverView = gameOverView;
            this.scoreSystem = scoreSystem;
            this.shootingSystem = shootingSystem;
            this.inputSystem = inputSystem;
            this.enemyMissileSpawnerSystem = enemyMissileSpawnerSystem;
            this.citySystem = citySystem;
            this.levelSystem = levelSystem;
            this.backToMenu = backToMenu;
        }

        public override void InstantiateState()
        {
            base.InstantiateState();
            levelSystem.Initialize();
            gameView.ShowView();
            scoreSystem.Initialize();
            shootingSystem.Initialize(UpdateRandomTargets);
            shootingSystem.ResetLaunchers();
            enemyMissileSpawnerSystem.Initialize(levelSystem.CurrentlyActiveLevel());
            enemyMissileSpawnerSystem.InitializeScoreSystem(UpdateScore);
            enemyMissileSpawnerSystem.ResetEnemyMissiles();
            citySystem.Initialize(UpdateRandomTargets);

            gameOverView.OnExitToMainMenuButtonClicked_AddListener(backToMenu);
        }

        public override void UpdateState()
        {
           
            base.UpdateState();
            if (citySystem.NumberOfAliveCites == 0 || shootingSystem.NumberOfAlivelaunchers == 0)
            {
                gameOverView.ShowView();
                return;
            }
            if (levelSystem.NoMoreLevels)
            {
                gameOverView.ShowView();
                return;
            }
            shootingSystem.UpdateLaunchers();
            inputSystem.UpdateInputs();
            enemyMissileSpawnerSystem.UpdateMissiles();
            if (enemyMissileSpawnerSystem.NumberOfAliveEnemyMissiles == 0)
            {
                levelSystem.NextLevel();
                enemyMissileSpawnerSystem.ChangeLevel(levelSystem.CurrentlyActiveLevel());
                UpdateScore(citySystem.NumberOfAliveCites*levelSystem.CurrentlyActiveLevel().PointsForAliveCity);
                UpdateScore(shootingSystem.NumberOfAlivelaunchers*levelSystem.CurrentlyActiveLevel().PointsForAvalibeMissile);
                shootingSystem.ResetLaunchers();
                enemyMissileSpawnerSystem.ResetEnemyMissiles();
                citySystem.ResetCities();
                citySystem.Initialize(UpdateRandomTargets);
            }
            
        }
        public override void DestroyState()
        {
            gameOverView.HideView();
            gameOverView.OnExitToMainMenuButtonClicked_RemoveListener(backToMenu);
            base.DestroyState();
            gameView.HideView();
            citySystem.Destroy();
            enemyMissileSpawnerSystem.DestroyScoreSystem();
        }

        public void UpdateRandomTargets()
        {
            enemyMissileSpawnerSystem.ResetTargets();
        }

        public void UpdateScore(int score)
        {
            scoreSystem.UpdateScore(score);
            gameView.UpdateScoreText(scoreSystem.GetCurrentScore());
        }
    }

}