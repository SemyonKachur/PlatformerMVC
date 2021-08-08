using UnityEngine;

namespace PlatformerMVC
{
    [CreateAssetMenu(fileName = "AIConfig",menuName ="AI/AIConfig")]
    public class AIConfigSO : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _minDistanceToTarget;
        [SerializeField] private Transform[] _waypoints;
        [SerializeField] private float _minSqrDistanceToTarget;
        [SerializeField] private GameObject[] _way;

        public float Speed => _speed;
        public float MinDistanceToTarget => _minDistanceToTarget;

        public Transform[] Waypoints { get => _waypoints; set => _waypoints = value; }

        internal float MinSqrDistanceToTarget => _minSqrDistanceToTarget;

        public Transform[] GetWaypoints()
        {
             _waypoints = new Transform[_way.Length];
            for (int i = 0; i < _way.Length; i++)
            {
                _waypoints[i] = _way[i].transform;
            }
            return _waypoints;
        }

    }
}
