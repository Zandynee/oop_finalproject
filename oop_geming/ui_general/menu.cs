using Godot;
using System;

public partial class menu : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	this.Pressed += ExitPressed;
	
	
	}
	public void ExitPressed()
	{
	GetTree().ChangeSceneToFile("res://home/home.tscn");
	
	}
	
}
