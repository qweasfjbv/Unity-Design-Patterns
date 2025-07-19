# Singleton Pattern

클래스의 인스턴스를 **단 하나만** 존재하도록 하여 해당 인스턴스에 대한 전역 접근을 할 수 있도록 하는 패턴

## Why?

Resource, Data, Audio Manager 등 전역 접근이 가능해야 구현이 편해지는 기능이 있습니다.
예를 들어 어떤 Audio를 여러 클래스에서 재생시키고 싶다면, 모든 클래스에서 다음과 같이 구현해야합니다.

```cs
public class A : MonoBehaviour 
{
	public AudioClip clip1;		// 재생시키고 싶은 오디오 클립
	public new AudioSource audio;	// 재생 시킬 스피커

	private void PlaySFX1() => audio.PlayOneShot(clip1, 1f);
}
```

하지만 싱글톤 패턴을 통해 전역적인 접근을 가능하도록 하면,

1. Clip 및 AudioSource를 한곳에서 관리하며 오브젝트 풀링을 적용할 수 있습니다.
2. 오디오 재생이 필요한 클래스마다 관련 코드를 작성할 필요가 없습니다.

```cs
void DoSomething(){
	// ...
	// 필요시 어디서나 호출가능
	AudioManager.Instance.PlaySFX(SFXType.Boom, 1f, 0.5f, .3f);
}
```

## How?

핵심은 instance는 단 한개만 존재하도록 하며, 외부에서 접근할 수 있도록 해야하는 것입니다.

```cs
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
}
```

### Advantages

- 인스턴스에 대한 전역 접근을 가능하게 합니다.

### Disadvantages

- 전역 접근이 가능하기 때문에 발생하는 문제들 (코드 유지보수 어려움, 멀티스레딩 환경에서 동기화 문제 ...)
- 확장에 불리합니다.