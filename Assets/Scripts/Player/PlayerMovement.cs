using System;
using Animations;
using Cameras;
using Enums;
using Inputs;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    private PlayerAnimatorController _animatorController;

    [SerializeField] private float speed;
    public float CurrentSpeed => speed;
    public bool IsJumping = false;

    [SerializeField] private float walkSpeed = 2f;
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float smoothAcceleration;

    [SerializeField] private float gravity = -9.81f;
    [SerializeField] public float jumpHeight = 1;

    [SerializeField] [Range(0, 10)] private float smoothRotationSpeed = 5f;

    private Vector3 _moveDirection;
    private Vector3 _moveVelocity;

    [SerializeField] public bool groundedPlayer;

    [SerializeField] private Vector3 playerVelocity;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _animatorController = GetComponent<PlayerAnimatorController>();
    }


    public void Update()
    {
        groundedPlayer = _controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -1f;
        }

        var move = HandleDirection();

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

        HandleJump();

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
        speed = Mathf.SmoothStep(speed, sprinting ? runSpeed : walkSpeed, Time.deltaTime * smoothAcceleration);
        // speed = sprinting ? runSpeed : walkSpeed;
    }

    private void HandleRotation(Vector3 move)
    {
        var moveRotation = Vector3.Slerp(transform.forward, move, Time.deltaTime * smoothRotationSpeed);
        transform.rotation = Quaternion.LookRotation(moveRotation);
    }

    private void HandleJump()
    {
        var jumping = InputHandler.Instance.GetIsJumpPressed();
        if (groundedPlayer)
        {
            if (IsJumping)
            {
                jumpHeight = 1f;
                _animatorController.SetTrigger(AnimatorParameters.Grounded);
            }

            IsJumping = false;
            if (jumping)
            {
                playerVelocity.y = Mathf.Sqrt(-2 * gravity * jumpHeight);
                if (!IsJumping)
                {
                    _animatorController.SetTrigger(AnimatorParameters.Jump);
                }

                IsJumping = true;
            }
        }
    }

    public void MoveHandler()
    {
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