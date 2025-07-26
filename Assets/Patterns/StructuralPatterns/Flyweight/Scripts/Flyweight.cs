using UnityEngine;

namespace Patterns.StructuralPatterns.Flyweight
{
    public class FlyweightWeapon
    {
        private WeaponData weaponData;

        public FlyweightWeapon(WeaponData weaponData)
        {
            this.weaponData = weaponData;
        }

        public void Attack()
        {
            Debug.Log($"{weaponData.WeaponName} : {weaponData.Strength}");
        }
    }
}