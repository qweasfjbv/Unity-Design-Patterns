# Singleton Pattern

---

클래스의 인스턴스를 **단 하나만** 존재하도록 하여 해당 인스턴스에 대한 전역 접근을 할 수 있도록 하는 패턴

## Why?

Game, Resource, Data Manager 등 전역 접근이 가능해야 구현이 편해지는 기능이 있습니다.


```cs
[DefaultExecutionOrder(-100)]   // Unity 생명주기 메서드가 먼저 실행됨 ( Awake, Start, ... )
public class SingletonClass : MonoBehaviour
{
	private static SingletonClass instance;             // 유일한 인스턴스
	public static SingletonClass Instance => instance;  // 외부에서 사용하는 프로퍼티

	private void Awake()
	{
		if (instance == null)   // instacne가 null -> 해당 instance로 설정
		{
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else    // instance가 null이 아님 -> 이미 존재하므로 해당 instance는 삭제
		{
			Destroy(this.gameObject);
		}
	}

	// SingletonClass.Instance.LogSingleton(); 과 같이 접근 가능
	public void LogSingleton()
	{
		Debug.Log("Singleton Log Function");
	}
}
```

### Advantages

- 인스턴스에 대한 전역 접근을 가능하게 합니다.

### Disadvantages

- 전역 접근이 가능하기 때문에 발생하는 문제들 (코드 유지보수 어려움, 멀티스레딩 환경에서 동기화 문제 ...)
- 확장에 불리합니다.