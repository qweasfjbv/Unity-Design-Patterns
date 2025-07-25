using UnityEngine;

namespace Patterns.StructuralPatterns.Adapter
{
    public class Main : MonoBehaviour
    {
		private void Start()
		{
			I2DMovable adapter = new Mover3DAdapter();

			// Physics3D의 Move3D와 동일하게 작동
			adapter.Move(Vector2.one);
		}
	}
}