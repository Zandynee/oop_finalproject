using Godot;
using System;

public partial class fight : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
			// Access the GameState singleton
		Node parentNode = GetParent();
		var gameState = parentNode.GetNode<GameState>("GameState");
		// Retrieve the rooms and process them
		if (gameState.Rooms.Count == 0)
		{
			GD.Print("No rooms found in GameState.");
			return;
		}

		GD.Print("Processing received rooms:");
		foreach (var room in gameState.Rooms)
		{
			GD.Print($"Room Type: {room.RoomType}");
		}
	 
	this.Pressed += FightPressed;
	
	
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void FightPressed()
	{
	GetTree().ChangeSceneToFile("res://ui_battle/battle_ui.tscn");
	}
	
}
