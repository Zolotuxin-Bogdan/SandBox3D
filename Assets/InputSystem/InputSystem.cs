using System.Collections;
using UnityEngine;

namespace Assets.InputSystem
{
    public class InputSystem : MonoBehaviour
    {
        public delegate void KeyPressed();
        public event KeyPressed OnKeyPressed;
        public event KeyPressed OnLeftMouseButtonClicked;
        MovementKeyBindings movementBindings;
        ActionKeyBindings actionBindings;

        public static InputSystem instance {get; private set;}
        protected void Awake()
        {
            instance = this;
            movementBindings = new MovementKeyBindings();
            actionBindings = new ActionKeyBindings();
        }

        private void Update() {
            StartCoroutine(WaitKey());
        }

        private IEnumerator WaitKey()
        {
            while (!Input.anyKeyDown)
            {
                yield return null;
            }

            if (Input.GetMouseButton(1))
            {
                OnLeftMouseButtonClicked?.Invoke();
            }
            OnKeyPressed?.Invoke();
        }

        public float GetHorizontalMovementValue()
        {
            if(Input.GetKey(movementBindings.KeyRight.keyCode))
            {
                return 1f;
            }
            if (Input.GetKey(movementBindings.KeyLeft.keyCode))
            {
                return -1f;
            }
            return 0f;
        }

        public float GetVerticalMovementValue()
        {
            if (Input.GetKey(movementBindings.KeyForward.keyCode))
            {
                return 1f;
            }
            if (Input.GetKey(movementBindings.KeyBack.keyCode))
            {
                return -1f;
            }
            return 0f;
        }

        public bool IsJumpKeyPressed()
        {
            return Input.GetKey(movementBindings.KeyJump.keyCode);
        }

        public float GetMouseYAxis()
        {
            return Input.GetAxis("Mouse Y");
        }

        public float GetMouseXAxis()
        {
            return Input.GetAxis("Mouse X");
        }

        public float GetMouseWheelAxisValue(){
            return Input.GetAxis("Mouse ScrollWheel");
        }

        public bool IsDropKeyPressed()
        {
            return Input.GetKey(actionBindings.DropKey.keyCode);
        }

        public bool IsAttackKeyPressed()
        {
            return Input.GetKey(actionBindings.AttackKey.keyCode);
        }

        public bool IsAttackKeyReleased() 
        {
            return Input.GetKeyUp(actionBindings.AttackKey.keyCode);
        }
    
        public bool IsCrouchingKeyPressed()
        {
            return Input.GetKey(actionBindings.CrouchingKey.keyCode);
        }
        public bool IsUseKeyPressed()
        {
            return Input.GetKey(actionBindings.UseKey.keyCode);
        }

        public bool IsInventoryKeyPressed()
        {
            return Input.GetKey(actionBindings.InventoryKey.keyCode);
        }

        public bool IsOpenSettingsKeyPressed()
        {
            return Input.GetKey(KeyCode.Escape);
        }

        public bool IsConsoleKeyPressed()
        {
            return Input.GetKey(actionBindings.ConsoleKey.keyCode);
        }

        public bool IsConfirmKeyPressed()
        {
            return Input.GetKey(KeyCode.Return);
        }
    }
}
