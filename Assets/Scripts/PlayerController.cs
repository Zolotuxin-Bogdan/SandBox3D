using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public float Speed = 6.0f;
    public float JumpHeight = 20.0f;
    public float Gravity = -9.8f;

    public GameObject PlayerHead;

    public GameObject FirstPersonCamPosition;
    public Camera FirstPersonCam;

    private float _verticalSpeed = 0;

    private readonly InputSystem _inputSystem = new InputSystem();
    private CharacterController _characterController;
    private Camera _firstPersonCamera;
    private UnityAction<string> _action;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _firstPersonCamera = FirstPersonCam.GetComponent<Camera>();
    }

    void Update()
    {
        Move();
        Dig();
    }

    void Move()
    {
        FirstPersonCam.transform.position = FirstPersonCamPosition.transform.position;
        PlayerHead.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, _firstPersonCamera.transform.rotation.eulerAngles.y + 180f, transform.rotation.z));
        if (PlayerHead.transform.rotation.eulerAngles.y > transform.rotation.eulerAngles.y + 50f)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.eulerAngles.y + 10f, transform.rotation.z));
        }
        if (PlayerHead.transform.rotation.eulerAngles.y < transform.rotation.eulerAngles.y - 50f)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x , transform.rotation.eulerAngles.y - 10f, transform.rotation.z));
        }

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
        Ray ray = FirstPersonCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3))
            Debug.DrawLine(ray.origin, hit.point, Color.red);
    }

    public void OnDropItemTouched(UnityAction<string> action)
    {
        _action = action;
    }

    void OnCollisionEnter(Collision col)
    {
        _action.Invoke(col.gameObject.name);
    }
}
