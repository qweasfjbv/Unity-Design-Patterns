# Adapter Pattern

호환되지 않는 인터페이스를 가진 객체들이 호환되도록 하는 패턴

## Why?

어댑터를 사용하지 않으면 중복 코드 발생 및 유연성이 떨어집니다.

```cs
void MoveLogic(Vector2 dir) 
{
    if(physics is Physics3D physics3D)  // Physics3D : 호환되지 않는 외부 클래스
    {
        physics3D.Move(new Vector3(dir.x, 0, dir.y));
    }
    else
    {
        physics.Move(dir);
    }
}
```

어댑터를 사용하면 다음과 같이 사용할 수 있습니다.

```cs
void MoveLogic(Vector2 dir) 
{
    IMovable movable = physics as IMovable;
    movable.Move(dir);
}
```

## How ?

어댑터 패턴은 호환되지 않지만 정상 작동하는 클래스를 최대한 수정하지 않고 내부 시스템과 호환되게 하기 위한 목적입니다.

```cs
// 기존 시스템에서 쓰던 인터페이스
public interface I2DMovable
{
    public void Move(Vector2 direction);
}

// 호환되지 않는 외부 클래스
public class Physics3D
{
    public virtual void Move(Vector3 direction)
    {
        Debug.Log("Move3D : " + direction);
    }
}
```

예를 들어, 위와 같이 기존 시스템에서 사용하는 인터페이스와 외부 클래스가 있다고 가정하겠습니다.

외부에서 `Physics3D` 의 내부는 모르지만 `I2DMovable` 은 사용 가능하게 하여 호환되도록 해야합니다.

```cs
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
        mover.Move(new Vector3(direction.x, 0, direction.y));
    }
}
```