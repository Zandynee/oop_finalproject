using Godot;
using System;

public partial class skip : Button

{
	private gameplay _gameskip;  // Reference to the gameplay class

	public override void _Ready()
	{
		// Get the parent node and cast it to the correct type
		Node parentNode = GetParent();
		_gameskip = parentNode.GetNode<gameplay>("Gameplay");  // Get the "Gameplay" node

		// Connect the button press signal to the OnPressed method
		this.Pressed += OnPressed;
	}

	private void OnPressed()
	{
		// Call the PlayerAttack method on the gameplay instance
		_gameskip.PlayerSkip();
	}
}
