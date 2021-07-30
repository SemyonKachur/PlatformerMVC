using UnityEngine;

namespace PlatformerMVC
{
    public class PlayerViewController
    {
        private LevelObjectView _view;
        private SpriteAnimatorController _spriteAnimator;
        private SpriteAnimatorConfig _playerAnimatorConfig;
        private readonly ContactPoller _contactPoller;

        private CapsuleCollider2D _playerCollider;
        private Rigidbody2D _playerRigidbody;

        public LevelObjectView PlayerView => _view;
        public SpriteAnimatorController SpriteAnimatorController => _spriteAnimator;
        public SpriteAnimatorConfig SpriteAnimatorConfig => _playerAnimatorConfig;
        public ContactPoller ContactPoller => _contactPoller;
        public CapsuleCollider2D PlayerCollider => _playerCollider;
        public Rigidbody2D PlayerRigidbody => _playerRigidbody;


        public PlayerViewController()
        {
            _playerAnimatorConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimCfg");
            _view = GameObject.FindGameObjectWithTag("Player").AddComponent<LevelObjectView>();
            _playerRigidbody = _view.gameObject.GetComponent<Rigidbody2D>();
            _playerCollider = _playerRigidbody.gameObject.GetComponent<CapsuleCollider2D>();
            _spriteAnimator = new SpriteAnimatorController(_playerAnimatorConfig);
            _contactPoller = new ContactPoller(_playerCollider);
        }

        public void FixedUpdate()
        {
            _spriteAnimator.Update();
            _contactPoller.Update();
        }
    }
}
