using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        public float Speed = 6.0f;
        public float JumpHeight = 20.0f;
        public float Gravity = -9.8f;

        public GameObject PlayerHead;

        public GameObject FirstPersonCamPosition;
        public Camera FirstPersonCam;

        private float _verticalSpeed = 0;
        private bool isDigReady = true;

        private readonly InputSystem _inputSystem = new InputSystem();
        private CharacterController _characterController;
        private Camera _firstPersonCamera;
        private GameObject _lastGameObject;

        public static PlayerController instance;

        void Awake()
        {
            instance = this;
        }

        void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _firstPersonCamera = FirstPersonCam.GetComponent<Camera>();
            _lastGameObject = new GameObject();
            _lastGameObject.AddComponent<BlockInstance>();
        }

        void Update()
        {
            Move();
            if (_inputSystem.IsAttackKeyPressed())
            {
                Dig();
            }
            else if (_inputSystem.IsAttackKeyReleased())
            {
                if (_lastGameObject != null)
                {
                    _lastGameObject.GetComponent<BlockInstance>().RestoreMaxDurability();
                }
                //isDigReady = true;
            }

        }

        void Move()
        {
            FirstPersonCam.transform.position = FirstPersonCamPosition.transform.position;
            //PlayerHead.transform.rotation = Quaternion.Euler(new Vector3(_firstPersonCamera.transform.rotation.eulerAngles.x * -1, _firstPersonCamera.transform.rotation.eulerAngles.y + 180f, transform.rotation.z));

            var mouseDirection = _inputSystem.GetMouseXAxis();

            var camRotationY = FirstPersonCam.transform.rotation.eulerAngles.y;

//            Debug.Log("Body: " + transform.rotation.eulerAngles.y);
//            Debug.Log("Body Round: " + Math.Round(transform.rotation.eulerAngles.y));


            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, (float)Math.Round(transform.rotation.eulerAngles.y), transform.rotation.z));
            if (mouseDirection > 0)
            {
                if (transform.rotation.eulerAngles.y >= 310)
                {
                    // Debug.Log("Camera: " + camRotationY);
                    if (camRotationY <= 50 && 360 + camRotationY >= transform.rotation.eulerAngles.y + 50f)
                    {
                        if (transform.rotation.eulerAngles.y + 10 > 360)
                        {
                            var yRotation = transform.rotation.eulerAngles.y + 10 - 360;
                            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, yRotation, transform.rotation.z));
                        }
                        else
                        {
                            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.eulerAngles.y + 10, transform.rotation.z));
                        }
                    }
                }
                else if (camRotationY >= transform.rotation.eulerAngles.y + 50f)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.eulerAngles.y + 10, transform.rotation.z));

                }
            }
            else if (mouseDirection < 0)
            {
                if (transform.rotation.eulerAngles.y <= 50)
                {
                    if (camRotationY >= 310 && 360 - camRotationY <= transform.rotation.eulerAngles.y - 50f)
                    {
                        if (transform.rotation.eulerAngles.y - 10 < 0)
                        {
                            var yRotation = transform.rotation.eulerAngles.y - 10;
                            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 360 + yRotation,
                                transform.rotation.z));
                        }
                        else
                        {
                            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x,
                                transform.rotation.eulerAngles.y - 10, transform.rotation.z));
                        }
                    }
                }
                else if (camRotationY <= transform.rotation.eulerAngles.y - 50f)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x,
                        transform.rotation.eulerAngles.y - 10, transform.rotation.z));

                }
            }
            PlayerHead.transform.rotation = Quaternion.Euler(new Vector3(_firstPersonCamera.transform.rotation.eulerAngles.x * -1, _firstPersonCamera.transform.rotation.eulerAngles.y + 180f, transform.rotation.z));
            var deltaX = _inputSystem.GetHorizontalMovementValue() * Speed;
            var deltaZ = _inputSystem.GetVerticalMovementValue() * Speed;
            var movement = new Vector3(deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, Speed);
            movement = transform.TransformDirection(movement);
            if (_characterController.isGrounded)
            {
                _verticalSpeed = -1f;
                if (_inputSystem.IsJumpKeyPressed())
                {
                    _verticalSpeed = JumpHeight;
                }
            }
            _verticalSpeed += Gravity * Time.deltaTime;
            movement.y = _verticalSpeed;
            _characterController.Move(movement * Time.deltaTime);
        }



        void Dig()
        {
            if (!isDigReady) return;
            StartCoroutine(DigCoolDown(1));
            if (Physics.Raycast(FirstPersonCam.transform.position, FirstPersonCam.transform.forward, out var hit, 3))
            {

                //Debug.DrawLine(FirstPersonCam.transform.position, hit.point, Color.red);
                if (_lastGameObject != hit.collider.gameObject && _lastGameObject)
                {
                    _lastGameObject.GetComponent<BlockInstance>().RestoreMaxDurability();
                }

                hit.collider.gameObject.GetComponent<BlockInstance>().RemoveDurability(1);
                Debug.Log(hit.collider.gameObject.GetComponent<BlockInstance>().BlockDurability);


                _lastGameObject = hit.collider.gameObject;

            }

        }

        IEnumerator DigCoolDown(float waitTime)
        {
            isDigReady = false;
            yield return new WaitForSeconds(waitTime);
            isDigReady = true;
        }
    }
}
