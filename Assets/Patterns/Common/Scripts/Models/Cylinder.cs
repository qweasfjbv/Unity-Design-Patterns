using UnityEngine;

namespace Patterns.Common
{
	public class Cylinder : ModelBase
	{
		public override void LogModelName()
		{
			Debug.Log($"Log : {colorType} Cylinder");
		}
	}
}