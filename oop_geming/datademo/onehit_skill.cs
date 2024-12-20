using Godot;
using System;

public partial class onehit_skill : Node
{
	private gameplay _gameonehit;
	public override void _Ready()
	{
		
		_gameonehit = GetParent().GetNode<gameplay>("BattleUi/Gameplay"); 
	}
	public void RunSkill()
	{
		
		_gameonehit.PlayerAttack(10000);
	}

	
}
