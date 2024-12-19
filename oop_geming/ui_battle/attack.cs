using Godot;
using System;

public partial class attack : Button
{
	private gameplay _gameattack;  // Reference to the gameplay class

	public override void _Ready()
	{
		// Get the parent node and cast it to the correct type
		Node parentNode = GetParent();
		_gameattack = parentNode.GetNode<gameplay>("Gameplay");  // Get the "Gameplay" node

		// Connect the button press signal to the OnPressed method
		this.Pressed += OnPressed;
	}

	private void OnPressed()
	{
		// Call the PlayerAttack method on the gameplay instance
		_gameattack.PlayerAttack();
	}
}
