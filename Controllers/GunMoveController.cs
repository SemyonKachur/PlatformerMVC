using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace PlatformerMVC
{
    public class GunMoveController
    {
        private Transform _player;
        private Transform _gun;
        private Transform _bulletSpawn;
        [SerializeField] private GameObject _bullet;
        private Vector2 _ballisticMagnitude;

        private float _speed = 5.0f;
        private float _bulletStartSpeed = 10f;
        private float _bulletMass = 500f;
        private float _gravity = 9.8f;
        private float _timer = 5.0f;
        private bool _isShooting = false;
        private GameObject[] guns = new GameObject[5];

        public GunMoveController(Transform player)
        {
            _player = player;
            guns = GameObject.FindGameObjectsWithTag("Gun");            
            _bullet = GameObject.FindGameObjectWithTag("Bullet");
            _bullet.SetActive(false);
        }

        public void Update()
        {
            _timer -= Time.deltaTime;

            for (int i = 0; i < guns.Length; i++)
            {
                var direction = guns[i].transform.position - _player.position;
                var angle = Vector3.Angle(Vector3.down, direction);
                var axis = Vector3.Cross(Vector3.down, direction);
                _bulletSpawn = guns[i].transform.Find("ShootingSpawn");


                if (Vector2.SqrMagnitude(direction) < 49)
                {
                    guns[i].transform.rotation = Quaternion.AngleAxis(angle, axis);
                    if (_timer <= 0)
                    {
                        _timer = 5.0f;
                        _isShooting = false;
                        Shooting();
                    }
                }

                if (_timer <= 3.0f) _bullet.SetActive(false);
            }
            
            _timer -= Time.deltaTime;
            if (_timer <= 3.0f) _bullet.SetActive(false);
        }

        private void Shooting()
        {
            _bullet.transform.position = _bulletSpawn.position;
            _bullet.transform.rotation = _bulletSpawn.rotation;
            var rigidbody = _bullet.GetComponent<Rigidbody2D>();
            _bullet.SetActive(true);
            rigidbody.AddForce(_bullet.transform.up * 5, ForceMode2D.Impulse);
            _isShooting = true;
        }
    }
}
