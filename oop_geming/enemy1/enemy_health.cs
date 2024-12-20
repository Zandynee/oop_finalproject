using Godot;
using System;

public partial class enemy_health : Label
{
	private gameplay _healthchek;
	public override void _Ready()
	{
		_healthchek = GetParent().GetNode<gameplay>("Gameplay");
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Text = $"{_healthchek.health_enemy}";
	}
}
