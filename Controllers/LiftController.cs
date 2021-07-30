using UnityEngine;

namespace PlatformerMVC
{
    public class LiftController
    {
        private LiftMotorController[] _lifts;

        public LiftController()
        {
            _lifts = GameObject.FindObjectsOfType<LiftMotorController>();
        }
        public void Update()
        {
            for (int i = 0; i < _lifts.Length; i++)
            {
                _lifts[i].Update();
            }
        }
    }
}
