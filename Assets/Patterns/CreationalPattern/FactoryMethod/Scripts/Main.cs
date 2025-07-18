using Patterns.Common;
using UnityEngine;

namespace Patterns.CreationalPatterns.Factory
{
	public class Main : MonoBehaviour
	{
		[SerializeField] private ModelType modelType;

		private FactoryBase factory;
		private ModelBase model;

		private void Start()
		{
			switch (modelType)
			{
				case ModelType.Sphere:
					factory = new SphereFactory();
					break;
				case ModelType.Cube:
					factory = new CubeFactory();
					break;
				case ModelType.Cylinder:
					factory = new CylinderFactory();
					break;
			}

			if(factory == null)
			{
				Debug.LogError("Factory Main : modelType is Invalid");
				return;
			}

			Debug.Log("Press Space bar");
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				model = factory.CreateModelObject();
				model.LogModelName();
			}
		}
	}
}