using System;
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

    private Vector3 _moveDirection;
    private Vector3 _moveVelocity;

    public float VelocityMagnitude => new Vector2(_moveVelocity.x, _moveVelocity.z).magnitude;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }
    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 10);

        // Draw Sphere
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }

    public void Move()
    {
        // _moveDirection = InputHandler.Instance.GetMoveDirection();
        // var move = _moveDirection;
        // var cameraEulerAngles = CameraManager.Instance.cameraTransform.eulerAngles;
        // _moveDirection = Quaternion.Euler(0, cameraEulerAngles.y, 0) * move;
        // if (move != Vector3.zero)
        // {
        //     var moveRotation = Vector3.Slerp(transform.forward, move, Time.deltaTime * smoothRotationSpeed);
        //     transform.rotation = Quaternion.LookRotation(moveRotation);
        //     if (_controller.isGrounded)
        //     {
        //         _moveVelocity = move * speed;
        //         _moveVelocity.y += gravity * Time.deltaTime;
        //
        //     }
        //     else
        //     {
        //         _moveVelocity.y = _controller.velocity.y + gravity * Time.deltaTime;
        //     }
        //     // _moveVelocity = move * speed;
        //     _controller.Move(_moveVelocity * Time.deltaTime);
        // }
        // else
        // {
        //     if (_controller.isGrounded)
        //     {
        //         _moveVelocity = Vector3.zero;
        //     }
        //     else
        //     {
        //         _moveVelocity.y += gravity * Time.deltaTime;
        //         _controller.Move(_moveVelocity * Time.deltaTime);
        //     }
        // }


        // Move and Rotate the player based on camera direction
        var moveDirection = InputHandler.Instance.GetMoveDirection();
        var cameraEulerAngles = CameraManager.Instance.cameraTransform.eulerAngles;
        moveDirection = Quaternion.Euler(0, cameraEulerAngles.y, 0) * moveDirection;
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
}