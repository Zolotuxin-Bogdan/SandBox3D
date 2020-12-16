using Assets.Scripts.UserSettings;
using UnityEngine;
public class InputSystem
{
    private MovementKeyBindings _movementBindings;
    public InputSystem()
    {
        _movementBindings = new MovementKeyBindings();
    }
    public float GetHorizontalMovementValue()
    {
        if(Input.GetKey(_movementBindings.KeyRight.keyCode))
        {
            return 1f;
        }
        if (Input.GetKey(_movementBindings.KeyLeft.keyCode))
        {
            return -1f;
        }
        return 0f;
    }

    public float GetVerticalMovementValue()
    {
        if (Input.GetKey(_movementBindings.KeyForward.keyCode))
        {
            return 1f;
        }
        if (Input.GetKey(_movementBindings.KeyBack.keyCode))
        {
            return -1f;
        }
        return 0f;
    }

    public bool IsJumpKeyPressed()
    {
        return Input.GetKey(_movementBindings.KeyJump.keyCode);
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
}
