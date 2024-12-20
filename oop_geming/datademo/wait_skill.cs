using Godot;
using System;

public partial class wait_skill : Node
{
	private gameplay _gamewait;
	public override void _Ready()
	{
		
		_gamewait = GetParent().GetNode<gameplay>("BattleUi/Gameplay"); 
	}
	public void RunSkill()
	{
		
		_gamewait.PlayerSkip();
	}

	
}
