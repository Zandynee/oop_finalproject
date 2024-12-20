using Godot;
using System;

public partial class fight : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	this.Pressed += FightPressed;
	
	
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void FightPressed()
	{
	GetTree().ChangeSceneToFile("res://ui_battle/battle_ui.tscn");
	}
	
}
