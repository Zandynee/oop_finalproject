using Godot;
using System;
using System.Collections.Generic;

public partial class GameState : Node
{
	public List<Room> Rooms { get; set; } = new List<Room>();
	[Export] public Enemy loadedEnemy { get; set; } = new Enemy();
}
