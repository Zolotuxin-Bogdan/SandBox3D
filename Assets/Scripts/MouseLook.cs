using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts
{
    public class MouseLook : MonoBehaviour
    {
        public RotationAxes Axes = RotationAxes.MouseXAndY;
        public float SensitivityHor = 9.0f;
        public float SensitivityVert = 9.0f;
        public float MinimumVert = -45.0f;
        public float MaximumVert = 45.0f;
        public bool isCursorVisible = false;
        public SettingsManager settings;

        private float _rotationX = 0;
        private InputSystem _inputSystem;
        private bool isInvertMouse;

        void Start()
        {
            isInvertMouse = false;//settings.GetSettings().invertMouse;
            Cursor.visible = isCursorVisible;
            _inputSystem = new InputSystem();
            Rigidbody body = GetComponent<Rigidbody>();
            if (body != null)
                body.freezeRotation = true;
        }
    
        void Update()
        {
            if (Axes == RotationAxes.MouseX)
            {
                if (isInvertMouse)
                    transform.Rotate(0,  _inputSystem.GetMouseXAxis() * SensitivityHor * (-1), 0);
                else
                    transform.Rotate(0,  _inputSystem.GetMouseXAxis() * SensitivityHor, 0);
            }
            else if (Axes == RotationAxes.MouseY)
            {
                if (isInvertMouse)
                    _rotationX += _inputSystem.GetMouseYAxis() * SensitivityVert;
                else
                    _rotationX -= _inputSystem.GetMouseYAxis() * SensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, MinimumVert, MaximumVert);
                float rotationY = transform.localEulerAngles.y;
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }
            else
            {
                if (isInvertMouse)
                    _rotationX += _inputSystem.GetMouseYAxis() * SensitivityVert;
                else
                    _rotationX -= _inputSystem.GetMouseYAxis() * SensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, MinimumVert, MaximumVert);
                float delta = _inputSystem.GetMouseXAxis() * SensitivityHor;
                float rotationY = transform.localEulerAngles.y + delta;
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }
        }
    }
}