using UnityEngine;

namespace PlatformerMVC
{
    public class Main : MonoBehaviour
    {
        private Controllers _controllers;

        void Awake()
        {
            _controllers = new Controllers();
            _controllers.LevelGeneratorController.Init();
        }
                
        void Update()
        {
            _controllers.Update();
        }

        private void FixedUpdate()
        {
            _controllers.FixedUpdate();
        }
    }
}
