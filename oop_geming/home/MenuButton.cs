using Godot;
using System;

public partial class MenuButton : Godot.MenuButton
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	this.Pressed += ButtonPressed;
	
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.

	public void ButtonPressed(){
	GetTree().ChangeSceneToFile("res://map/map.tscn");
	}
}
