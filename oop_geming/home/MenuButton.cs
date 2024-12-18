using Godot;
using System;

public partial class MenuButton : Godot.MenuButton
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var button = new Button();
   	button.Text = "Start!";
	button.Pressed += ButtonPressed;
	AddChild(button);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void ButtonPressed(){
	GetTree().ChangeSceneToFile("res://map/map.tscn");
	}
}
