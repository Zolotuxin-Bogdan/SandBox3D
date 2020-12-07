using UnityEngine;

namespace Assets.Scripts
{
    public class CameraController: MonoBehaviour
    {

        public float zoomFactor = 3f;
        public float zoomSpeed = 10f;
        public int speedIncrease = 2;
        public float Speed = 5.0f;
        private MouseLook _mouseLook;

        private Camera _camera;
        private float _targetZoom;
        private InputSystem _inputSystem;
        private CharacterController _characterController;

        //Unity Start Message
        void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _mouseLook = gameObject.AddComponent<MouseLook>();
            _inputSystem = new InputSystem();
            _camera = GetComponentInChildren<Camera>();
            _targetZoom = _camera.orthographicSize;
        }

        //Unity Update Message
        void Update()
        {
            Move();
            Zoom();
        }

        void Move()
        {
            var deltaX = _inputSystem.GetHorizontalMovementValue() * Speed;
            var deltaZ = _inputSystem.GetVerticalMovementValue() * Speed;
            var deltaY = 0f;

            if (_inputSystem.IsLeftShiftPressed())
            {
                deltaY *= speedIncrease;
                deltaX *= speedIncrease;
                deltaZ *= speedIncrease;
            }
            var movement = new Vector3(deltaX, deltaY, deltaZ);
            movement = Vector3.ClampMagnitude(movement, Speed);
            movement = transform.TransformDirection(movement);
            _characterController.Move(movement * Time.deltaTime);
        }

        void Zoom()
        {
            float scrollData = Input.GetAxis("Mouse ScrollWheel");
            _targetZoom -= scrollData * zoomFactor;
            _targetZoom = Mathf.Clamp(_targetZoom, 0f, 100f);
            _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize, _targetZoom, Time.deltaTime * zoomSpeed);
        }
    }
}