using UnityEngine;

namespace Patterns.Common
{
	public class Sphere : ModelBase
	{
		public override void LogModelName()
		{
			Debug.Log($"Log : {colorType} Sphere");
		}
	}
}