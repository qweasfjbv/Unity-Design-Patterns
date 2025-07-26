# Composite Pattern

객체들을 트리 구조로 구성한 뒤, 부모 객체를 통해 서브트리를 하나의 객체처럼 다룰 수 있게 해주는 패턴

비슷한 예제로는 `Behaviour Tree` 가 있습니다.

## Why?

여러 객체의 함수를 직접 호출하기에는 번거로운 부분이 많습니다.

```cs
void DoSomething()
{
    instance1.DoSometing();
    instance1_1.DoSometing();
    instance1_2.DoSometing();
    ...
}
```

이러한 경우 객체를 트리 형태로 구성하여 부모 객체만 제어하면 간단합니다.

```cs
void Init()
{
    instance1 = new InstanceGroup("1");
    instance1.AddElement(new InstanceElement("1_1"));
    instance1.AddElement(new InstanceElement("1_2"));
}

void DoSomething()
{
    instance1.DoSomething();
}
```

## How?

```cs
public interface IMenuElement
{
    void Draw();
}
```

공통적인 작업이 들어갈 인터페이스 입니다.

```cs
public class MenuGroup : IMenuElement
{
    private string groupName;
    private List<IMenuElement> children = new();

    public MenuGroup(string groupName)
    {
        this.groupName = groupName;
    }

    public void Add(IMenuElement element)
    {
        children.Add(element);
    }

    public void Draw()
    {
        Debug.Log($"Drawing Group : {groupName}");
        for(int i = 0; i < children.Count; i++)
        {
            children[i].Draw();
        }
    }
}
```

인터페이스를 상속받은 `MenuGroup` 클래스 입니다.

- 해당 클래스에선 `List<IMenuElement>` 멤버 변수에 자식 인스턴스들을 담습니다.
- 인터페이스 구현 시 자식 인스턴스들의 인터페이스 함수를 호출해줍니다.

재귀적으로 인터페이스 함수가 호출되게 됩니다.

### Advantages
- 개방/폐쇄 원칙
- 복잡한 트리 구조를 편하게 사용 가능합니다.


### Disadvantages
- 공통 인터페이스를 제공하기 어려운 경우 존재합니다.
- 인터페이스를 지나치게 일반화하면 이해하기 어려울 수 있습니다.