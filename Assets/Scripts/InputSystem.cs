using Assets.Scripts.UserSettings;
using UnityEngine;
public class InputSystem
{
    MovementKeyBindings movementBindings;
    ActionKeyBindings actionBindings;
    public InputSystem()
    {
        movementBindings = new MovementKeyBindings();
        actionBindings = new ActionKeyBindings();
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
    
    public bool IsCrouchingKeyPressed()
    {
        return Input.GetKey(actionBindings.CrouchingKey.keyCode);
    }
    public bool IsUseKeyPressed()
    {
        return Input.GetKey(actionBindings.UseKey.keyCode);
    }
}
