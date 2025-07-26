# Proxy Pattern

실제 객체의 접근에 대한 대리 역할을 하는 패턴

## Why?

접근 제한, 제어 로직과 실제 작업 수행부를 분리하기 위해 사용합니다.

```cs
public void DoSomething()
{
    if (userRole != "Admin") return;    // 접근 거부
    // ...

    if (document == null)
        document = new();   // Lazy Loading

    document.Display();
    // ...
}
```

프록시 패턴을 통해 분리하면 다음과 같습니다.

```cs
public void DoProxySomething()
{
    if (userRole != "Admin") return;    // 접근 거부
    // ...

    if (document == null)
        document = new();   // Lazy Loading

    document.DoSomething();
}
```

### Advantages
- OCP 원칙을 만족합니다.
- 보안 및 제어에 용이합니다.

### Disadvantages
- 클래스 수가 증가합니다.
- 일관성이 부족하면 오류가 발생할 수 있습니다.