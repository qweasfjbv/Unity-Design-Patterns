using UnityEngine;

namespace Patterns.StructuralPatterns.Composite
{
    public class Main : MonoBehaviour
    {
		private void Start()
		{
			// Composite
			MenuGroup mainMenu = new MenuGroup("Main Menu");
			mainMenu.Add(new MenuItem("NewGame"));
			mainMenu.Add(new MenuItem("LoadGame"));
			mainMenu.Add(new MenuItem("Exit"));

			// Sub Composite
			MenuGroup settings = new MenuGroup("Settings");
			settings.Add(new MenuItem("Audio"));
			settings.Add(new MenuItem("Graphics"));

			mainMenu.Add(settings);

			mainMenu.Draw();
		}
	}
}