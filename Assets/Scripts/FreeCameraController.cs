using Assets.Scripts.Zoom;
using UnityEngine;

namespace Assets.Scripts
{
    public class FreeCameraController : MonoBehaviour 
    {
        [Header("Camera Positioning")]
        public Vector2 cameraOffset = new Vector2(10f, 14f);
        public float lookAtOffset = 2f;

        [Header("Move Controls")]
        public float moveSpeed = 5f;

        [Header("Zoom Controls")]
        public float zoomSpeed = 5f;
        public float minZoomLimit = 2f;
        public float maxZoomLimit = 16f;
        public float wheelValueIncrement = 1000f;
        public float startingZoom = 5f;

        IZoomStrategy zoomStrategy;
        float frameZoom;
        Camera cam;
        InputSystem inputSystem;
        CharacterController controller;
        private void Awake() {
            cam = GetComponentInChildren<Camera>();
            inputSystem = InputSystem.instance;
            Cursor.lockState = CursorLockMode.Locked;
            controller = GetComponentInChildren<CharacterController>();
            zoomStrategy = cam.orthographic ?(IZoomStrategy) new OrthographicZoomStrategy(cam, startingZoom) : new PerspectiveZoomStrategy(cam, cameraOffset, startingZoom);
        }

        private void Update() {
            UpdateFrameZoom();
            Move();
        }
        private void LateUpdate() {
            if (frameZoom > 0f)
            {
                zoomStrategy.ZoomIn(cam, Time.deltaTime * Mathf.Abs(frameZoom) * zoomSpeed, minZoomLimit);
                frameZoom = 0f;
            }
            else if (frameZoom < 0f)
            {
                zoomStrategy.ZoomOut(cam, Time.deltaTime * Mathf.Abs(frameZoom) * zoomSpeed, maxZoomLimit);
                frameZoom = 0f;
            }
        }
        void UpdateFrameZoom(){
            frameZoom += inputSystem.GetMouseWheelAxisValue() * wheelValueIncrement;
        }
        
        void Move()
        {
            var deltaX = inputSystem.GetHorizontalMovementValue() * moveSpeed;
            var deltaZ = inputSystem.GetVerticalMovementValue() * moveSpeed;
            var deltaY = 0f;

            var movement = new Vector3(deltaX, deltaY, deltaZ);
            movement = Vector3.ClampMagnitude(movement, moveSpeed);
            movement = transform.TransformDirection(movement);
            if (Input.GetKey(KeyCode.LeftControl))
                controller.Move(movement * Time.fixedDeltaTime);
            else
                controller.Move(movement * Time.deltaTime);
        }
    }
}