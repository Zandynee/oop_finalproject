using Godot;
using System;
using System.Reflection;

public partial class player : Node
{
	

	public int MaxHp = Global.getHealth();
	public int Defend = 0;
	public int Buff = 1;
	public int Attack = 1;
	public int fights = 0;

	// Skilldex fields
	public string skilldex1;
	public string skilldex2;
	public string skilldex3;
	public string skilldex4;

	// Example skill pool
	private string[] skillPool = { "skl1", "skl2", "skl3","skl4", "skl5" };

	public skillslot1 _fetchskill1;
	public skillslot2 _fetchskill2;
	public skillslot3 _fetchskill3;
	public skillslot4 _fetchskill4;
	public int Hp { get; set; }

	public override void _Ready()
	{
		// Randomize skilldex slots
		RandomizeSkilldex();

		// Load the player database scene and set HP
		

		
		Hp = MaxHp;

		Ready1();
	}

	private void RandomizeSkilldex()
	{
		Random random = new Random();

		// Shuffle or select random skills from the skill pool
		skilldex1 = skillPool[random.Next(skillPool.Length)];
		skilldex2 = skillPool[random.Next(skillPool.Length)];
		skilldex3 = skillPool[random.Next(skillPool.Length)];
		skilldex4 = skillPool[random.Next(skillPool.Length)];

		// Debug: Print the randomized skills
		
		GD.Print($"Skilldex Randomized: {skilldex1}, {skilldex2}, {skilldex3}, {skilldex4}");
	}

	public void Ready1()
	{
	}

	public void TakeDamage(int amount)
	{
		int absol = (amount - Defend);
		if (absol <= 0)
			absol = 0;
		Hp = Hp - absol;

		Hp = Math.Max(Hp, 0);
	}

	public int TakeGuard(int amount)
	{
		Defend = amount * Buff;
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
		if (buff_duration == 0)
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
	public string SkillSlot4()
	{
		return skilldex4;
	}

	public skillslot4 FetchSkillSlot4()
	{
		_fetchskill4 = GetNode<skillslot4>("Skillslot4");
		return _fetchskill4;
	}
}
