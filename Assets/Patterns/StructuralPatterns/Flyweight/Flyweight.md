# Flyweight Pattern

공통 데이터를 공유하여 메모리 사용을 줄이는 패턴

## Why?

수십, 수백개의 객체가 있다고 가정할 때, 다음과 같은 변수들을 따로 가지고 있을 필요는 없습니다.

```cs
// Constants
private readonly string ANIM_PARAM_RUN = "isRun";

// Intrinsic Variables
private int speed = 5;
```

이런 것들을 유니티에서는 `ScriptableObject` 를 통해 저장하고, 참조 형태로 전달하여 메모리를 절약합니다.

## How?

```cs
[CreateAssetMenu(fileName = "WeaponData", menuName = "Patterns/Structrual/Flyweight/Weapon")]
public class WeaponData : ScriptableObject
{
    [SerializeField] private string weaponName;
    // ...

    public string WeaponName => weaponName;
    // ...
}
```

필요한 정보들을 담은 ScriptableObject를 Assets에 생성한 뒤에 참조를 연결해주면 됩니다.

```cs
public class FlyweightWeapon
{
    private WeaponData weaponData;

    public FlyweightWeapon(WeaponData weaponData)
    {
        this.weaponData = weaponData;
    }

    public void Attack()
    {
        Debug.Log($"{weaponData.WeaponName} : {weaponData.Strength}");
    }
}
```

### Advantages 
- 메모리 절약이 가능합니다.
- 데이터와 로직이 명확하게 나뉩니다.

### Disadvantages
- 공유데이터를 변경할 경우 위험합니다. ( Read-Only로 사용해야 안전 )