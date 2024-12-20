using Godot;
using System;

public partial class attack_skill : Node
{
	private gameplay _gameattack;
	public override void _Ready()
	{
		
		_gameattack = GetParent().GetNode<gameplay>("BattleUi/Gameplay"); 
	}
	public void RunSkill()
	{
		
		_gameattack.PlayerAttack(1);
	}

	
}
