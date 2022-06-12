using Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Inputs
{
    public class InputHandler : MonoBehaviour
    {
        public static InputHandler Instance;
        private bool _isSprinting;
        private bool _isJumpPressed;
        [SerializeField] private float jumpPressedTime;
        [SerializeField] private float jumpThreshold = 0.5f;

        private PlayerAttackController _playerAttackController;

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
            
            _playerAttackController = GetComponent<PlayerAttackController>();
        }

        private Vector2 _move;

        public Vector3 GetMoveDirection() => new(_move.x, 0, _move.y);
        public bool GetIsSprinting() => _isSprinting;
        public bool GetIsJumpPressed() => _isJumpPressed && jumpPressedTime + jumpThreshold > Time.time;

        public void OnMove(InputAction.CallbackContext context) => _move = context.ReadValue<Vector2>();
        public void OnSprint(InputAction.CallbackContext context) => _isSprinting = context.ReadValueAsButton();

        public void OnJump(InputAction.CallbackContext context)
        {
            _isJumpPressed = context.ReadValueAsButton();
            if (_isJumpPressed)
                jumpPressedTime = Time.time;
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton())
            {
                _playerAttackController.Attack();
            }
        }
    }
}