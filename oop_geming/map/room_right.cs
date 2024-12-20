using Godot;
using System;

public partial class room_right : Button
{
      private Room room;

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
      room = gameState.Rooms[2];

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
          GetTree().ChangeSceneToFile("res://ui_event/event_ui.tscn");
          break;
      }
    }
}