using Godot;
using System;

public partial class poison_skill : Node
{
	private gameplay _gamepoison;
	public override void _Ready()
	{
		
		_gamepoison = GetParent().GetNode<gameplay>("BattleUi/Gameplay"); 
	}
	public void RunSkill()
	{
		
		_gamepoison.PlayerPoisoned();
	}

	
}
