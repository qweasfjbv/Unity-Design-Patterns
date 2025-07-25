using UnityEngine;

namespace Patterns.StructuralPatterns.Bridge
{
	public interface IAttackStrategy
	{
		public void Attack();
	}

	public class MeleeAttack : IAttackStrategy
	{
		public void Attack()
		{
			Debug.Log("근접 공격");
		}
	}

	public class RangedAttack : IAttackStrategy
	{
		public void Attack()
		{
			Debug.Log("원거리 공격");
		}
	}
}