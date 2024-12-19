using Godot;
using System;

public partial class enemy1 : Node
{
	[Export] public int MaxHp = 4;
	public int Hp { get; private set; }

	public override void _Ready()
	{
		Hp = MaxHp;
	}
	public void TakeDamage(int amount)
	{
		
		Hp -= amount;
		Hp = Math.Max(Hp,0);
		
	}


}
