using Cameras;
using Inputs;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField] private float speed = 8f;
    [SerializeField] [Range(0, 10)] private float smoothRotationSpeed = 5f;
    [SerializeField] private float jumpHeight = 10f;
    [SerializeField] private float gravity = -9.81f;

    private Vector3 _moveVelocity;

    public float VelocityMagnitude => _moveVelocity.magnitude;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Move(); 
        // Jump(); // Jump the player
    }

    public void Move()
    {
        // Move and Rotate the player based on camera direction
        var moveDirection = InputHandler.Instance.GetMoveDirection();
        var cameraEulerAngles = CameraManager.Instance.cameraTransform.eulerAngles;
        moveDirection = Quaternion.Euler(0, cameraEulerAngles.y, 0) * moveDirection;
        if (moveDirection != Vector3.zero)
        {
            var moveRotation = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * smoothRotationSpeed);
            transform.rotation = Quaternion.LookRotation(moveRotation);
            _moveVelocity = moveDirection * speed;
            // _moveVelocity.y = _moveVelocity.y + gravity * Time.deltaTime;
            _controller.Move(_moveVelocity * Time.deltaTime);
        }
        else
        {
            _moveVelocity = Vector3.zero;
        }
    }

    private void Jump()
    {
        // throw new NotImplementedException();
    }
}