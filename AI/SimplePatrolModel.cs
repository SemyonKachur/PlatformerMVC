using UnityEngine;

namespace PlatformerMVC
{
    public class SimplePatrolModel
    {
        private readonly AIConfig _config;
        private Transform _target;
        private int _currentPointIndex;


        public SimplePatrolModel(AIConfig config)
        {
            _config = config;
            _target = GetNextWaypoint();
        }

        public Vector2 CalculateVelocity(Vector2 fromPosition)
        {
            var sqrDistance = Vector2.SqrMagnitude((Vector2)_target.position - fromPosition);
            if (sqrDistance <= _config.minSqrDistanceToTarget)
            {
                _target = GetNextWaypoint();
            }

            var direction = ((Vector2)_target.position - fromPosition).normalized;
            return _config.speed * direction;
        }

        private Transform GetNextWaypoint()
        {
            _currentPointIndex = (_currentPointIndex + 1) % _config.waypoints.Length;
            return _config.waypoints[_currentPointIndex];
        }

    }
}