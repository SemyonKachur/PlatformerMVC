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
            _sliderJoint = this.GetComponent<SliderJoint2D>();
            _motor = _sliderJoint.motor;
            _motorSpeed = _motor.motorSpeed;
            _rigidbody = _sliderJoint.gameObject.GetComponent<Rigidbody2D>();
        }

        public void Update()
        {
            if (_rigidbody.velocity == Vector2.zero)
            {
                _motorSpeed *= -1;
            }
        }

    }
}