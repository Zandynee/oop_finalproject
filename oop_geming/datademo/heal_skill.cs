using Godot;
using System;

public partial class heal_skill : Node
{
	private gameplay _gameheal;
	public override void _Ready()
	{
		
		_gameheal = GetParent().GetNode<gameplay>("BattleUi/Gameplay"); 
	}
	public void RunSkill()
	{
		
		_gameheal.PlayerHealed();
	}

	
}
