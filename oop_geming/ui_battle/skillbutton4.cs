using Godot;
using System;

public partial class skillbutton4 : Button
{
	public skillslot4 _skillrun4;
	public gameplay _fetchskill4;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		Node parentnode = GetParent();
		_fetchskill4 = parentnode.GetNode<gameplay>("Gameplay");
		_skillrun4 = _fetchskill4.PlayerSlot4();
		this.Pressed += OnPressed;
	}
	private void OnPressed()
	{
		
		this.Text = _skillrun4.skillname4;
		_skillrun4.RunSkill4();
		
	}


}
