using System.Collections.Generic;
using UnityEngine;

namespace Patterns.StructuralPatterns.Flyweight
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private WeaponData weaponData;
		[SerializeField] private int weaponCount = 10;

		List<FlyweightWeapon> weapons = new();

		private void Start()
		{
			for(int i=0; i<weaponCount; i++)
			{
				weapons.Add(new FlyweightWeapon(weaponData));
			}

			weapons[weaponCount - 1].Attack();
		}
	}
}