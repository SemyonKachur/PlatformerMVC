using UnityEngine;

namespace PlatformerMVC
{
    public class ExplosionController
    {
        private GameObject _explosion;
        private PlayerViewController _playerView;
        private LevelObjectView _explosionView;
        private SpriteAnimatorConfig _spriteConfig;
        private SpriteAnimatorController _animatorController;
        private float _explosionTime;
        
        public ExplosionController(PlayerViewController playerView)
        {
            _playerView = playerView;
            _spriteConfig = Resources.Load<SpriteAnimatorConfig>("ExplosionAnimator");
            _animatorController = new SpriteAnimatorController(_spriteConfig);
            _explosion = GameObject.FindGameObjectWithTag("Explosion");
            _explosionView = _explosion.GetComponent<LevelObjectView>();
            _explosion.SetActive(false);
            _playerView.PlayerContact += Explosion;
        }

        public void Explosion(GameObject target)
        {
            _explosionTime = 0.2f;
            _explosion.transform.position = target.transform.position;
            _explosion.SetActive(true);
            _animatorController.StartAnimation(_explosionView._spriteRenderer, AnimState.Explosion, true, 10);              
        }

        public void Update()
        {
            _explosionTime -= Time.deltaTime;
            _animatorController.Update();
            if (_explosionTime <= 0) _explosion.SetActive(false);
        }
        
    }
}
