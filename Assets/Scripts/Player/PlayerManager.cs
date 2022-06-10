using Animations;
using UnityEngine;
using static Enums.AnimatorParameters;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerAnimatorController playerAnimatorController;

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
            playerAnimatorController = GetComponent<PlayerAnimatorController>();
        }

        private void Update()
        {
            playerMovement.Move();
        }

        private void LateUpdate()
        {
            playerAnimatorController.SetFloat(Velocity, playerMovement.VelocityMagnitude);
        }
    }
}