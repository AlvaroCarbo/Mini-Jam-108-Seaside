using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance;
    
    private Vector2 _move;
    public Vector2 Move => _move;
    // private InputActionPhase moveInputPhase;
    // public InputActionPhase MoveInputPhase => moveInputPhase;

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
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _move = context.ReadValue<Vector2>();
        // moveInputPhase = context.phase;
        // PlayerAgentController.Instance.OnMoveTo(context.ReadValue<Vector2>());
        // var forward = Camera.main.gameObject.transform.forward;
        // Debug.DrawRay(transform.position, forward, Color.red, 1f);

        // PlayerAgentController.Instance.OnMoveTo(forward * context.ReadValue<Vector2>());
        // movement = context.ReadValue<Vector2>();
    }
}