using Godot;
using System;

public partial class buff_skill : Node2D
{
	private gameplay _gamebuff;
	public override void _Ready()
	{
		
		_gamebuff = GetParent().GetNode<gameplay>("BattleUi/Gameplay"); 
	}
	public void RunSkill()
	{
		
		_gamebuff.PlayerBuff(2);
	}
}
