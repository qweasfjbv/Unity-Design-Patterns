using UnityEngine;

namespace Patterns.StructuralPatterns.Facade
{
	public class AudioSystem
	{
		public void PlayBGM() => Debug.Log("BGM 재생");
	}

	public class UISystem
	{
		public void ShowMainMenu() => Debug.Log("메인 메뉴 표시");
	}

	public class SaveSystem
	{
		public void LoadSaveData() => Debug.Log("데이터 로드");
	}
}