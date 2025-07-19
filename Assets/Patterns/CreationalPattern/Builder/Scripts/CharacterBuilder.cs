
namespace Patterns.CreationalPatterns.Builder
{
	public class Character
	{
		private string name;
		private int level;
		private int maxHP;
		private int maxMP;
		private int attack;
		private int defense;
		public Character(CharacterBuilder builder)
		{
			name = builder.Name;
			level = builder.Level;
			maxHP = builder.MaxHP;
			maxMP = builder.MaxMP;
			attack = builder.Attack;
			defense = builder.Defense;
		}

	}

	public class CharacterBuilder
	{
		private string name = "Default";
		private int level = 10;
		private int maxHP = 10;
		private int maxMP = 10;
		private int attack = 10;
		private int defense = 10;

		public string Name => name;
		public int Level => level;
		public int MaxHP => maxHP;
		public int MaxMP => maxMP;
		public int Attack => attack;
		public int Defense => defense;

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

		public CharacterBuilder SetDefense(int defense)
		{
			this.defense = defense;
			return this;
		}

		public Character Build()
		{
			return new Character(this);
		}
	}
}