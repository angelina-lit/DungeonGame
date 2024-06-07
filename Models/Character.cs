namespace Dungeon.Models
{
	class Character
	{
		public int Health { get; set; }
		public int DamageReceiveCount { get; set; }

		public Character(int health, int damageReceiveCount)
		{
			Health = health;
			DamageReceiveCount = damageReceiveCount;
		}

		public void ReceiveDamage(int damageReceiveCount)
		{
			if (damageReceiveCount <= 0)
				throw new ArgumentException(nameof(damageReceiveCount));

			Health -= damageReceiveCount;
		}
	}
}
