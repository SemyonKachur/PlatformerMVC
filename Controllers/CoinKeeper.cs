using UnityEngine;
using System;

namespace PlatformerMVC
{
    public class CoinKeeper : LevelObjectView
    {
        private Rigidbody2D _rigidbody;
        private BoxCollider2D _collider;

        private void Awake()
        {
            _rigidbody = this.gameObject.AddComponent<Rigidbody2D>();
            _collider = this.gameObject.AddComponent<BoxCollider2D>();
        }

        public Action<CoinKeeper> CoinContact;
    }
}
