using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 6.0f;
    public float JumpHeight = 20.0f;
    public float Gravity = -9.8f;

    private float _verticalSpeed = 0;

    private readonly InputSystem _inputSystem = new InputSystem();
    private CharacterController _characterController;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        var deltaX = _inputSystem.GetHorizontalMovementValue() * Speed ;
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
}
