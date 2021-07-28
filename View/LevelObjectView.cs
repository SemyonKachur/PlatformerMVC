using UnityEngine;

namespace PlatformerMVC
{
    public class LevelObjectView : MonoBehaviour
    {
        public GameObject _unit;
        public Transform _transform;
        public SpriteRenderer _spriteRenderer;
        public Rigidbody2D _rigidbody;

        public void Awake()
        {
            _unit = this.gameObject;
            _transform = _unit.transform;
            _spriteRenderer = _unit.GetComponent<SpriteRenderer>();
        }
    }
}
