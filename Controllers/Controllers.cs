using UnityEngine;
using System;

namespace PlatformerMVC
{
    public class Controllers
    {
        private SpriteAnimatorConfig _policemanConfig;
        private SpriteAnimatorConfig _coinConfig;
        private LevelObjectView _enemyView;
        private LevelObjectView [] _coinViews;
        private SpriteAnimatorController _enemyAnimator;
        private SpriteAnimatorController _coinAnimation;
        private PlayerController _playerMoveController;
        private GunMoveController _gunController;
        private CameraController _cameraController;
        private CoinController _coinController;
        private ExplosionController _explosionController;
        private LiftController _liftController;
        private UIController _playerUIController;
        private AIEnemiesController _aiEnemiesController;
        private EnemyViewController _enemyViewController;
        

        public  Controllers()
        {
            _playerMoveController = new PlayerController();
            _playerUIController = new UIController(_playerMoveController);
            _gunController = new GunMoveController(_playerMoveController.GetPlayerTransform());
            _cameraController = new CameraController(_playerMoveController.GetPlayerTransform(), Camera.main.transform);
            _coinController = new CoinController();
            LoadCoinAnimation();
            _explosionController = new ExplosionController(_gunController.GetBulletView());
            _liftController = new LiftController();
            _aiEnemiesController = new AIEnemiesController();
            _enemyViewController = new EnemyViewController();
        }       
        public void Update()
        {
            _gunController.Update();
            _cameraController.Update();
            _coinAnimation.Update();
            _explosionController.Update();
            _liftController.Update();
        }

        public void FixedUpdate()
        {
            _playerMoveController.FixedUpdate();
            _aiEnemiesController.FixedUpdate();
            _enemyViewController.FixedUpdate();
        }

        //private void LoadEnemiesController()
        //{
        //    _policemanConfig = Resources.Load<SpriteAnimatorConfig>("PolicemanAnimationCfg");
        //    _enemyView = GameObject.FindGameObjectWithTag("Enemy").AddComponent<LevelObjectView>();
        //    _enemyAnimator = new SpriteAnimatorController(_policemanConfig);
        //    _enemyAnimator.StartAnimation(_enemyView._spriteRenderer, AnimState.Run);
        //}
        private void LoadCoinAnimation()
        {
            _coinConfig = Resources.Load<SpriteAnimatorConfig>("CoinAnimator");
            _coinAnimation = new SpriteAnimatorController(_coinConfig);
            _coinViews = GameObject.FindObjectsOfType<CoinKeeper>();
            for (int i = 0; i < _coinViews.Length; i++)
            {
                _coinAnimation.StartAnimation(_coinViews[i]._spriteRenderer, AnimState.Idle, true, 10);
            }
        }
        
    }
}
