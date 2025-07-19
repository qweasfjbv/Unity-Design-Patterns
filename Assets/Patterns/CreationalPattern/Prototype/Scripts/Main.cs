using UnityEngine;

namespace Patterns.CreationalPatterns.Prototype
{
	public class Main : MonoBehaviour
	{
		private void Start()
		{
			ClonableClass nested = new ClonableClass(101, null, 102);
			ClonableClass clone1 = new ClonableClass(1, nested, 2);
			ClonableClass clone2 = clone1.Clone() as ClonableClass;

			Debug.Log($"IsSameInstance : {clone1 == clone2}");
			Debug.Log($"IsSameValues : {clone1.Equals(clone2)}");
		}
	}
}