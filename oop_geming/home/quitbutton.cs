using Godot;
using System;

public partial class quitbutton : Button
{
	public override void _Ready()
	{
		this.Pressed += ButtonPressed;
	}
	private void ButtonPressed()
	{
		GetTree().Quit();
	}
	
}
