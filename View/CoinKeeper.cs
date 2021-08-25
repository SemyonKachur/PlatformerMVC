using UnityEngine;
using System;

namespace PlatformerMVC
{
    public class CoinKeeper : LevelObjectView
    {
        private CoinKeeper _coin;
        private LevelObjectView _playerView;
        private bool _isDone = false;
        private int _id;

        public int Id => _id;

        public bool IsDone { get; }

        public event Action<GameObject> CoinContact = delegate (GameObject gameObject) { };


        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                this._isDone = true;
                _playerView = collision.GetComponent<LevelObjectView>();
                CoinContact.Invoke(this.gameObject);
            }                
        }
    }
}
