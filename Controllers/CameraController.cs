using UnityEngine;

namespace PlatformerMVC
{
    public class CameraController
    {
        private float X;
        private float Y;
        
        private float _xOffset = 1.5f;
        private float _yOffset = 1.5f;

        private int cameraSpeed = 150;

        private Transform _playerTransform;
        private Transform _cameraTransform;

        public CameraController(Transform playerTransform, Transform cameraTraansform)
        {
            _playerTransform = playerTransform;
            _cameraTransform = cameraTraansform;
        }

        public void Update()
        {
            X = _playerTransform.position.x;
            Y = _playerTransform.position.y;

            _cameraTransform.position = Vector3.MoveTowards(_cameraTransform.position,
                                        new Vector3(X + _xOffset, Y + _yOffset, _cameraTransform.position.z),Time.deltaTime*cameraSpeed);
        }

    }
}
