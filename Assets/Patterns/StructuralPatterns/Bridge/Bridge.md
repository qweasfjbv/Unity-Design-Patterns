# Bridge Pattern

클래스들을 추상화 및 구현 계층으로 나누어 각각 독립적으로 개발할 수 있도록 하는 패턴

## Why?

`모델` 과 `색` 을 상속구조로 나누려면 불필요하게 많은 클래스들이 만들어지게 됩니다.

```cs
public void DoSomething()
{
    RedSquare rsq = new RedSquare();
    RedSphere rsp = new RedSphere();
    BlueSquare bsq = new BlueSquare();
    BlueSphere bsp = new BlueSphere();
    ...
}
```

이를 좀 더 간단하게 구조화하기 위해 브릿지 패턴을 사용합니다.

```cs
public void DoSomething()
{
    Square sq = new Square(new RedColor()); // RedSquare
}
```

이를 통해 불필요하게 많은 클래스를 생성할 필요가 없습니다.


## How?

구현부부터 보겠습니다.

```cs
public interface IAttackStrategy
{
    public void Attack();
}

public class MeleeAttack : IAttackStrategy
{
    public void Attack()
    {
        Debug.Log("근접 공격");
    }
}

public class RangedAttack : IAttackStrategy
{
    public void Attack()
    {
        Debug.Log("원거리 공격");
    }
}
```

공격전략 인터페이스입니다. 이를 통해 근거리 공격 및 원거리 공격을 선택할 수 있습니다.

다음은 추상화 부분입니다.

```cs
public abstract class Weapon
{
    protected IAttackStrategy attackStrategy;

    public Weapon(IAttackStrategy attackStrategy)
    {
        this.attackStrategy = attackStrategy;
    }

    public abstract void UseWeapon();
}

public class Sword : Weapon
{
    public Sword(IAttackStrategy attackStrategy) : base(attackStrategy) { }

    public override void UseWeapon()
    {
        Debug.Log("검 사용");
        attackStrategy.Attack();
    }
}

public class Bow : Weapon
{
    public Bow(IAttackStrategy attackStrategy) : base(attackStrategy) { }

    public override void UseWeapon()
    {
        Debug.Log("활 사용");
        attackStrategy.Attack();
    }
}
```

각 무기 클래스에서 `attackStrategy` 가 근거리/원거리인지 상관없이 `Attack` 함수를 호출합니다.

이를 통해 `원거리 검` , `근거리 활`, `근거리 검`, `원거리 활` 클래스를 각각 구현하지 않아도 만들 수 있게 되었습니다.

### Advantages 

- 개방/폐쇄 원칙을 준수하여 새로운 추상화 및 구현들을 추가하기 쉽습니다.