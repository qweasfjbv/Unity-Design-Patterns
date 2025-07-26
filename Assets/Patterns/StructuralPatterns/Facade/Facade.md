# Facade Pattern

복잡한 서브시스템들을 감추고, 외부에 단순한 인터페이스만 제공하는 패턴

## Why?

외부에서 여러 서브시스템들을 직접 사용하기에는 번거로운 부분이 많습니다.

```cs
void DoSomething()
{
    ...
    audioSytem.PlayBGM();
    uiSystem.ShowUI();
    ...
}
```

`Facade` 패턴을 사용하여 복잡한 시스템을 감추면 다음과 같이 단순하게 사용 가능합니다.

```cs
void DoSomething()
{
    facade.DoAll();
}
```

## How?

구현 또한 단순하게 가능합니다.

```cs
public class GameStartFacade
{
    private AudioSystem audioSystem = new();
    private UISystem uiSystem = new();
    private SaveSystem saveSystem = new();

    public void StartGame()
    {
        audioSystem.PlayBGM();
        uiSystem.ShowMainMenu();
        saveSystem.LoadSaveData();
    }
}
```

하나의 클래스에서 여러 서브시스템을 묶어서 실행시켜 구현할 수 있습니다.


### Advantages 
- 복잡한 API 를 단순하게 래핑합니다.
- 클라이언트가 내부 시스템을 몰라도 되므로 결합도를 낮춥니다.
- 유지보수에 용이합니다.

### Disadvantages
- 퍼사드에 너무 많은 책임이 부여될 수 있습니다. (SRP 위반 가능성)