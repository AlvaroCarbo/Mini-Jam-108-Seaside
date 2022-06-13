using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "New Melee Weapon", menuName = "Weapons/Melee Weapon")]
    public class MeleeWeaponData : WeaponData
    {
        public Enums.AnimatorStates secondaryAttackState;
        public Enums.AnimatorStates thirdAttackState;
    }
}