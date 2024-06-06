namespace Dungeon.Models;

class Room
{
	public string Description { get; private set; }
	public Enemy Enemy { get; private set; }
	public bool IsHealingFountain { get; private set; }

	public Room(string description, Enemy enemy = null, bool isHealingFountain = false)
	{
		Description = description;
		Enemy = enemy;
		IsHealingFountain = isHealingFountain;
	}

	public void Enter(Player player)
	{
		Console.WriteLine(Description);
		if (Enemy != null)
		{
			Fight(player);
		}

		if (IsHealingFountain)
		{
			player.Heal(30);
			Console.WriteLine("Вы исцелились на 30 единиц здоровья.");
		}

		Console.WriteLine($"Ваше здоровье: {player.Health}/{player.MaxHealth}");
	}

	private void Fight(Player player)
	{
		Console.WriteLine("Враг атакует!");

		while (player.Health > 0 && Enemy.Health > 0)
		{
			Console.WriteLine($"Ваше здоровье: {player.Health}");
			Console.WriteLine($"Здоровье врага: {Enemy.Health}");

			Console.WriteLine("1. Атаковать");
			Console.WriteLine("2. Бежать");

			string choice = Console.ReadLine();

			if (choice == "1")
			{
				player.TakeDamage(Enemy.Attack());
				Enemy.TakeDamage(10);
			}
			else if (choice == "2")
			{
				Console.WriteLine("Вы убежали от врага!");
				break;
			}
			else
			{
				Console.WriteLine("Неверный ввод. Попробуйте снова.");
			}

			if (Enemy.Health <= 0)
			{
				Console.WriteLine("Вы победили врага и получили награду!");
			}
			else if (player.Health <= 0)
			{
				Console.WriteLine("Вы были побеждены врагом!");
			}
		}
	}
}
