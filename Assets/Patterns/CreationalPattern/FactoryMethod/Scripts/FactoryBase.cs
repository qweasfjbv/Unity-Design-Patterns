using Patterns.Common;
using UnityEngine;

namespace Patterns.CreationalPatterns.Factory
{
	public abstract class FactoryBase
	{
		public abstract ModelBase CreateModelObject();
	}

	public class SphereFactory : FactoryBase
	{
		public override ModelBase CreateModelObject()
		{
			return Object.Instantiate(PrefabLoader.Instance.GetPrefab(ModelType.Sphere),
				Vector3.zero, Quaternion.identity, null)
				.GetComponent<ModelBase>();
		}
	}

	public class CubeFactory : FactoryBase
	{
		public override ModelBase CreateModelObject()
		{
			return Object.Instantiate(PrefabLoader.Instance.GetPrefab(ModelType.Cube), 
				Vector3.zero, Quaternion.identity, null)
				.GetComponent<ModelBase>();
		}
	}

	public class CylinderFactory : FactoryBase
	{
		public override ModelBase CreateModelObject()
		{
			return Object.Instantiate(PrefabLoader.Instance.GetPrefab(ModelType.Cylinder),
				Vector3.zero, Quaternion.identity, null)
				.GetComponent<ModelBase>();
		}
	}
}