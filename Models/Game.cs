namespace Dungeon.Models
{
	class Game
	{
		Player player;
		List<Room> dungeon;
		int currentRoomIndex;

		public Game()
		{
			player = new Player();
			dungeon = CreateDungeon();
			currentRoomIndex = 0;
		}

		public void Start()
		{
			Console.WriteLine("Добро пожаловать в подземелье!");
			while (true)
			{
				Console.Clear();
				Room currentRoom = dungeon[currentRoomIndex];
				currentRoom.Enter(player);

				if (player.Health <= 0)
				{
					Console.WriteLine("Вы погибли! Игра окончена.");
					break;
				}

				if (currentRoomIndex == dungeon.Count - 1)
				{
					Console.WriteLine("Поздравляем! Вы победили босса и прошли подземелье!");
					break;
				}

				Console.WriteLine("1. Перейти в следующую комнату");
				if (currentRoomIndex > 0)
				{
					Console.WriteLine("2. Вернуться в предыдущую комнату");
				}
				Console.Write("Ваш выбор: ");
				string choice = Console.ReadLine();

				if (choice == "1")
				{
					currentRoomIndex++;
				}
				else if (choice == "2" && currentRoomIndex > 0)
				{
					currentRoomIndex--;
				}
				else
				{
					Console.WriteLine("Неверный ввод. Попробуйте снова.");
				}
			}
		}

		private List<Room> CreateDungeon()
		{
			List<Room> rooms = new List<Room>
			{
				new Room("Вы вошли в подземелье."),
				new Room("Вы попали в пустую комнату."),
				new Room("Вы попали в комнату с врагом.", new Enemy(10)),
				new Room("Вы попали в комнату с врагом.", new Enemy(15)),
				new Room("Вы попали в пустую комнату."),
				new Room("Вы нашли фонтан исцеления.", isHealingFountain: true),
				new Room("Вы попали в комнату с врагом.", new Enemy(20)),
				new Room("Вы попали в комнату с боссом.", new Enemy(50)),
				new Room("Вы нашли выход из подземелья!")
			};
			return rooms;
		}
	}
}
