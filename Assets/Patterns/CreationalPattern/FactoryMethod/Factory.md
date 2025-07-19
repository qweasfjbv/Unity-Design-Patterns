# Factory Method Pattern

인스턴스 생성 과정을 위임하여 객체 간의 결합도를 낮추는 패턴

## Why?

팩토리 메서드 패턴을 사용하지 않고 객체를 생성하기 위해선 다음과 같은 코드를 작성해야합니다.

```cs
BaseClass c1;
switch(type) {
    case Type.A : 
        c1 = new AClass();
        break;
    case Type.B :
        c2 = new BClass();
        break;
    ...
}
```

이는 새로운 인스턴스를 만들 때마다 추가해야됩니다.

여기서 `AClass` , `BClass` 자체를 저장할 수 있다면, `Unity`의 경우 PrefabObject를 `Awake` 같은 곳에서 캐싱해주면 코드를 중복작성 할 필요없이 가능할 것 같아 보입니다.

하지만 인스턴스의 초기화 과정이 다를 수 있습니다.

```cs
BaseClass c1 = Instantiate(cachedPrefab).GetComponent<BaseClass>();

if(c1 is AClass ac) {
    ac.InitAClass( ... );
}
else if(c1 is BClass bc) {
    bc.InitBClass( ... );
}
...
```

## How?

`FactoryBase` 클래스에서 `Create` 추상함수를 제공하고, 자식 Factory 클래스에서 이를 구현합니다.

```cs
public abstract class FactoryBase
{
    public abstract ModelBase CreateModelObject();
}

public class SphereFactory : FactoryBase
{
    public override ModelBase CreateModelObject()
    {
        // 필요시 추가 전처리도 가능
        return Object.Instantiate(PrefabLoader.Instance.GetPrefab(ModelType.Sphere),
            Vector3.zero, Quaternion.identity, null)
            .GetComponent<ModelBase>();
    }
}
```

`Factory` 는 다음과 같이 사용할 수 있습니다.


```cs
private void Start()
{
    // 편의상 팩토리들을 배열에 넣어두었습니다.
    // 메모리를 절약하기 위해서는 switch-case문을 통해 원하는 factory만 생성하면 됩니다.
    factory = new FactoryBase[3];
    factory[0] = new SphereFactory();
    factory[1] = new CubeFactory();
    factory[2] = new CylinderFactory();
}

private void Update()
{
    if (Input.GetKeyDown(KeyCode.Space))
    {
        // 다음과 같이 Model 오브젝트를 생성
        model = factory[(int)modelType].CreateModelObject();
        model.LogModelName();
    }
}
```

### Advantages

- 수정에 유연하며 확장성이 좋습니다.
- 전처리 코드를 각자의 클래스에서 구현하여 가독성을 높일 수 있습니다.