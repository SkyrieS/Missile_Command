using MissileCommand.UI;
using UnityEngine;


namespace MissileCommand.Core
{
    public class GameController : BaseController
    {
        private WinState winState;
        private LoseState loseState;
        private GameState gameState;

        [SerializeField]
        private GameView gameView;
        [SerializeField]
        private ScoreSystem scoreSystem;
        [SerializeField]
        private ShootingSystem shootingSystem;
        [SerializeField]
        private InputSystem inputSystem;
        [SerializeField]
        private EnemyMissileSpawnerSystem enemyMissileSpawnerSystem;
        [SerializeField]
        private FriendlyBuildingSystem friendlyBuildingSystem;

        protected override void InjectReferences()
        {
            winState = new WinState();
            loseState = new LoseState();
            gameState = new GameState(gameView, scoreSystem, shootingSystem, inputSystem, enemyMissileSpawnerSystem, friendlyBuildingSystem);
        }

        protected override void Start()
        {
            base.Start();
            ChangeState(gameState);

        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        public void GameOver()
        {
            
        }

    }
}