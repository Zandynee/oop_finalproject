using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Database : Control
{
	GameContext context = new GameContext();
	
	public override void _Ready()
	{
		
	}

	public override void _Process(double delta)
	{
	}


	// Enemy
	public Enemy GetEnemy(int id){
		return context.Enemies.Find(id);
	}


}
