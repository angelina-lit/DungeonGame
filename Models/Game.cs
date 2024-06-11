namespace Dungeon.Models
{
	class Game
	{
		private Player player;
		private List<Room> dungeons;
		private int currentRoomIndex;

		private string enterDungeonMessage = "Вы вошли в подземелье.";
		private string emptyRoomMessage = "Вы попали в пустую комнату.";
		private string enemyInTheRoomMessage = "Вы попали в комнату с врагом.";
		private string bossInTheRoomMessage = "Вы попали в комнату с боссом.";
		private string fountainOfHealingMessage = "Вы нашли фонтан исцеления.";
		private string exitDungeonMessage = "Вы нашли выход из подземелья!";

		public Game()
		{
			player = new Player();
			dungeons = CreateDungeon();
			currentRoomIndex = 0;
		}

		public void Start()
		{
			Console.WriteLine("Добро пожаловать в подземелье!");
			while (true)
			{
				Console.Clear();
				Room currentRoom = dungeons[currentRoomIndex];
				currentRoom.Enter(player);

				if (IsGameOver())
				{
					break;
				}

				if (IsCheckWin())
				{
					break;
				}

				EnterRoom();
			}
		}

		private bool IsCheckWin()
		{
			if (currentRoomIndex == dungeons.Count - 1)
			{
				Console.WriteLine("Поздравляем! Вы победили босса и прошли подземелье!");
				return true;
			}
			return false;
		}

		private bool IsGameOver()
		{
			if (player.Health <= 0)
			{
				Console.WriteLine("Вы погибли! Игра окончена.");
				return true;
			}
			return false;
		}

		private void EnterRoom()
		{
			Console.WriteLine("1. Перейти в следующую комнату");

			if (currentRoomIndex > 0)
				Console.WriteLine("2. Вернуться в предыдущую комнату");

			Console.Write("Ваш выбор: ");
			string choice = Console.ReadLine();

			if (choice == "1")
				currentRoomIndex++;
			else if (choice == "2" && currentRoomIndex > 0)
				currentRoomIndex--;
			else
				Console.WriteLine("Неверный ввод. Попробуйте снова.");
		}

		private List<Room> CreateDungeon()
		{
			List<Room> rooms = new List<Room>
			{
				new Room(enterDungeonMessage),
				new Room(emptyRoomMessage),
				new FightingRoom(enemyInTheRoomMessage, new Character(10, 10)),
				new FightingRoom(enemyInTheRoomMessage, new Character(15, 10)),
				new Room(emptyRoomMessage),
				new FountainRoom(fountainOfHealingMessage, isHealingFountain: true),
				new FightingRoom(enemyInTheRoomMessage, new Character(20, 10)),
				new FightingRoom(bossInTheRoomMessage, new Character(50, 10)),
				new Room(exitDungeonMessage)
			};
			return rooms;
		}
	}
}
