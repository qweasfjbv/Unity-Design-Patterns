# Abstract Factory Pattern

객체들의 **모음**을 추상화하여 인스턴스화 하도록 하는 패턴 

## Why?

예를 들어, 게임에서 각 직업에 따라 무기, 스킬 등이 다르다고 가정하겠습니다.
일반적으로는 다음과 같이 선언해야합니다.

```cs
private void InitClass(ClassType myClass) 
{
    switch(myClass) {
        case ClassType.Warrior:
            skill = new Slash();
            weapon = new Sword();
            ability = new Fortify();
            break;
        case ClassType.Archer:
            skill = new ArrowRain();
            weapon = new Bow();
            ability = new BetterEyes();
            break;
        ...
    }
}
```

이와 같은 코드는 조건문이 계속 늘어날 수 있으며 유지보수에 어려움을 겪게 됩니다.
특히 각 무기, 스킬 클래스의 `Init` 코드까지 포함된다면 가독성 또한 떨어지게 됩니다.

`Abstract Factory Pattern`을 사용하게 되면 다음과 같이 사용할 수 있게 됩니다.

```cs
private void Start()
{
    switch (colorType) {
        case ColorType.Red:
            factory = new AbsRedFactory();
            break;
        ...
    }

    cubeModel = factory.CreateCubeObject();
    sphereModel = factory.CreateSphereObject();
    cylinderModel = factory.CreateCylinderObject();
}

```

## How?

```cs
// 추상 클래스에서 Create 함수 인터페이스 제공
public abstract class AbsFactoryBase
{
    public abstract ModelBase CreateCubeObject();
    public abstract ModelBase CreateSphereObject();
    public abstract ModelBase CreateCylinderObject();
}
```

```cs
// 자식 클래스에서 추상함수 구현
public class AbsRedFactory : AbsFactoryBase
{
    public override ModelBase CreateCubeObject()
    {
        return Object.Instantiate(PrefabLoader.Instance.GetPrefab(ModelType.Cube, ColorType.Red),
            Vector3.zero, Quaternion.identity, null)
            .GetComponent<ModelBase>();	
    }

    public override ModelBase CreateCylinderObject()
    {
        return Object.Instantiate(PrefabLoader.Instance.GetPrefab(ModelType.Cylinder, ColorType.Red),
            Vector3.zero, Quaternion.identity, null)
            .GetComponent<ModelBase>();
    }

    public override ModelBase CreateSphereObject()
    {
        return Object.Instantiate(PrefabLoader.Instance.GetPrefab(ModelType.Sphere, ColorType.Red),
            Vector3.zero, Quaternion.identity, null)
            .GetComponent<ModelBase>();
    }
}
```

자식 클래스에서 추상함수를 구현할 때, 해당 클래스에 맞는 오브젝트 **조합**을 만들 수 있습니다.
필요시 각자에 맞는 `Init` 함수 또한 추가할 수 있습니다.

### Advantages
- 하나의 팩토리에서 생성되는 제품들의 호환 보장 가능
- 제품들과 클라이언트 코드 사이의 결함을 느슨하게 함