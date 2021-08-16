using UnityEngine;
using System;

namespace PlatformerMVC
{

    public class BulletView : LevelObjectView
    {
        public event Action<GameObject> PlayerContact = delegate (GameObject gameObject) { };
        public event Action<int> Damage = delegate (int damage) { };


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                //PlayerContact.Invoke(this.gameObject);
                //Damage.Invoke(1);
                //gameObject.SetActive(false);
            }
            
        }
    }
}
