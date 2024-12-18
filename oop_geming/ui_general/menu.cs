using Godot;
using System;

public partial class menu : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var button = new Button();
   	button.Text = "Exit";
	button.Pressed += ExitPressed;
	AddChild(button);
	
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	public void ExitPressed()
	{
	GetTree().ChangeSceneToFile("res://home/home.tscn");
	}
	
}
