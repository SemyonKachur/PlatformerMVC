using UnityEngine;

namespace PlatformerMVC
{
    public class PlayerController
    {
        private float _xAxisInput;
        private bool _isJump;

        private float _walkSpeed;
        private float _animationSpeed;
        private float _movingTreshold;
        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);
        private bool isMoving;

        private float _jumpForce;
        private float _jumpTreshold;
        private float _xVelocity = 0f;
        private PlayerStats _playerData;
        private int _health;
        private int _lives;
        private PlayerViewController _playerView;

        public PlayerViewController PlayerView => _playerView;
        public PlayerStats PlayerData => _playerData;
        public int PlayerHealthPoints { get => _health; set => _health = value; }
        public int PlayerLives { get => _lives; set => _lives = value; }

        public PlayerController()
        {
            _playerData = Resources.Load<PlayerStats>("Player");
            _walkSpeed = _playerData.MoveSpeed;
            _animationSpeed = _playerData.AnimationSpeed;
            _movingTreshold = _playerData.MovingTrashold;
            _jumpForce = _playerData.JumpForce;
            _jumpTreshold = _playerData.JumpTrashold;
            _health = _playerData.HealthPoints;
            _lives = _playerData.Lives;
            _playerView = new PlayerViewController(this);
            _playerView.PlayerView._transform.position = _playerData.Respawn;
        }
        public Transform GetPlayerTransform()
        {
            return _playerView.PlayerView._transform;
        }
       
        private void MoveTowards()
        {
            _xVelocity = _walkSpeed * Time.deltaTime * (_xAxisInput < 0 ? -1 : 1);
            _playerView.PlayerRigidbody.velocity = _playerView.PlayerRigidbody.velocity.Change(x:_xVelocity);
            _playerView.PlayerView._transform.localScale = (_xAxisInput < 0 ? _leftScale : _rightScale);
        }

        public void FixedUpdate()
        {
            _playerView.FixedUpdate();
            _xAxisInput = Input.GetAxis("Horizontal");
            _isJump = Input.GetAxis("Vertical") > 0;
            isMoving = Mathf.Abs(_xAxisInput) > _movingTreshold;
            bool isGrounded = _playerView.PlayerRigidbody.velocity.y <= _jumpTreshold;


            if (isMoving)
            {
                MoveTowards();
            }

            if (_playerView.ContactPoller.isGrounded)
            {
                _playerView.SpriteAnimatorController.StartAnimation(_playerView.PlayerView._spriteRenderer, isMoving ? AnimState.Run : AnimState.Idle, true, _animationSpeed);

                if(_isJump && isGrounded)
                {
                    _playerView.PlayerRigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                }                
            }
            else
            {
                if(Mathf.Abs(_playerView.PlayerRigidbody.velocity.y) > _jumpTreshold)
                {
                    _playerView.SpriteAnimatorController.StartAnimation(_playerView.PlayerView._spriteRenderer, AnimState.Jump, true, _animationSpeed);
                }

            }
        }
    }
}
