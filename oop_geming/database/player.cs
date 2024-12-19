using Godot;
using System;

public partial class player : Node
{
	public int MaxHp = 10;
	public int Defend = 0 ;
	public int Hp { get; private set; }
	public override void _Ready()
	{
		Hp = MaxHp;
	}
	public void TakeDamage(int amount)
	{
		int absol = (amount-Defend);
		if (absol <= 0)
			absol = 0;
		Hp = Hp - absol;
		
		Hp = Math.Max(Hp, 0);
	}
	public int TakeGuard(int amount)
	{
		Defend = amount;
		Defend = Math.Max(Defend, 0);
		return Defend;
	}
	public void StatReset()
	{
		TakeGuard(0);
	}
	
	


}
