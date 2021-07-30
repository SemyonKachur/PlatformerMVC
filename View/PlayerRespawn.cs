using UnityEngine;

namespace PlatformerMVC
{   
    public class PlayerRespawn : MonoBehaviour
    {
        [SerializeField] private Transform _playerSpawn;
        private LevelObjectView _playerView;

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                _playerView = collision.GetComponent<LevelObjectView>();
                _playerView._transform.position = _playerSpawn.position;
            }

        }
    }
}
