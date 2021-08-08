using UnityEngine;

namespace PlatformerMVC
{

    public class EnemyViewController
    {
        private GameObject[] _enemies;
        private LevelObjectView[] _view;
        private SpriteAnimatorController[] _spriteAnimator;
        private SpriteAnimatorConfig _enemyAnimatorConfig;
        private readonly ContactPoller[] _contactPoller;
        private BoxCollider2D[] _enemyCollider;
        private Rigidbody2D[] _enemyRigidbody;

        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);

        public LevelObjectView[] PlayerView => _view;
        public SpriteAnimatorController[] SpriteAnimatorController => _spriteAnimator;
        public SpriteAnimatorConfig SpriteAnimatorConfig => _enemyAnimatorConfig;
        public ContactPoller[] ContactPoller => _contactPoller;
        public BoxCollider2D[] PlayerCollider => _enemyCollider;
        public Rigidbody2D[] PlayerRigidbody => _enemyRigidbody;


        public EnemyViewController()
        {
            _enemyAnimatorConfig = Resources.Load<SpriteAnimatorConfig>("PolicemanAnimationCfg");
            _enemies = GameObject.FindGameObjectsWithTag("Police");
            _view = new LevelObjectView[_enemies.Length];
            _enemyRigidbody = new Rigidbody2D[_enemies.Length];
            _enemyCollider = new BoxCollider2D[_enemies.Length];
            _spriteAnimator = new SpriteAnimatorController[_enemies.Length];
            _contactPoller = new ContactPoller[_enemies.Length];
            for (int i = 0; i < _enemies.Length; i++)
            {
                _view[i] = _enemies[i].GetComponent<LevelObjectView>();
                _enemyRigidbody[i] = _view[i].gameObject.GetComponent<Rigidbody2D>();
                _enemyCollider[i] = _enemyRigidbody[i].gameObject.GetComponent<BoxCollider2D>();
                _spriteAnimator[i] = new SpriteAnimatorController(_enemyAnimatorConfig);
                _spriteAnimator[i].StartAnimation(_view[i]._spriteRenderer, AnimState.Run, true, 10);
                _contactPoller[i] = new ContactPoller(_enemyCollider[i]);
            }
            
        }

        public void FixedUpdate()
        {
            for (int i = 0; i < _spriteAnimator.Length; i++)
            {
                _spriteAnimator[i].Update();
                _view[i]._transform.localScale = (_enemyRigidbody[i].velocity.x < 0 ? _leftScale : _rightScale);
            }

            for (int i = 0; i < _contactPoller.Length; i++)
            {
                _contactPoller[i].Update();
            }
        }
    }
}