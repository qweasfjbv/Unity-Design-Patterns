using System.Collections.Generic;
using UnityEngine;

namespace Patterns.Common
{

	public class PrefabLoader : MonoBehaviour
    {
		private static PrefabLoader instance;
		public static PrefabLoader Instance => instance;

		public PrefabLists prefabLists;

		private void Awake()
		{
			if(instance == null)
			{
				instance = this;
			}
			else
			{
				Destroy(this.gameObject);
			}
		}

		public GameObject GetPrefab(ModelType modelType, ColorType type = ColorType.White)
		{
			switch (modelType)
			{
				case ModelType.Sphere:
					return prefabLists.spherePrefabList[(int)type];
				case ModelType.Cube:
					return prefabLists.cubePrefabList[(int)type];
				case ModelType.Cylinder:
					return prefabLists.cylinderPrefabList[(int)type];
			}

			return null;
		}

	}
}