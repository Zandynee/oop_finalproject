using Godot;
using System;

public partial class gameplay : Node2D
{
	private player _player;
	private enemy1 _enemy;
	private int turn_number =0;
	private int buff_effect = 0;
	private int buff = 1;
	private bool _isPlayerTurn = true;
	private Node _attackbutton;
	public override void _Ready()
	{
		Node parentnode = GetParent();
		 _attackbutton = parentnode.GetNode("Attack");
		// Initialize player and enemy nodes
		_player = GetNode<player>("Player"); // Adjust path as needed
		_enemy = GetNode<enemy1>("Enemy1");   // Adjust path as needed
		
		
		StartTurn();
	}
	

	public void PlayerBuff(int amount)
	{
	if (!_isPlayerTurn) return;
	
	buff = _player.TakeBuff(amount);
	buff_effect+=2;
	CheckGameState(); 
		
	}
	public void PlayerAttack(int amount)
	{
		if (!_isPlayerTurn) return; // Ensure player attacks only on their turn
		
		GD.Print("Player attacks!");
		_enemy.TakeDamage(amount*buff); // Player attacks the enemy with 2 damage
		
		CheckGameState(); // Check if the game is over
	}
	public void PlayerGuard(int amount)
	{
		if (!_isPlayerTurn) return; 
		GD.Print("Player guards!");
		_player.TakeGuard(amount*buff); 
		CheckGameState(); 
	}
	public void PlayerSkip()
	{
		if (!_isPlayerTurn) return; 
		GD.Print("Skipped a turn..");
		CheckGameState();
	}
	
	

	public void EnemyTurn()
	{
		if (_isPlayerTurn) return; // Ensure the enemy attacks only on their turn
		
		GD.Print("Enemy attacks!");
		_player.TakeDamage(1); // Enemy attacks the player with 1 damage
		buff_effect-=1;
		_player.StatReset(buff_effect);
		buff_effect = Math.Max(buff_effect, 0); 
		CheckGameState(); // Check if the game is over
	}

	private void CheckGameState()
	{
		
		// Check if either the player or the enemy is dead
		if (_enemy.Hp <= 0)
		{
			GD.Print("You win!");
			GetTree().ChangeSceneToFile("res://map/map.tscn");
			return;
		}

		if (_player.Hp <= 0)
		{
			GD.Print("You lose!");
			GetTree().ChangeSceneToFile("res://home/home.tscn");
			return;
		}

		
		_isPlayerTurn = !_isPlayerTurn;
		StartTurn();
		
	}

	private void StartTurn()
	{
		// Trigger the attack for the current turn
		if (_isPlayerTurn)
		{
			turn_number++;
			GD.Print("Turn Number:", turn_number);
			GD.Print("Your Health:", _player.Hp);
		}
		else
		{
			GD.Print("Enemy Health:", _enemy.Hp);
			EnemyTurn();
		}
	}
}
