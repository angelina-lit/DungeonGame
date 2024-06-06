namespace Dungeon.Models
{
	class Enemy
	{
		public int Health { get; private set; }

		public Enemy(int health)
		{
			Health = health;
		}

		public int Attack()
		{
			return 10;
		}

		public void TakeDamage(int damage)
		{
			Health -= damage;
			if (Health < 0)
			{
				Health = 0;
			}
		}
	}
}
