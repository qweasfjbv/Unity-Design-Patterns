using System.Collections.Generic;
using UnityEngine;

namespace Patterns.Common
{
	public enum ModelType
	{
		Sphere,
		Cube,
		Cylinder
	}

	public enum ColorType
	{
		White,
		Red,
		Green,
		Blue
	}

	[CreateAssetMenu(menuName = "Patterns/Common/PrefabLists")]
	public class PrefabLists : ScriptableObject
	{
		public List<GameObject> spherePrefabList = new();
		public List<GameObject> cubePrefabList = new();
		public List<GameObject> cylinderPrefabList = new();
	}
}