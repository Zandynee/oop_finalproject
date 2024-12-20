using Godot;
using System;

public partial class room_centre : Button
{      private Room room;

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
	  room = gameState.Rooms[1];

	  this.Text = room.RoomType.ToString();

	  if (room.RoomType == Room.Type.FIGHT) {
		  GD.Print("Enemies: " + room.Enemies[0].Name);
		  gameState.loadedEnemy = room.Enemies[0];
	  }
	  this.Pressed += RoomPressed;

	}

	public void RoomPressed()
	{
	  switch (room.RoomType)
	  {
		case Room.Type.FIGHT:
		  //TODO: Export enemies
		  GetTree().ChangeSceneToFile("res://ui_battle/battle_ui.tscn");
		  break;
		case Room.Type.STORE:
		  GetTree().ChangeSceneToFile("res://ui_store/store_ui.tscn");
		  break;
		case Room.Type.EVENT:
		  GetTree().ChangeSceneToFile("res://datademo/event.tscn");
		  break;
	  }
	}

}
