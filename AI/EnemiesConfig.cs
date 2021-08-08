using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

namespace PlatformerMVC
{
    [Serializable]
    public struct AIConfig
    {
        public float speed;
        public float minDistanceToTarget;
        public Transform[] waypoints;
        internal float minSqrDistanceToTarget;
    }

    public class EnemiesConfig 
    {
        [Header("Simple AI")]
        [SerializeField] private AIConfig _simplePatrolAIConfig;
        [SerializeField] private LevelObjectView _simplePatrolAIView;

        private SimplePatrolAI _simplePatrolAI;
        private ProtectorAI _protectorAI;
        private ProtectedZone _protectedZone;

        public EnemiesConfig()
        {
            _simplePatrolAI = new SimplePatrolAI(_simplePatrolAIView, new SimplePatrolModel(_simplePatrolAIConfig));          
        }

        private void FixedUpdate()
        {
            if (_simplePatrolAI != null) _simplePatrolAI.FixedUpdate();
        }

    }
}
