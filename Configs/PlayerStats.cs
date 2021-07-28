using UnityEngine;
namespace PlatformerMVC
{

    [CreateAssetMenu(fileName = "Player", menuName = "UnitStats /Player")]
    public class PlayerStats : ScriptableObject
    {
        [SerializeField] private float _moveSpeed = 150f;
        [SerializeField] private float _jumpForce = 10f;
        [SerializeField] private float _animationSpeed = 10f;

        [SerializeField] private float _movingTreshold = 0.1f;
        [SerializeField] private float _jumpTreshold = 0.6f;

        [SerializeField] private int _healhPoints = 5;
        [SerializeField] private float _damage = 2f;

        [SerializeField] private Vector2 _respawn = new Vector2(-6.5f,-1.5f);
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private BoxCollider2D _collider2D;
        [SerializeField] private GameObject _playerPrefab;
              
 
        public float MoveSpeed => _moveSpeed;
        public float JumpForce => _jumpForce;
        public float AnimationSpeed => _animationSpeed;

        public float MovingTrashold => _movingTreshold;
        public float JumpTrashold => _jumpTreshold;

        public int HealthPoints => _healhPoints;
        public float Damage => _damage;

        public Vector2 Respawn => _respawn;
        public Rigidbody2D Rigidbody2D => _rigidbody2D;
        public BoxCollider2D BoxCollider2D => _collider2D;
        public GameObject PlayerPrefab => _playerPrefab;


    }
}
