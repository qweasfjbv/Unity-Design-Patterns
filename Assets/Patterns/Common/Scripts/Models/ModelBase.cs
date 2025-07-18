using UnityEngine;

namespace Patterns.Common
{

	public abstract class ModelBase : MonoBehaviour
	{
		[SerializeField] protected ColorType colorType;
		
		public abstract void LogModelName();
	}
}