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
        private float _g = -9.8f;
        private float _yVelocity = 0f;
        private float _xVelocity = 0f;

        private LevelObjectView _view;
        private SpriteAnimatorController _spriteAnimator;
        private SpriteAnimatorConfig _playerAnimatorConfig;
        private PlayerStats _playerData;
        private readonly ContactPoller _contactPoller;

        private CapsuleCollider2D _playerCollider;
        private Rigidbody2D _playerRigidbody;
       

        public PlayerController()
        {
            _playerData = Resources.Load<PlayerStats>("Player");
            _walkSpeed = _playerData.MoveSpeed;
            _animationSpeed = _playerData.AnimationSpeed;
            _movingTreshold = _playerData.MovingTrashold;
            _jumpForce = _playerData.JumpForce;
            _jumpTreshold = _playerData.JumpTrashold;

            _playerAnimatorConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimCfg");
            _view = GameObject.FindGameObjectWithTag("Player").AddComponent<LevelObjectView>();
            _view._transform.position = _playerData.Respawn;
            _playerRigidbody = _view.gameObject.GetComponent<Rigidbody2D>();
            _playerCollider = _playerRigidbody.gameObject.GetComponent<CapsuleCollider2D>();
            _spriteAnimator = new SpriteAnimatorController(_playerAnimatorConfig);
            _contactPoller = new ContactPoller(_playerCollider);
        }
        public Transform GetPlayerTransform()
        {
            return _view._transform;
        }

        private void MoveTowards()
        {
            _xVelocity = _walkSpeed * Time.deltaTime * (_xAxisInput < 0 ? -1 : 1);
            _playerRigidbody.velocity = _playerRigidbody.velocity.Change(x:_xVelocity);
            _view._transform.localScale = (_xAxisInput < 0 ? _leftScale : _rightScale);
        }

        public void FixedUpdate()
        {
            _spriteAnimator.Update();
            _contactPoller.Update();
            _xAxisInput = Input.GetAxis("Horizontal");
            _isJump = Input.GetAxis("Vertical") > 0;
            isMoving = Mathf.Abs(_xAxisInput) > _movingTreshold;
            bool isGrounded = _playerRigidbody.velocity.y <= _jumpTreshold;


            if (isMoving)
            {
                MoveTowards();
            }

            if (_contactPoller.isGrounded)
            {
                _spriteAnimator.StartAnimation(_view._spriteRenderer, isMoving ? AnimState.Run : AnimState.Idle, true, _animationSpeed);


                if(_isJump && isGrounded)
                {
                    _playerRigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                }
                
            }
            else
            {
                if(Mathf.Abs(_playerRigidbody.velocity.y) > _jumpTreshold)
                {
                    _spriteAnimator.StartAnimation(_view._spriteRenderer, AnimState.Jump, true, _animationSpeed);
                }

            }
        }
    }
}
