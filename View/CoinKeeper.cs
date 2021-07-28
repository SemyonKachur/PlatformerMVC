using UnityEngine;
using System;

namespace PlatformerMVC
{
    public class CoinKeeper : LevelObjectView
    {
        private GameObject _coin;
        private LevelObjectView _playerView;

        public event Action<GameObject> CoinContact = delegate (GameObject gameObject) { };

        public void OnTriggerEnter2D(Collider2D collision)
        {
            _coin = this.gameObject;
            if (collision.gameObject.CompareTag("Player"))
            {
                _playerView = collision.GetComponent<LevelObjectView>();
                CoinContact.Invoke(this.gameObject);
            }
                
        }
    }
}
