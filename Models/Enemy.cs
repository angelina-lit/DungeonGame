namespace Dungeon.Models
{
	class Enemy : Character
	{
		public Enemy(int health, int damageReceiveCount) : base(health, damageReceiveCount)
		{
			Health = health;
			DamageReceiveCount = damageReceiveCount;
		}
	}
}
