using Godot;
using System;

public partial class UnitTests : Node
{
	public override void _Ready()
	{
		RunTests();
	}

	private void RunTests()
	{
		GD.Print("Running Tests...");

		// Add test cases
		TestAddEnemyToRoom();
		TestRoomEventDescription();

		GD.Print("All Tests Completed.");
	}

	private void Assert(bool condition, string testName)
	{
		if (condition)
		{
			GD.Print($"{testName}: PASSED");
		}
		else
		{
			GD.PrintErr($"{testName}: FAILED");
		}
	}

	private void TestAddEnemyToRoom()
	{
		var room = new Room { RoomType = Room.Type.FIGHT };

		var enemy = new Enemy { Name = "Goblin", Health = 50 };
		room.AddEnemy(enemy);

		Assert(room.Enemies.Count == 1, "TestAddEnemyToRoom");
		Assert(room.Enemies[0] == enemy, "TestAddEnemyToRoom - Enemy Added");
	}

	private void TestRoomEventDescription()
	{
		var room = new Room { RoomType = Room.Type.EVENT };

		room.SetEvent("Mysterious Stranger Appears");
		Assert(room.EventDescription == "Mysterious Stranger Appears", "TestRoomEventDescription");
	}
}
