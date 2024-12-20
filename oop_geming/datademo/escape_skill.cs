using Godot;
using System;

public partial class escape_skill : Node
{
	
	public override void _Ready()
	{
		
		
	}
	public void RunSkill()
	{
		
		GetTree().ChangeSceneToFile("res://map/map.tscn");
		
	}

	
}
