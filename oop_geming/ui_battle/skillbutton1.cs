using Godot;
using System;

public partial class skillbutton1 : Button
{
	public skillslot1 _skillrun1;
	public gameplay _fetchskill1;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		Node parentnode = GetParent();
		_fetchskill1 = parentnode.GetNode<gameplay>("Gameplay");
		_skillrun1 = _fetchskill1.PlayerSlot1();
		
		this.Pressed += OnPressed;
	}
	private void OnPressed()
	{
		
		this.Text = _skillrun1.skillname1;
		_skillrun1.RunSkill1();
		
	}


}
