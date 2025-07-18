using UnityEngine;

namespace Patterns.Common
{
	public class Cube : ModelBase
	{
		public override void LogModelName()
		{
			Debug.Log($"Log : {colorType} Cube");
		}
	}
}