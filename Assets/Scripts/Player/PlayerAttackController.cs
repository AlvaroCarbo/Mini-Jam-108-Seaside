using Animations;
using Enums;
using Items;
using UnityEngine;
using Weapons;

namespace Player
{
    public class PlayerAttackController : MonoBehaviour
    {
        [SerializeField] private WeaponData currentWeapon;
        private PlayerAnimatorController _playerAnimatorController;

        private void Awake()
        {
            _playerAnimatorController = GetComponent<PlayerAnimatorController>();
        }

        public void Attack()
        {
            _playerAnimatorController.PlayTargetAnimation(currentWeapon.attackState, false, 1);
        }

        public void ShootProjectile()
        {
            var currentTransform = transform;
            var forward = currentTransform.forward;
            var projectile = Instantiate(((RangedWeaponData) currentWeapon).projectilePrefab,
                currentTransform.position + new Vector3(0, 0.8f, 0) + forward * 1,
                Quaternion.LookRotation(forward) * Quaternion.Euler(-90, 0, 0));

            projectile.GetComponent<Rigidbody>()
                .AddForce(transform.forward * ((RangedWeaponData) currentWeapon).projectileSpeed, ForceMode.Impulse);
        }
    }
}