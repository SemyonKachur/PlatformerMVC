using UnityEngine;

namespace PlatformerMVC
{
    public class GunMoveController
    {
        private Transform _player;
        private Transform _bulletSpawn;
        private BulletView _buletView;
        private BulletController _bulletController;

        private float _attackDistance = 50.0f;
        private float _timer = 5.0f;
        private float _delayTime = 5.0f;
        private bool _isShooting = false;
        private GameObject[] guns = new GameObject[5];

        public GunMoveController(Transform player)
        {
            _player = player;
            guns = GameObject.FindGameObjectsWithTag("Gun");
            _bulletController = new BulletController();
            _buletView = _bulletController.GetBullet().GetComponent<BulletView>();
        }
        
        public BulletView GetBulletView()
        {
            return _buletView;
        }

        public void Update()
        {
            _timer -= Time.deltaTime;

            for (int i = 0; i < guns.Length; i++)
            {
                var direction = guns[i].transform.position - _player.position;
                var angle = Vector3.Angle(Vector3.down, direction);
                var axis = Vector3.Cross(Vector3.down, direction);

                if (Vector2.SqrMagnitude(direction) < _attackDistance)
                {
                    guns[i].transform.rotation = Quaternion.AngleAxis(angle, axis);
                    _bulletSpawn = guns[i].transform.Find("ShootingSpawn");
                    if (_timer <= 0)
                    {
                        _timer = _delayTime;
                        _isShooting = false;
                        _bulletController.Shooting(_bulletSpawn);
 
                    }
                }

                if (_timer <= 3.0f) _buletView.gameObject.SetActive(false);
            }
            
            _timer -= Time.deltaTime;
            if (_timer <= 3.0f) _buletView.gameObject.SetActive(false);
        }
    }
}
