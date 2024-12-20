using Godot;
using System;

public partial class defend_skill : Node2D
{
	private gameplay _gamedefend;
	public override void _Ready()
	{
		
		_gamedefend = GetParent().GetNode<gameplay>("BattleUi/Gameplay"); 
	}
	public void RunSkill()
	{
		
		_gamedefend.PlayerGuard(1);
	}
}
