using UnityEngine;

namespace Patterns.CreationalPatterns.Builder
{
    public class Main : MonoBehaviour
    {
		private void Start()
		{
			CharacterBuilder builder = new CharacterBuilder();

			builder.SetName("character")
				.SetLevel(10)
				.SetMaxHP(100)
				.SetMaxMP(20)
				.SetAttack(10)
				.setDefense(5);
		}
	}
}