using System;
using System.Collections;
using System.Collections.Generic;
using Inputs;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerAgentController : MonoBehaviour
{
    public static PlayerAgentController Instance;

    public Vector3 Target =>
        float.IsPositiveInfinity(
            GetComponent<NavMeshAgent>().destination.magnitude)
            ? transform.position
            : GetComponent<NavMeshAgent>(
            ).destination;

    public delegate void MoveTo(Vector2 target);

    // public event MoveTo OnMoveTo;
    public MoveTo OnMoveTo;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        OnMoveTo += SetDestinationToMove;
    }

    public void Update()
    {
        // if (InputHandler.Instance.MoveInputPhase == InputActionPhase.Performed)
        {
            var origin = transform.position + Vector3.up * 0.5f;
            var inputDir = InputHandler.Instance.GetMoveDirection();
            // inputDir.x = Mathf.Clamp(inputDir.x, -1, 1);
            inputDir.x = -inputDir.x;
            var forward = Camera.main.transform.forward;
            var cameraDir = new Vector3(forward.x, 0, forward.z);

            Debug.DrawRay(origin, inputDir, Color.red, 1f);
            Debug.DrawRay(origin, cameraDir, Color.green, 1f);

            // Debug.Log(Vector3.Angle(cameraDir, Vector3.forward));
            var angle = Vector3.Angle(inputDir, cameraDir);
            
            var cross = Vector3.Cross(inputDir, cameraDir);
            if (cross.y < 0) angle = -angle;
            
            // Debug.Log(angle);
            // var angle = InputHandler.Instance.Move.x >= 0 ? Vector3.Angle(inputDir, cameraDir) : -Vector3.Angle(inputDir, cameraDir);
            var targetDir = Quaternion.AngleAxis(angle, Vector3.up) * Vector3.forward;
            // var targetDir = Quaternion.AngleAxis(angle, inputDir);
            Debug.DrawRay(origin, targetDir, Color.blue, 1f);
            // Debug.Log(Quaternion.AngleAxis(angle, inputDir));
            OnMoveTo?.Invoke(new Vector2(targetDir.x, targetDir.z));
        }
        // Debug.Log(InputHandler.Instance.MoveInputPhase);
    }

    private void SetDestinationToMove(Vector2 position)
    {
        var positionToMove = transform.position + new Vector3(position.x, 0, position.y);
        SetNavMeshAgentDestination(positionToMove);
    }

    private void SetNavMeshAgentDestination(Vector3 destination)
    {
        GetComponent<NavMeshAgent>().SetDestination(destination);
    }
}