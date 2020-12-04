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
        private float _rotationX = 0;
    
        void Start()
        {
            Cursor.visible = false;
            Rigidbody body = GetComponent<Rigidbody>();
            if (body != null)
                body.freezeRotation = true;
        }
    
        void Update()
        {
            if (Axes == RotationAxes.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * SensitivityHor, 0);
            }
            else if (Axes == RotationAxes.MouseY)
            {
                _rotationX -= Input.GetAxis("Mouse Y") * SensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, MinimumVert, MaximumVert);
                float rotationY = transform.localEulerAngles.y;
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }
            else
            {
                _rotationX -= Input.GetAxis("Mouse Y") * SensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, MinimumVert, MaximumVert);
                float delta = Input.GetAxis("Mouse X") * SensitivityHor;
                float rotationY = transform.localEulerAngles.y + delta;
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }
        }
    }
}