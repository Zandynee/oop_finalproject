using Godot;
using System;

public partial class namenemy : Label
{
	private gameplay namy;
	public override void _Ready()
	{
		namy = GetParent().GetNode<gameplay>("Gameplay");
	}
	public override void _Process(double delta)
	{
		Text = $"{Global.EnemyName}";
	}
}
