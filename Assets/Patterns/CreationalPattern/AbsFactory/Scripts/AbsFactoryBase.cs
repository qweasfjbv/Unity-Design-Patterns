using Patterns.Common;
using UnityEngine;

namespace Patterns.CreationalPatterns.AbsFactory
{
	public abstract class AbsFactoryBase
	{
		public abstract ModelBase CreateCubeObject();
		public abstract ModelBase CreateSphereObject();
		public abstract ModelBase CreateCylinderObject();
	}

	public class AbsRedFactory : AbsFactoryBase
	{
		public override ModelBase CreateCubeObject()
		{
			return Object.Instantiate(PrefabLoader.Instance.GetPrefab(ModelType.Cube, ColorType.Red),
				Vector3.zero, Quaternion.identity, null)
				.GetComponent<ModelBase>();	
		}

		public override ModelBase CreateCylinderObject()
		{
			return Object.Instantiate(PrefabLoader.Instance.GetPrefab(ModelType.Cylinder, ColorType.Red),
				Vector3.zero, Quaternion.identity, null)
				.GetComponent<ModelBase>();
		}

		public override ModelBase CreateSphereObject()
		{
			return Object.Instantiate(PrefabLoader.Instance.GetPrefab(ModelType.Sphere, ColorType.Red),
				Vector3.zero, Quaternion.identity, null)
				.GetComponent<ModelBase>();
		}
	}

	public class AbsGreenFactory : AbsFactoryBase
	{
		public override ModelBase CreateCubeObject()
		{
			return Object.Instantiate(PrefabLoader.Instance.GetPrefab(ModelType.Cube, ColorType.Green),
				Vector3.zero, Quaternion.identity, null)
				.GetComponent<ModelBase>();
		}

		public override ModelBase CreateCylinderObject()
		{
			return Object.Instantiate(PrefabLoader.Instance.GetPrefab(ModelType.Cylinder, ColorType.Green),
				Vector3.zero, Quaternion.identity, null)
				.GetComponent<ModelBase>();
		}

		public override ModelBase CreateSphereObject()
		{
			return Object.Instantiate(PrefabLoader.Instance.GetPrefab(ModelType.Sphere, ColorType.Green),
				Vector3.zero, Quaternion.identity, null)
				.GetComponent<ModelBase>();
		}
	}

	public class AbsBlueFactory : AbsFactoryBase
	{
		public override ModelBase CreateCubeObject()
		{
			return Object.Instantiate(PrefabLoader.Instance.GetPrefab(ModelType.Cube, ColorType.Blue),
				Vector3.zero, Quaternion.identity, null)
				.GetComponent<ModelBase>();
		}

		public override ModelBase CreateCylinderObject()
		{
			return Object.Instantiate(PrefabLoader.Instance.GetPrefab(ModelType.Cylinder, ColorType.Blue),
				Vector3.zero, Quaternion.identity, null)
				.GetComponent<ModelBase>();
		}

		public override ModelBase CreateSphereObject()
		{
			return Object.Instantiate(PrefabLoader.Instance.GetPrefab(ModelType.Sphere, ColorType.Blue),
				Vector3.zero, Quaternion.identity, null)
				.GetComponent<ModelBase>();
		}
	}

	public class AbsWhiteFactory : AbsFactoryBase
	{
		public override ModelBase CreateCubeObject()
		{
			return Object.Instantiate(PrefabLoader.Instance.GetPrefab(ModelType.Cube, ColorType.White),
				Vector3.zero, Quaternion.identity, null)
				.GetComponent<ModelBase>();
		}

		public override ModelBase CreateCylinderObject()
		{
			return Object.Instantiate(PrefabLoader.Instance.GetPrefab(ModelType.Cylinder, ColorType.White),
				Vector3.zero, Quaternion.identity, null)
				.GetComponent<ModelBase>();
		}

		public override ModelBase CreateSphereObject()
		{
			return Object.Instantiate(PrefabLoader.Instance.GetPrefab(ModelType.Sphere, ColorType.White),
				Vector3.zero, Quaternion.identity, null)
				.GetComponent<ModelBase>();
		}
	}
}