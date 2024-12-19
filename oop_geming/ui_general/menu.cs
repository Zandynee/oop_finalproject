using Godot;
using System;

public partial class menu : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	var button = new Button();
   	button.Text = "";
	button.Pressed += ExitPressed;
	AddChild(button);
	
	}
	public void ExitPressed()
	{
	GetTree().ChangeSceneToFile("res://home/home.tscn");
	}
	
}
