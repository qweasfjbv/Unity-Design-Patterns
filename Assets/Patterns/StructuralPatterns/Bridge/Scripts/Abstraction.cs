using UnityEngine;

namespace Patterns.StructuralPatterns.Bridge
{ 
	public abstract class Weapon
	{
		protected IAttackStrategy attackStrategy;

		public Weapon(IAttackStrategy attackStrategy)
		{
			this.attackStrategy = attackStrategy;
		}

		public abstract void UseWeapon();
	}

	public class Sword : Weapon
	{
		public Sword(IAttackStrategy attackStrategy) : base(attackStrategy) { }

		public override void UseWeapon()
		{
			Debug.Log("검 사용");
			attackStrategy.Attack();
		}
	}

	public class Bow : Weapon
	{
		public Bow(IAttackStrategy attackStrategy) : base(attackStrategy) { }

		public override void UseWeapon()
		{
			Debug.Log("활 사용");
			attackStrategy.Attack();
		}
	}
}