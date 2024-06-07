namespace Dungeon.Models
{
	class Player : Character
	{
		public int MaxHealth { get; set; }
        public int HealthPointsRecieveCount { get; private set; }

		private int healthPointsRecieveCount = 30 ;

		public Player(int maxHealth = 100, int damageReceiveCount = 10) : base(maxHealth, damageReceiveCount)
		{
			MaxHealth = maxHealth;
			Health = MaxHealth;
			HealthPointsRecieveCount = healthPointsRecieveCount;
			DamageReceiveCount = damageReceiveCount;
		}

		public void ReceiveHealthPoints(int healthPoint)
		{
			if (healthPoint <= 0)
				throw new ArgumentException(nameof(healthPoint));

			Health += healthPoint;

			if (Health > MaxHealth)
			{
				Health = MaxHealth;
			}
		}
	}
}
