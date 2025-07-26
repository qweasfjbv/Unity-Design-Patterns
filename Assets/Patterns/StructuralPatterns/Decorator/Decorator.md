# Decorator Pattern

기존 객체를 감싸서, 상속 등의 구조를 변경하지 않고 새로운 기능을 추가하는 패턴

## Why?

목적은 `Bridge` 패턴과 유사하게, 상속 클래스의 수가 많아지는 것을 방지하기 위함입니다.

```cs
void Start()
{
    IAttackable player;

    // 모든 경우의 수를 조건문으로 처리해야함
    if (useFire && useIce)
        player = new FireIcePlayer();
    else if (useFire)
        player = new FirePlayer();
    else if (useIce)
        player = new IcePlayer();
    else
        player = new BasePlayer();

    player.Attack();
}
```

Decorator 패턴을 사용하면 다음과 같이 사용 가능합니다.

```cs
void Start()
{
    IAttackable player = new BasePlayer();

    // 필요한 것만 데코레이터로 추가 가능
    if (useFire)
        player = new FireDecorator(player);
    if (useIce)
        player = new IceDecorator(player);

    player.Attack();
}
```

## How?

```cs
public abstract class PlayerDecorator : IAttackable
{
	protected IAttackable player;

	public PlayerDecorator(IAttackable player)
	{
		this.player = player;
	}

	public virtual void Attack()
	{
		player.Attack();
	}
}
```

Wrapper 추상 클래스 입니다.
- `IAttackable`을 생성자에서 입력받아 가지고 있어야하며
- `IAttackable`을 상속받아 외부에서 `IAttackble` 로 해당 래퍼 인스턴스를 사용할 수 있도록 해야합니다.

<br>

```cs
public class FireEnchantDecorator : PlayerDecorator
{
    public FireEnchantDecorator(IAttackable player) : base(player) { }

    public override void Attack()
    {
        base.Attack();
        Debug.Log("불 속성");
    }
}
```

### Advantages
- 상속 클래스 수가 많아지는 것을 방지할 수 있습니다.
- 여러 개의 데코레이터를 자유롭게 조합 가능합니다.

### Disadvantages
- 데코레이터가 많아지면 구조가 복잡해질 수 있습니다.
- 데코레이터 순서에 동작이 달라집니다.