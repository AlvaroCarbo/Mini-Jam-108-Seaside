using UnityEngine;
using UnityEngine.InputSystem;

namespace Inputs
{
    public class InputHandler : MonoBehaviour
    {
        public static InputHandler Instance;
        private bool _isSprinting;
        private bool _isJumpPressed;
        
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
        
        private Vector2 _move;

        public Vector3 GetMoveDirection() => new(_move.x, 0, _move.y);
        public bool GetIsSprinting() => _isSprinting;
        public bool GetIsJumpPressed() => _isJumpPressed;

        public void OnMove(InputAction.CallbackContext context) => _move = context.ReadValue<Vector2>();
        public void OnSprint(InputAction.CallbackContext context) => _isSprinting = context.ReadValueAsButton();
        public void OnJump(InputAction.CallbackContext context) => _isJumpPressed = context.ReadValueAsButton();
    }
}