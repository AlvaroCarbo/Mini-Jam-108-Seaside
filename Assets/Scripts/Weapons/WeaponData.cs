using UnityEngine;

namespace Weapons
{
    public abstract class WeaponData : ScriptableObject
    {
        public GameObject weaponPrefab;

        // public WeaponType weaponType;

        public Enums.AnimatorStates attackState;
    }

    // public enum WeaponType
    // {
    //     Melee,
    //     Ranged
    // }
}