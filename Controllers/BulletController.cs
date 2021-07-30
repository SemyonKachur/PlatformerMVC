using UnityEngine;

namespace PlatformerMVC
{
    public class BulletController
    {
        private BulletView _bulletView;
        private Transform _bulletTransform;
        private Transform _bulletSpawn;
        private Rigidbody2D _bulletRigidbody;
        private float _bulletStartSpeed = 5.0f;

        public BulletController()
        {
            _bulletView = GameObject.FindGameObjectWithTag("Bullet").AddComponent<BulletView>();
            _bulletRigidbody = _bulletView.GetComponent<Rigidbody2D>();
            _bulletView.gameObject.SetActive(false);
        }
        public GameObject GetBullet()
        {
            return _bulletView.gameObject;
        }
        public void Shooting(Transform bulletSpawn)
        {
            _bulletSpawn = bulletSpawn;
            _bulletView._transform.position = _bulletSpawn.position;
            _bulletView._transform.rotation = _bulletSpawn.rotation;
            _bulletView.gameObject.SetActive(true);
            _bulletRigidbody.AddForce(_bulletView.transform.up * _bulletStartSpeed, ForceMode2D.Impulse);
        }
      
    }
}
