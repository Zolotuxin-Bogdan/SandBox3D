using Assets.Scripts.Zoom;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraManager : MonoBehaviour 
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
        public float startingZoom = 5f;

        [Header("Rotate Controls")]
        public float mouseSensitivity = 100f;
        public Transform playerBody;
        float xRotation = 0f;

        IZoomStrategy zoomStrategy;
        float frameZoom;
        Camera cam;
        InputSystem inputSystem;
        CharacterController controller;
        MouseLook mouseLook;
        private void Awake() {
            cam = GetComponentInChildren<Camera>();
            cam.transform.localPosition = new Vector3(0f, Mathf.Abs(cameraOffset.y), -Mathf.Abs(cameraOffset.x));
            zoomStrategy = new OrthographicZoomStrategy(cam, startingZoom);
            cam.transform.LookAt(transform.position + Vector3.up * lookAtOffset);
            inputSystem = new InputSystem();
            Cursor.lockState = CursorLockMode.Locked;
            //mouseLook = gameObject.AddComponent<MouseLook>();
            controller = GetComponentInChildren<CharacterController>();
        }

        private void Update() {
            UpdateFrameZoom();
            Move();
            Rotating();
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
            frameZoom += inputSystem.GetMouseWheelAxisValue() * 1000;
        }
        
        void Move()
        {
            var deltaX = inputSystem.GetHorizontalMovementValue() * moveSpeed;
            var deltaZ = inputSystem.GetVerticalMovementValue() * moveSpeed;
            var deltaY = 0f;

            var movement = new Vector3(deltaX, deltaY, deltaZ);
            movement = Vector3.ClampMagnitude(movement, moveSpeed);
            movement = transform.TransformDirection(movement);
            controller.Move(movement * Time.deltaTime);
        }

        void Rotating(){
            float mouseX = inputSystem.GetMouseXAxis() * mouseSensitivity * Time.deltaTime;
            float mouseY = inputSystem.GetMouseYAxis() * mouseSensitivity * Time.deltaTime;
            //float mouseZ = inputSystem.GetIncline() * mouseSensitivity * Time.deltaTime;

            //playerBody.Rotate(new Vector3(-mouseY, mouseX, mouseZ));

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}