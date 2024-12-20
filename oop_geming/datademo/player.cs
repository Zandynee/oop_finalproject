using Godot;
using System;

public partial class player : Node
{
	public int MaxHp = 10;
	public int Defend = 0;
	public int Buff = 1;
	public string skilldex1 = "skl1";
	public string skilldex2 = "skl2";
	public string skilldex3 = "skl3";
	public string skilldex4 = "skl4";
	public skillslot1 _fetchskill1;
	public skillslot2 _fetchskill2;
	public skillslot3 _fetchskill3;
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
	public string SkillSlot1()
	{
		return skilldex1;
	}
	public skillslot1 FetchSkillSlot1()
	{
		_fetchskill1 = GetNode<skillslot1>("Skillslot1");
		return _fetchskill1;
	}
	public string SkillSlot2()
	{
		return skilldex2;
	}
	public skillslot2 FetchSkillSlot2()
	{
		_fetchskill2 = GetNode<skillslot2>("Skillslot2");
		return _fetchskill2;
	}
	public string SkillSlot3()
	{
		return skilldex3;
	}
	public skillslot3 FetchSkillSlot3()
	{
		_fetchskill3 = GetNode<skillslot3>("Skillslot3");
		return _fetchskill3;
	}
	
	


}
