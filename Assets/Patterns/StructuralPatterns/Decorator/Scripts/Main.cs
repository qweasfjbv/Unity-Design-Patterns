using UnityEngine;

namespace Patterns.StructuralPatterns.Decorator
{
    public class Main : MonoBehaviour
    {
		private void Start()
		{
			IAttackable player = new BasePlayer();
			player = new FireEnchantDecorator(player);
			player = new IceEnchantDecorator(player);

			player.Attack(); // 기본 공격 + 불 + 얼음
		}
	}
}