using UnityEngine;

namespace Patterns.StructuralPatterns.Decorator
{
	public abstract class PlayerDecorator : IAttackable
	{
		protected IAttackable player;

		public PlayerDecorator(IAttackable player)
		{
			this.player = player;
		}

		public virtual void Attack()
		{
			player.Attack();
		}
	}

	public class FireEnchantDecorator : PlayerDecorator
	{
		public FireEnchantDecorator(IAttackable player) : base(player) { }

		public override void Attack()
		{
			base.Attack();
			Debug.Log("불 속성");
		}
	}

	public class IceEnchantDecorator : PlayerDecorator
	{
		public IceEnchantDecorator(IAttackable player) : base(player) { }

		public override void Attack()
		{
			base.Attack();
			Debug.Log("얼음 속성");
		}
	}
}