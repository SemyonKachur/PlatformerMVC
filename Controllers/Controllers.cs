using UnityEngine;
using System;

namespace PlatformerMVC
{
    public class Controllers
    {
        private SpriteAnimatorConfig _policemanConfig;
        private LevelObjectView _enemyView;
        private SpriteAnimatorController _enemyAnimator;
        private PlayerController _playerMoveController;
        private GunMoveController _gunController;
        private CameraController _cameraController;
        private CoinController _coinController;

        public  Controllers()
        {
            _playerMoveController = new PlayerController();
            LoadEnemiesController();
            _gunController = new GunMoveController(_playerMoveController.GetPlayerTransform());
            _cameraController = new CameraController(_playerMoveController.GetPlayerTransform(), Camera.main.transform);
            _coinController = new CoinController();
        }       
        public void Update()
        {
            _enemyAnimator.Update();
            _gunController.Update();
            _cameraController.Update();
        }

        public void FixedUpdate()
        {
            _playerMoveController.FixedUpdate();
        }

        private void LoadEnemiesController()
        {
            _policemanConfig = Resources.Load<SpriteAnimatorConfig>("PolicemanAnimationCfg");
            _enemyView = GameObject.FindGameObjectWithTag("Enemy").AddComponent<LevelObjectView>();
            _enemyAnimator = new SpriteAnimatorController(_policemanConfig);
            _enemyAnimator.StartAnimation(_enemyView._spriteRenderer, AnimState.Run);
        }
        
    }
}
