using System;

namespace Patterns.CreationalPatterns.Prototype
{
    public abstract class PrototypeBase
    {
        private int prototypeInt;
        private PrototypeBase nestedClass;

        public PrototypeBase(int pInt, PrototypeBase pClass)
        {
            prototypeInt = pInt;
            nestedClass = pClass;
        }

        public PrototypeBase(PrototypeBase prototype)
        {
            prototypeInt = prototype.prototypeInt;
            nestedClass = prototype.nestedClass?.Clone();
        }

		public abstract PrototypeBase Clone();

		public override bool Equals(object obj)
		{
			return (obj is PrototypeBase prototype)
				? prototype.prototypeInt == this.prototypeInt && Equals(nestedClass, prototype.nestedClass)
				: false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(prototypeInt, nestedClass.GetHashCode());
		}
	}

    public class ClonableClass : PrototypeBase
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

        public override PrototypeBase Clone()
        {
            return new ClonableClass(this);
        }

        public override bool Equals(object obj)
        {
            bool cond = (obj is ClonableClass prototype)
				? prototype.clonedInt == this.clonedInt
				: false;
            return cond && base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(base.GetHashCode(), clonedInt);
		}
	}
}