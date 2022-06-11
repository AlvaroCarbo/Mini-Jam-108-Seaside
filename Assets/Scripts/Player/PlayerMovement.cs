using System;
using Cameras;
using Inputs;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField] private float speed;
    public float CurrentSpeed => speed;
    public bool IsJumping = false;

    [SerializeField] private float walkSpeed = 2f;
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] [Range(0, 10)] private float smoothRotationSpeed = 5f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 1;

    private Vector3 _moveDirection;
    private Vector3 _moveVelocity;

    [SerializeField] private bool groundedPlayer;
    [SerializeField] private Vector3 playerVelocity;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }


    public void Update()
    {
        groundedPlayer = _controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -1f;
        }

        var move = HandleDirection();
        
        HandleJump();
        if (move != Vector3.zero)
        {
            HandleSprint();
            HandleRotation(move);
        }
        else
        {
            speed = 0f;
        }

        _controller.Move(move * Time.deltaTime * speed);

        // Rotation

        // Changes the height position of the player..
        // if (Input.GetButtonDown("Jump") && groundedPlayer)
        // {
        //     playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        // }

        playerVelocity.y += gravity * Time.deltaTime;
        _controller.Move(playerVelocity * Time.deltaTime);
    }

    private Vector3 HandleDirection()
    {
        var move = InputHandler.Instance.GetMoveDirection();

        var cameraEulerAngles = CameraManager.Instance.cameraTransform.eulerAngles;

        return Quaternion.Euler(0, cameraEulerAngles.y, 0) * move;
    }

    private void HandleSprint()
    {
        var sprinting = InputHandler.Instance.GetIsSprinting();
        speed = sprinting ? runSpeed : walkSpeed;
    }

    private void HandleJump()
    {
        var jumping = InputHandler.Instance.GetIsJumpPressed();
        if (groundedPlayer)
        {
            IsJumping = false;
            if (jumping)
            {
                playerVelocity.y = Mathf.Sqrt(-2 * gravity * jumpHeight);
                IsJumping = true;
            }
        }
    }

    private void HandleRotation(Vector3 move)
    {
        var moveRotation = Vector3.Slerp(transform.forward, move, Time.deltaTime * smoothRotationSpeed);
        transform.rotation = Quaternion.LookRotation(moveRotation);
    }

    public void Move()
    {
        // Move 
        var moveDirection = InputHandler.Instance.GetMoveDirection();
        var cameraEulerAngles = CameraManager.Instance.cameraTransform.eulerAngles;
        moveDirection = Quaternion.Euler(0, cameraEulerAngles.y, 0) * moveDirection;

        var sprinting = InputHandler.Instance.GetIsSprinting();
        speed = sprinting ? runSpeed : walkSpeed;

        // Smooth Rotate
        if (moveDirection != Vector3.zero)
        {
            var moveRotation = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * smoothRotationSpeed);
            transform.rotation = Quaternion.LookRotation(moveRotation);
            _moveVelocity.y = _moveVelocity.y + gravity * Time.deltaTime;
            if (_controller.isGrounded)
            {
                _moveVelocity = moveDirection * speed;
            }
            else
            {
                var fallVelocity = new Vector3(moveDirection.x * speed / 2, _moveVelocity.y,
                    moveDirection.z * speed / 2);
                _moveVelocity = fallVelocity;
            }

            _controller.Move(_moveVelocity * Time.deltaTime);
        }
        else
        {
            _moveVelocity = new Vector3(0, _moveVelocity.y,
                0);
        }

        if (!_controller.isGrounded)
        {
            // apply gravity
            _moveVelocity.y += gravity * Time.deltaTime;
            _controller.Move(_moveVelocity * Time.deltaTime);
        }
    }


    private void Jump()
    {
        // throw new NotImplementedException();
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        var playerTransform = transform;
        var position = playerTransform.position;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(position, playerTransform.forward * 10);

        if (_controller == null) return;

        Gizmos.color = _controller.isGrounded ? Color.green : Color.yellow;
        //Gizmos.DrawMesh(_controller.bounds.center, _moveVelocity);
        Gizmos.DrawWireCube(_controller.bounds.center, _controller.bounds.size);
        // Gizmos.DrawSphere(_controller.bounds.center, 0.1f);
    }
#endif
}