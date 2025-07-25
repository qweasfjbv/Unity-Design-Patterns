using UnityEngine;

namespace Patterns.StructuralPatterns.Adapter
{
	// 기존 시스템에서 쓰던 인터페이스
	public interface I2DMovable
	{
		public void Move(Vector2 direction);
	}

	// 호환되지 않는 외부 클래스
	public class Physics3D
	{
		public virtual void Move3D(Vector3 direction)
		{
			Debug.Log("Move3D : " + direction);
		}
	}

	// 호환하기위해 만든 어댑터 클래스
	public class Mover3DAdapter : I2DMovable
	{
		Physics3D mover;

		public Mover3DAdapter()
		{
			mover = new Physics3D();
		}

		public void Move(Vector2 direction)
		{
			mover.Move3D(new Vector3(direction.x, 0, direction.y));
		}
	}
}