using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "New Ranged Weapon", menuName = "Weapons/Ranged Weapon")]
    public class RangedWeaponData : WeaponData
    {
        public GameObject projectilePrefab;
        public float projectileSpeed;
    }
}