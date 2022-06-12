using System;
using Animations;
using Enums;
using UnityEngine;

namespace Player
{
    public class PlayerAttackController : MonoBehaviour
    {
        // private WeaponData currentWeapon;
        private PlayerAnimatorController _playerAnimatorController;

        private void Awake()
        {
            _playerAnimatorController = GetComponent<PlayerAnimatorController>();
        }

        public void Attack()
        {
            _playerAnimatorController.PlayTargetAnimation(AnimatorStates.ShootBow, false, 1);
            Debug.Log("Attack");
        }
    }
}