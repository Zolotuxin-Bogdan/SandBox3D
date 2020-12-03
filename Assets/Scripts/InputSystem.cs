using UnityEngine;
public class InputSystem
{
    public float GetHorizontalAxis() { return Input.GetAxisRaw("Horizontal");}
    public float GetVerticalAxis() { return Input.GetAxisRaw("Vertical");}
}
