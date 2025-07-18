
namespace Patterns.CreationalPatterns.Builder
{
	public class CharacterBuilder
	{
		private string name;
		private int level;
		private int maxHP;
		private int maxMP;
		private int attack;
		private int defense;

		public CharacterBuilder SetName(string name)
		{
			this.name = name;
			return this;
		}

		public CharacterBuilder SetLevel(int level)
		{
			this.level = level;
			return this;
		}

		public CharacterBuilder SetMaxHP(int maxHP)
		{
			this.maxHP = maxHP;
			return this;
		}

		public CharacterBuilder SetMaxMP(int maxMP)
		{
			this.maxMP = maxMP;
			return this;
		}

		public CharacterBuilder SetAttack(int attack)
		{
			this.attack = attack;
			return this;
		}

		public CharacterBuilder setDefense(int defense)
		{
			this.defense = defense;
			return this;
		}

	}
}