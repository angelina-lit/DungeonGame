namespace Dungeon.Models
{
	class FountainRoom : Room
	{
		public bool IsHealingFountain { get; set; }

		public FountainRoom(string description, bool isHealingFountain = false) : base(description)
		{
			IsHealingFountain = isHealingFountain;
		}

		public override void Enter(Player player)
		{
			base.Enter(player);

			player.ReceiveHealthPoints(player.HealthPointsRecieveCount);
			Console.WriteLine($"Вы исцелились на {player.HealthPointsRecieveCount} единиц здоровья.");

			Console.WriteLine($"Ваше здоровье: {player.Health}/{player.MaxHealth}");
		}
	}
}
