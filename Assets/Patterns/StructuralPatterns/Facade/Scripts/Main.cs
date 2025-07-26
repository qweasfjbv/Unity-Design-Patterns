using UnityEngine;

namespace Patterns.StructuralPatterns.Facade
{
    public class Main : MonoBehaviour
    {
		GameStartFacade facade = new();
		private void Start()
		{
			facade.StartGame();
		}
	}
}