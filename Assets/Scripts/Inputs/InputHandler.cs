using UnityEngine;
using UnityEngine.InputSystem;

namespace Inputs
{
    public class InputHandler : MonoBehaviour
    {
        public static InputHandler Instance;
        
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

        public void OnMove(InputAction.CallbackContext context) => _move = context.ReadValue<Vector2>();
    }
}