using Patterns.Common;
using UnityEngine;

namespace Patterns.CreationalPatterns.Factory
{
	public class Main : MonoBehaviour
	{
		[SerializeField] private ModelType modelType;

		private FactoryBase[] factory;
		private ModelBase model;

		private void Start()
		{
			factory = new FactoryBase[3];
			factory[0] = new SphereFactory();
			factory[1] = new CubeFactory();
			factory[2] = new CylinderFactory();

			Debug.Log("Press Space bar");
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				model = factory[(int)modelType].CreateModelObject();
				model.LogModelName();
			}
		}
	}
}