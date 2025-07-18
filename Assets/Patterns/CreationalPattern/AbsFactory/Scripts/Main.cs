using Patterns.Common;
using UnityEngine;

namespace Patterns.CreationalPatterns.AbsFactory
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private ColorType colorType;

		private AbsFactoryBase factory;
		private ModelBase cubeModel;
		private ModelBase sphereModel;
		private ModelBase cylinderModel;

		private void Start()
		{
			switch (colorType) {
				case ColorType.Red:
					factory = new AbsRedFactory();
					break;
				case ColorType.Green:
					factory = new AbsGreenFactory();
					break;
				case ColorType.Blue:
					factory = new AbsBlueFactory();
					break;
				case ColorType.White:
					factory = new AbsWhiteFactory();
					break;
			}

			if (factory == null)
			{
				Debug.LogError("colorType is invalid");
				return;
			}

			Debug.Log("Press Space bar");
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				cubeModel = factory.CreateCubeObject();
				sphereModel = factory.CreateSphereObject();
				cylinderModel = factory.CreateCylinderObject();

				cubeModel.LogModelName();
				sphereModel.LogModelName();
				cylinderModel.LogModelName();
			}	
		}
	}
}