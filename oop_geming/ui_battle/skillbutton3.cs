using Godot;
using System;

public partial class skillbutton3 : Button
{
	public skillslot3 _skillrun3;
	public gameplay _fetchskill3;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		Node parentnode = GetParent();
		_fetchskill3 = parentnode.GetNode<gameplay>("Gameplay");
		_skillrun3 = _fetchskill3.PlayerSlot3();
		this.Pressed += OnPressed;
	}
	private void OnPressed()
	{
		

		_skillrun3.RunSkill3();
		
	}


}
