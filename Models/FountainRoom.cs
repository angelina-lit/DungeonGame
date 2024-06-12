namespace Dungeon.Models
{
	class FountainRoom : Room
	{
		public FountainRoom(string description) : base(description)
		{
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
