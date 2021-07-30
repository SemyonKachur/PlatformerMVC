using UnityEngine;

namespace PlatformerMVC
{
    public class ExplosionController
    {
        private GameObject _explosion;
        private BulletView _bullet;
        private LevelObjectView _explosionView;
        private SpriteAnimatorConfig _spriteConfig;
        private SpriteAnimatorController _animatorController;
        private float _explosionTime;
        
        public ExplosionController(BulletView buletView)
        {
            _bullet = buletView;
            _spriteConfig = Resources.Load<SpriteAnimatorConfig>("ExplosionAnimator");
            _animatorController = new SpriteAnimatorController(_spriteConfig);
            _explosion = GameObject.FindGameObjectWithTag("Explosion");
            _explosionView = _explosion.GetComponent<LevelObjectView>();
            _explosion.SetActive(false);
            _bullet.CoinContact += Explosion;
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
