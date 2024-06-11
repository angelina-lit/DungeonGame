namespace Dungeon.Models
{
	class FightingRoom : Room
	{
		public Character Character { get; set; }

		public FightingRoom(string description, Character сharacter = null) : base(description)
		{
			Character = сharacter;
		}

		public override void Enter(Player player)
		{
			base.Enter(player);

			Fight(player);
			Console.WriteLine($"Ваше здоровье: {player.Health}/{player.MaxHealth}");
		}

		private void Fight(Player player)
		{
			Console.WriteLine("Враг атакует!");

			while (player.Health > 0 || Character.Health > 0)
			{
				Console.WriteLine($"Ваше здоровье: {player.Health}");
				Console.WriteLine($"Здоровье врага: {Character.Health}");

				FightOrFlight(player);

				if (IsPlayerWin(player))
					break;
			}
		}

		private void FightOrFlight(Player player)
		{
			Console.WriteLine("1. Атаковать");
			Console.WriteLine("2. Бежать");

			string choice = Console.ReadLine();

			switch (choice)
			{
				case "1":
					player.ReceiveDamage(player.DamageReceiveCount);
					Character.ReceiveDamage(Character.DamageReceiveCount);
					break;
				case "2":
					Console.WriteLine("Вы убежали от врага!");
					break;
				default:
					Console.WriteLine("Неверный ввод. Попробуйте снова.");
					break;
			}
		}

		private bool IsPlayerWin(Player player)
		{
			if (Character.Health <= 0)
			{
				Console.WriteLine("Вы победили врага и получили награду!");
				return true;
			}
			else if (player.Health <= 0)
			{
				Console.WriteLine("Вы были побеждены врагом!");
				return true;
			}
			return false;
		}
	}
}
