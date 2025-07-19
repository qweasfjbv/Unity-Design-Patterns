# Builder Pattern

생성자 혹은 `Init` 함수보다 더 유연한 인스턴스 초기화를 가능하게 하는 패턴

## Why?

생성자 혹은 `Init` 함수로 초기화를 하게되면 다음과 같은 코드를 작성하게 됩니다.

```cs
AClass c1 = new AClass("AClass", 3, 4, null, true, ...);

AClass c2 = new AClass();
c2.Init("AClass", 3, 4, null, false, ...);
```

이는 몇 가지 문제점이 있습니다.

1. 파라미터가 너무 많아 가독성이 떨어지며, 유지보수에 어렵습니다.
2. 필요없는 파라미터를 처리하기 어렵습니다.

따라서 빌더 패턴을 사용하면 다음과 같이 작성가능합니다.

```cs
CharacterBuilder builder = new CharacterBuilder();
Character character = builder.SetName("character")
    .SetLevel(10)
    .SetMaxHP(100)
    .SetMaxMP(20)
    .SetAttack(10)
    .SetDefense(5)
    .Build();
```

## How?

`Character` 클래스에 `Builder` 를 파라미터로 받는 생성자를 생성합니다.

```cs
public Character(CharacterBuilder builder)
{
    name = builder.Name;
    level = builder.Level;
    // ...
}
```

`Builder` 에서는 Set 함수들에서는 값 대입과 Builder 인스턴스를 리턴하고, Build 함수에서는 Character 인스턴스를 생서하여 리턴합니다.

```cs
public CharacterBuilder SetDefense(int defense)
{
    this.defense = defense;
    return this;
}

public Character Build()
{
    return new Character(this);
}
```

### Advantages

- 필요없는 파라미터는 생략하거나, 필요한 파라미터를 추가하기 쉽습니다.
- 어떤 파라미터에 값이 들어갔는지 보기 쉬워 가독성이 높아집니다.