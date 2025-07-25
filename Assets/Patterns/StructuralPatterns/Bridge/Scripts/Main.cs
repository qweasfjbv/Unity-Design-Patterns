using UnityEngine;

namespace Patterns.StructuralPatterns.Bridge
{
    public class Main : MonoBehaviour
    {
		private void Start()
		{
			Weapon sword = new Sword(new MeleeAttack());
			sword.UseWeapon();	// 검, 근거리 공격

			Weapon bow = new Bow(new RangedAttack());
			bow.UseWeapon();	// 활, 원거리 공격
		}
	}
}