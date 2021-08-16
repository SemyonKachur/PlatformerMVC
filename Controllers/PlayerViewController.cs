using System;
using UnityEngine;

namespace PlatformerMVC
{
    public class PlayerViewController
    {
        private LevelObjectView _view;
        private PlayerRespawn _playerRespawn;
        private PlayerController _playerController;
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

        public event Action<GameObject> PlayerContact = delegate (GameObject gameObject) { };
        public event Action<int, int> PlayerHP = delegate (int healthPoints, int lives) { };
        public event Action<bool> GameOver = delegate (bool GameOver) { };


        public PlayerViewController(PlayerController playerController)
        {
            _playerController = playerController;
            _playerAnimatorConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimCfg");
            _view = GameObject.FindGameObjectWithTag("Player").AddComponent<LevelObjectView>();
            _playerRigidbody = _view.gameObject.GetComponent<Rigidbody2D>();
            _playerCollider = _playerRigidbody.gameObject.GetComponent<CapsuleCollider2D>();
            _spriteAnimator = new SpriteAnimatorController(_playerAnimatorConfig);
            _contactPoller = new ContactPoller(_playerCollider);
            _playerRespawn = GameObject.FindObjectOfType<PlayerRespawn>();
            _playerRespawn.Damage += TakeDamage;
        }

        public void TakeDamage(int damage)
        {
            _playerController.PlayerHealthPoints -= damage;
            if (_playerController.PlayerHealthPoints < 1)
            {
                if (_playerController.PlayerLives != 0)
                {
                    --_playerController.PlayerLives;
                    _playerController.PlayerHealthPoints = _playerController.PlayerData.HealthPoints;
                }
                else GameOver.Invoke(true);
            }
            PlayerHP.Invoke(_playerController.PlayerHealthPoints, _playerController.PlayerLives);
        }
        public void FixedUpdate()
        {
            _spriteAnimator.Update();
            _contactPoller.Update();

            for (int i = 0; i < _contactPoller.ContactCount; i++)
            {
                if (_contactPoller.Contacts[i].collider.gameObject.CompareTag("Enemy"))
                {
                    TakeDamage(1);
                }
                if (_contactPoller.Contacts[i].collider.gameObject.CompareTag("Bullet"))
                {
                    PlayerContact.Invoke(_contactPoller.Contacts[i].collider.gameObject);
                    TakeDamage(1);
                    _contactPoller.Contacts[i].collider.gameObject.SetActive(false);
                }
            }
        }
    }
}
