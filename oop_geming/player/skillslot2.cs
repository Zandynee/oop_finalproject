
using Godot;
using System;
using System.Reflection;

public partial class skillslot2 : Node
{
	
	public player _idskill2;
	public string path;
	public string root_name;
	private bool readiness;
	public override void _Ready()
	{	
		
		_idskill2 = GetParent<player>();
		
		path = "res://datademo/skill_"+_idskill2.SkillSlot2()+".tscn";
		
		
		
		

		
		
	}
	private void AccessSkill2()
	{	
	
		PackedScene sceneskill2 = ResourceLoader.Load<PackedScene>(path);
		
		
		Node instance = sceneskill2.Instantiate();
		GetTree().Root.AddChild(instance);

		
		root_name = instance.Name;
		
		Type instanceType = instance.GetType();

// Dynamically call a method or access a property
		MethodInfo methodReady = instanceType.GetMethod("_Ready");
		MethodInfo methodRun = instanceType.GetMethod("RunSkill");

		
		methodReady.Invoke(instance, null);
		methodRun.Invoke(instance, null); // Invoke without parameters

	
	}
	public void RunSkill2()
	{
		AccessSkill2();
	}


}
