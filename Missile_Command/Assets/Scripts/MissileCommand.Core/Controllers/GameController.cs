using MissileCommand.UI;
using UnityEngine;


namespace MissileCommand.Core
{
    public class GameController : BaseController
    {
        private GameState gameState;
        private MenuState menuState;

        [SerializeField]
        private MenuView menuView;

        [SerializeField]
        private GameView gameView;
        [SerializeField]
        GameOverView gameOverView;
        [SerializeField]
        private ScoreSystem scoreSystem;
        [SerializeField]
        private ShootingSystem shootingSystem;
        [SerializeField]
        private InputSystem inputSystem;
        [SerializeField]
        private EnemyMissileSpawnerSystem enemyMissileSpawnerSystem;
        [SerializeField]
        private CitySystem citySystem;
        [SerializeField]
        private LevelSystem levelSystem;

        protected override void InjectReferences()
        {
            menuState = new MenuState(menuView);
            gameState = new GameState(gameView, gameOverView, scoreSystem, shootingSystem, inputSystem, enemyMissileSpawnerSystem, citySystem, levelSystem, ChangeToMenuState);
        }

        protected override void Start()
        {
            base.Start();
            ChangeState(menuState);
            menuView.OnStartButtonClicked_AddListener(() => ChangeState(gameState));
        }

        protected override void Update()
        {
            base.Update();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        public void ChangeToMenuState()
        {
            ChangeState(menuState);
        }
    }
}