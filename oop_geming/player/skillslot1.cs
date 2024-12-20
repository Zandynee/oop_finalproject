using Godot;
using System;
using System.Reflection;

public partial class skillslot1 : Node
{
	
	public player _idskill1;
	public string skillname1;
	public string path;
	public string root_name;
	private bool readiness;
	public override void _Ready()
	{	
		
		
		
		
		

		
		
	}
	private void AccessSkill1()
	{	
	_idskill1 = GetParent<player>();
		
		path = "res://datademo/skill_"+_idskill1.SkillSlot1()+".tscn";
		GD.Print("ooioiasdasdasdoooi");
		PackedScene sceneskill1 = ResourceLoader.Load<PackedScene>(path);
		
		
		Node instance = sceneskill1.Instantiate();
		GetTree().Root.AddChild(instance);

		
		root_name = instance.Name;
		GD.Print(root_name);
		Type instanceType = instance.GetType();
		
		skillname1 = instanceType.Name;
		GD.Print(skillname1);

// Dynamically call a method or access a property
		MethodInfo methodReady = instanceType.GetMethod("_Ready");
		MethodInfo methodRun = instanceType.GetMethod("RunSkill");

		
		methodReady.Invoke(instance, null);
		methodRun.Invoke(instance, null); // Invoke without parameters

	
	}
	public void RunSkill1()
	{
		AccessSkill1();
	}


}
