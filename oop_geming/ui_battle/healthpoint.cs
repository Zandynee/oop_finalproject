using Godot;
using System;

public partial class healthpoint : Label
{
	// Called when the node enters the scene tree for the first time.
	private gameplay _healthcek;
	public override void _Ready()
	{
		_healthcek = GetParent().GetNode<gameplay>("Gameplay");	
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Text = $"Health point : {_healthcek.health_player}";
	}
}
