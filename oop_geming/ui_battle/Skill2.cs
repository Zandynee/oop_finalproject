using Godot;
using System;

public partial class Skill2 : Button
{
	// Called when the node enters the scene tree for the first time.
	private gameplay _gamebuff;  // Reference to the gameplay class

	public override void _Ready()
	{
		// Get the parent node and cast it to the correct type
		Node parentNode = GetParent();
		_gamebuff = parentNode.GetNode<gameplay>("Gameplay");  // Get the "Gameplay" node

		// Connect the button press signal to the OnPressed method
		this.Pressed += OnPressed;
	}
	private void OnPressed()
	{
		
		_gamebuff.PlayerBuff();
	}

	
}
