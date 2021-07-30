using UnityEngine;

namespace PlatformerMVC
{
    public class LiftMotorController : LevelObjectView
    {
        private SliderJoint2D _sliderJoint;
        private JointMotor2D _motor;
        private float _motorSpeed;
        private Rigidbody2D _rigidbody;


        public void Awake()
        {
            _rigidbody = this._rigidbody;
            _sliderJoint = this.GetComponent<SliderJoint2D>();
            _motor = _sliderJoint.motor;
            _motorSpeed = _motor.motorSpeed;
        }

        public void Update()
        {
            if (_sliderJoint.jointSpeed == 0.0f)
            {
                _motor.motorSpeed = _motorSpeed * -1;
            }
        }

    }
}