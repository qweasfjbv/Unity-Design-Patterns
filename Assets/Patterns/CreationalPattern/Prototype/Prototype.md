# Prototype Pattern

객체를 생성할 때 기존의 객체를 복사하여 생성하는 패턴

## Why?


깊은 복사를 해야하는 경우에 클래스 외부에서 복제를 하기엔 번거로운 부분이 많습니다.

```cs
// 코드가 쓸데없이 길어지며, AClass 내부 구조가 바뀌면 해당 코드도 바뀌어야 한다.
AClass class1 = new AClass(1, 2, 3, ...);   
AClass class2 = new AClass(class1.val1, class1.val2, class1.val3, ...);
```

또한 private 변수의 경우에는 위와 같은 방식으로 복제할 수 없습니다.

따라서 `Clone` 함수를 사용하여 깊은 복사한 인스턴스를 사용합니다.
    
```cs
private void Start()
{
    ClonableClass nested = new ClonableClass(101, null, 102);

    ClonableClass clone1 = new ClonableClass(1, nested, 2); // 오리지널 객체
    ClonableClass clone2 = clone1.Clone() as ClonableClass; // 복제된 객체

    Debug.Log($"IsSameInstance : {clone1 == clone2}");      // 다른 객체이지만 (false)
    Debug.Log($"IsSameValues : {clone1.Equals(clone2)}");   // 변수들의 값은 같다 (true)
}
```

## How?

핵심은 `Clone` 함수와 자신의 클래스를 파라미터로 갖는 생성자입니다.

```cs
    public abstract class PrototypeBase
    {
        private int prototypeInt;
        private PrototypeBase nestedClass;

        // 기본적인 파라미터를 받는 생성자
        public PrototypeBase(int pInt, PrototypeBase pClass)
        {
            prototypeInt = pInt;
            nestedClass = pClass;
        }
        // 해당 클래스를 파라미터로 받는 생성자
        public PrototypeBase(PrototypeBase prototype)
        {
            prototypeInt = prototype.prototypeInt;
            nestedClass = prototype.nestedClass?.Clone();
        }
        // Clone 함수
		public abstract PrototypeBase Clone();
	}
```

자식 클래스에서 해당 생성자를 통해 Clone함수를 구현할 수 있습니다.

```cs
    public class ClonableClass : PrototypeBase  // PrototypeBase를 상속
    {
        private int clonedInt;

        public ClonableClass(int pInt = 0, PrototypeBase pClass = null, int cloned = 1)
            : base(pInt, pClass)
        {
            clonedInt = cloned;
        }

        public ClonableClass(ClonableClass clonable)
            : base(clonable)
        {
            clonedInt = clonable.clonedInt;
        }

        // 생성자를 사용한 깊은 복사
        public override PrototypeBase Clone()
        {
            return new ClonableClass(this);
        }
    }
```

### Advantages

- 외부 클래스에서 내부 구조를 알 필요가 없으므로 결합도를 낮춥니다.
- 복잡한 객체를 쉽게 생성할 수 있습니다.