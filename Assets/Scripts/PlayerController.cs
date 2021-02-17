using System;
using System.Collections;
using Assets.FSM;
using Assets.Scripts.Enums;
using Assets.Scripts.Tools_and_Managers;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        private const double FIFTY_DEGREE = 50.001;

        public float Speed = 6.0f;
        public float JumpHeight = 20.0f;
        public float Gravity = -9.8f;

        public GameObject PlayerHead;

        public GameObject FirstPersonCamPosition;
        public Camera FirstPersonCam;

        private float _verticalSpeed = 0;
        private bool isDigReady = true;

        private InputSystem.InputSystem _inputSystem;
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
            _inputSystem = InputSystem.InputSystem.instance;
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
            var mouseDirection = _inputSystem.GetMouseXAxis();
            var camRotationY = FirstPersonCam.transform.rotation.eulerAngles.y;

            //
            // Rounding player model rotation to avoid non-integer values
            //
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, (float)Math.Round(transform.rotation.eulerAngles.y), transform.rotation.z));

            //
            // Rotate player model body by camera when rotation delta between them equal 50 degrees
            //

            //
            // When Right rotation
            //
            if (mouseDirection > 0)
            {
                if (transform.rotation.eulerAngles.y >= 310)
                {
                    if (camRotationY <= FIFTY_DEGREE && 360 + camRotationY >= transform.rotation.eulerAngles.y + FIFTY_DEGREE)
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
                else if (camRotationY >= transform.rotation.eulerAngles.y + FIFTY_DEGREE)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.eulerAngles.y + 10, transform.rotation.z));

                }
            }
            
            //
            // When Left rotation
            //
            else if (mouseDirection < 0)
            {
                if (transform.rotation.eulerAngles.y <= FIFTY_DEGREE)
                {
                    if (camRotationY >= 300 && camRotationY - 360 < transform.rotation.eulerAngles.y - FIFTY_DEGREE)
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
                else if (camRotationY <= transform.rotation.eulerAngles.y - FIFTY_DEGREE)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x,
                        transform.rotation.eulerAngles.y - 10, transform.rotation.z));

                }
            }
            
            //
            // Follow player model head by camera direction
            //
            PlayerHead.transform.rotation = Quaternion.Euler(new Vector3(_firstPersonCamera.transform.rotation.eulerAngles.x * -1, _firstPersonCamera.transform.rotation.eulerAngles.y + 180f, transform.rotation.z));
            
            //
            // User move input
            //
            var deltaX = _inputSystem.GetHorizontalMovementValue() * Speed;
            var deltaZ = _inputSystem.GetVerticalMovementValue() * Speed;
            
            //
            // Follow player model by camera direction
            //
            if (deltaZ > 0)
            {
                PlayerStatesManager.instance.SwitchState(CharacterStates.Walk);
                transform.rotation = Quaternion.RotateTowards(transform.rotation,
                    Quaternion.Euler(transform.rotation.eulerAngles.x, camRotationY, transform.rotation.eulerAngles.z), 
                    200 * Time.deltaTime);
                
            }
            else
            {
                PlayerStatesManager.instance.SwitchState(CharacterStates.Idle);
            }
            
            //
            // Player movement
            //
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
