using UnityEngine;

namespace Patterns.CreationalPatterns.Singleton
{
	[DefaultExecutionOrder(-100)]
	public class SingletonClass : MonoBehaviour
	{
		private static SingletonClass instance;
		public static SingletonClass Instance => instance;

		private void Awake()
		{
			if (instance == null)
			{
				instance = this;
			}
			else
			{
				Destroy(this.gameObject);
			}
		}

		public void LogSingleton()
		{
			Debug.Log("Singleton Log Function");
		}
	}
}