using UnityEngine;

namespace PlatformerMVC
{
    public class AIEnemiesController
    {
        private LevelObjectView _enemyView;
        private GameObject[] _views;
        private EnemiesConfig _enemiesConfig;
        private AIConfig _aiConfig;
        private AIConfigSO _configs;
        private SimplePatrolModel _simplePatrolModel;
        private SimplePatrolAI _simplePatrolAI;

        public AIEnemiesController()
        {
            _configs = Resources.Load<AIConfigSO>("PoliceAIConfig");
            _configs.Waypoints = _configs.GetWaypoints();
            _aiConfig = new AIConfig();
            _aiConfig.minDistanceToTarget = _configs.MinDistanceToTarget;
            _aiConfig.minSqrDistanceToTarget = _configs.MinSqrDistanceToTarget;
            _aiConfig.speed = _configs.Speed;
            _aiConfig.waypoints = _configs.Waypoints;

            _views = GameObject.FindGameObjectsWithTag("Police");
            for (int i = 0; i < _views.Length; i++)
            {
                _enemyView = _views[i].AddComponent<LevelObjectView>();
            }

            _simplePatrolModel = new SimplePatrolModel(_aiConfig);
            _simplePatrolAI = new SimplePatrolAI(_enemyView, _simplePatrolModel);
 
        }

        public void FixedUpdate()
        {
            if (_simplePatrolAI != null) _simplePatrolAI.FixedUpdate();
        } 
    }
}

