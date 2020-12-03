using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 6.0f;
    public float Gravity = -9.8f;

    private readonly InputSystem _inputSystem = new InputSystem();
    private CharacterController _characterController;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        var deltaX = _inputSystem.GetHorizontalMovementValue() * Speed ;
        var deltaZ = _inputSystem.GetVerticalMovementValue() * Speed;
        var movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, Speed);
        movement.y = Gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);
    }
}
