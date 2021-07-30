using UnityEngine;
using System;

namespace PlatformerMVC
{

    public class BulletView : LevelObjectView
    {
        public event Action<GameObject> CoinContact = delegate (GameObject gameObject) { };

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                CoinContact.Invoke(this.gameObject);
                gameObject.SetActive(false);
            }
            
        }
    }
}
