using Animations;
using Unity.VisualScripting;
using UnityEngine;
using static Enums.AnimatorParameters;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerAnimatorController playerAnimatorController;
        [SerializeField] private CharacterController characterController;

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
            playerAnimatorController = GetComponent<PlayerAnimatorController>();
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
        }

        private void LateUpdate()
        {
            // playerMovement.Move();
            playerAnimatorController.SetBool(Jumping, playerMovement.IsJumping);
            playerAnimatorController.SetFloat(Velocity, playerMovement.CurrentSpeed);
        }
    }
}