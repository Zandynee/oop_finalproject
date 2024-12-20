using Godot;
using System;

public partial class eventbutton : Button
{
	
	public player _healbuff;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		Node parentnode = GetParent();
		_healbuff = parentnode.GetNode<player>("Player");
		
		
		this.Pressed += OnPressed;
	}
	private void OnPressed()
	{
		
		var _hp = Global.getHealth();
		_hp *= 5;
		Global.updateHealth(_hp);
		
		GetTree().ChangeSceneToFile("res://map/map.tscn");
		
		
	}


}
