
using Godot;
using System;
using System.Reflection;

public partial class skillslot4 : Node
{
	
	public player _idskill4;
	public string path;
	public string root_name;
	public string skillname4;
	private bool readiness;
	public override void _Ready()
	{	

	}
	private void AccessSkill4()
	{	
		_idskill4 = GetParent<player>();
		
		path = "res://datademo/skill_"+_idskill4.SkillSlot4()+".tscn";
		
		PackedScene sceneskill4 = ResourceLoader.Load<PackedScene>(path);
		
		
		Node instance = sceneskill4.Instantiate();
		GetTree().Root.AddChild(instance);

		
		root_name = instance.Name;
		
		Type instanceType = instance.GetType();
		skillname4 = instanceType.Name;
// Dynamically call a method or access a property
		MethodInfo methodReady = instanceType.GetMethod("_Ready");
		MethodInfo methodRun = instanceType.GetMethod("RunSkill");

		
		methodReady.Invoke(instance, null);
		methodRun.Invoke(instance, null); // Invoke without parameters

	
	}
	public void RunSkill4()
	{
		AccessSkill4();
	}


}
