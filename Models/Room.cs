namespace Dungeon.Models;

class Room
{
	public string Description { get; set; }

	public Room(string description)
	{
		Description = description;
	}

	public virtual void Enter(Player player)
	{
		Console.WriteLine(Description);
	}
}
