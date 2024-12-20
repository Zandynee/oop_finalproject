using Godot;
using System;

public partial class skillbutton2 : Button
{
	public skillslot2 _skillrun2;
	public gameplay _fetchskill2;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		Node parentnode = GetParent();
		_fetchskill2 = parentnode.GetNode<gameplay>("Gameplay");
		_skillrun2 = _fetchskill2.PlayerSlot2();
		this.Pressed += OnPressed;
	}
	private void OnPressed()
	{
		

		_skillrun2.RunSkill2();
		
	}


}
