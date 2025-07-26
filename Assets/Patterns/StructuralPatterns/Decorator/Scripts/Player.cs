using UnityEngine;

namespace Patterns.StructuralPatterns.Decorator
{
	public interface IAttackable
	{
		void Attack();
	}

	public class BasePlayer : IAttackable
	{
		public void Attack()
		{
			Debug.Log("기본 공격");
		}
	}
}