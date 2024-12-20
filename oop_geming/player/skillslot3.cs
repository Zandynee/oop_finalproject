
using Godot;
using System;
using System.Reflection;

public partial class skillslot3 : Node
{
	
	public player _idskill3;
	public string path;
	public string root_name;
	public string skillname3;
	private bool readiness;
	public override void _Ready()
	{	

	}
	private void AccessSkill3()
	{	
		_idskill3 = GetParent<player>();
		
		path = "res://datademo/skill_"+_idskill3.SkillSlot3()+".tscn";
		
		PackedScene sceneskill3 = ResourceLoader.Load<PackedScene>(path);
		
		
		Node instance = sceneskill3.Instantiate();
		GetTree().Root.AddChild(instance);

		
		root_name = instance.Name;
		
		Type instanceType = instance.GetType();
		skillname3 = instanceType.Name;
// Dynamically call a method or access a property
		MethodInfo methodReady = instanceType.GetMethod("_Ready");
		MethodInfo methodRun = instanceType.GetMethod("RunSkill");

		
		methodReady.Invoke(instance, null);
		methodRun.Invoke(instance, null); // Invoke without parameters

	
	}
	public void RunSkill3()
	{
		AccessSkill3();
	}


}
