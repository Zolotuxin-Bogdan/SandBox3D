using UnityEngine;
public class InputSystem
{
    private KeyboardBindings _bindings;
    public InputSystem()
    {
        _bindings = new KeyboardBindings();
    }
    public float GetHorizontalMovementValue()
    {
        if(Input.GetKey(_bindings.KeyRight))
        {
            return 1f;
        }
        if (Input.GetKey(_bindings.KeyLeft))
        {
            return -1f;
        }
        return 0f;
    }

    public float GetVerticalMovementValue()
    {
        if (Input.GetKey(_bindings.KeyForward))
        {
            return 1f;
        }
        if (Input.GetKey(_bindings.KeyBack))
        {
            return -1f;
        }
        return 0f;
    }

    public bool IsJumpKeyPressed()
    {
        return Input.GetKey(_bindings.KeyJump);
    }

    public bool IsLeftShiftPressed()
    {
        return Input.GetKey(_bindings.KeyLeftShift);
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

    public float GetIncline()
    {
        if (Input.GetKey(_bindings.KeyLeftIncline))
        {
            return 1f;
        }
        if (Input.GetKey(_bindings.KeyRightIncline))
        {
            return -1f;
        }
        return 0f;
    }
}
