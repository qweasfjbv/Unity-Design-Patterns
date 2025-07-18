using UnityEngine;

namespace Patterns.CreationalPatterns.Singleton
{
    public class Main : MonoBehaviour
    {
		private void Start()
		{
			Debug.Log("Press Space bar");
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				SingletonClass.Instance.LogSingleton();
			}
		}
	}
}