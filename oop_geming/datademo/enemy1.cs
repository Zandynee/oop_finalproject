using Godot;
using System;

public partial class enemy1 : Node
{
	[Export] public int MaxHp = 4;

	[Export] public int Damage = 1;
	[Export] public string enemyName = "Enemy";
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
