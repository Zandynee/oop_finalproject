using Godot;
using System;

public partial class skill1 : Button
{
	private gameplay _gamedefend; 
	public override void _Ready()
	{
		Node parentNode = GetParent();
		_gamedefend = parentNode.GetNode<gameplay>("Gameplay");  // Get the "Gameplay" node

		// Connect the button press signal to the OnPressed method
		this.Pressed += OnPressed;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	private void OnPressed()
	{
		_gamedefend.PlayerGuard(1);
	}
}
