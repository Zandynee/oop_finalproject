using Godot;
using System;

public partial class player : Node
{
	public int MaxHp = 10;
	public int Defend = 0 ;
	public int Buff = 1;
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
		Defend = amount*Buff;
		Defend = Math.Max(Defend, 0);
		return Defend;
	}
	public int TakeBuff(int amount)
	{
		Buff = amount;
		GD.Print("You Buffed!");
		Buff = Math.Max(Buff, 0);
		return Buff;
		
	}
	public void StatReset(int buff_duration)
	{
		TakeGuard(0);
		if(buff_duration ==0)
		{
			GD.Print("Player Buff is gone...");
			TakeBuff(1);
		}
	}
	
	


}
