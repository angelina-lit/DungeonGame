namespace Dungeon.Models
{
	class Player
	{
		public int Health { get; private set; }
		public int MaxHealth { get; private set; }

		public Player()
		{
			MaxHealth = 100;
			Health = MaxHealth;
		}

		public void TakeDamage(int damage)
		{
			Health -= damage;
			if (Health < 0)
			{
				Health = 0;
			}
		}

		public void Heal(int amount)
		{
			Health += amount;
			if (Health > MaxHealth)
			{
				Health = MaxHealth;
			}
		}
	}
}
