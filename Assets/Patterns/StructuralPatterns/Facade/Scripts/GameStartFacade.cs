
namespace Patterns.StructuralPatterns.Facade
{
    public class GameStartFacade
    {
		private AudioSystem audioSystem = new();
		private UISystem uiSystem = new();
		private SaveSystem saveSystem = new();

		public void StartGame()
		{
			audioSystem.PlayBGM();
			uiSystem.ShowMainMenu();
			saveSystem.LoadSaveData();
		}
	}
}