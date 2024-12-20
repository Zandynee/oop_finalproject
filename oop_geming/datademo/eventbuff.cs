using Godot;
using System;

public partial class eventbuff : Button
{
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		this.Pressed += OnPressed;
	}
	private void OnPressed()
	{
		
		
		
		Global.EventBuff*= 5;
		GetTree().ChangeSceneToFile("res://map/map.tscn");
		
		
	}


}
