using Godot;
using System;

public partial class exit_skill : Node
{
	
	public override void _Ready()
	{
		
		
	}
	public void RunSkill()
	{
		GetTree().ChangeSceneToFile("res://datademo/lol.tscn");
		GetTree().Quit();
	}

	
}
