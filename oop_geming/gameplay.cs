using Godot;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public partial class gameplay : Node2D
{
	private player _player;
	private enemy1 _enemy;
	private int turn_number =0;
	private int buff_effect = 0;
	private int buff = 1;
	private bool _isPlayerTurn = true;
	private Node _attackbutton;
	public skillslot1 _fetchplayerskl1;
	public skillslot2 _fetchplayerskl2;
	public skillslot3 _fetchplayerskl3;
	public override void _Ready()
	{
		Node parentnode = GetParent();
		 _attackbutton = parentnode.GetNode("Attack");
		// Initialize player and enemy nodes
		_player = GetNode<player>("Player"); // Adjust path as needed
		_enemy = GetNode<enemy1>("Enemy1");   // Adjust path as needed

		//Generate random enemy
		Enemy loadedEnemy = GetRandomEnemy();
		_enemy.MaxHp = loadedEnemy.Health;
		_enemy.Damage = loadedEnemy.Damage;

		GD.Print("Enemy Health: " + _enemy.MaxHp);
		GD.Print("Enemy Damage: " + _enemy.Damage);
		
		
		
		StartTurn();
	}
	

	public skillslot1 PlayerSlot1()
	{
		_fetchplayerskl1= _player.FetchSkillSlot1();
		return _fetchplayerskl1;
	}
	public skillslot2 PlayerSlot2()
	{
		_fetchplayerskl2= _player.FetchSkillSlot2();
		return _fetchplayerskl2;
	}
	public skillslot3 PlayerSlot3()
	{
		_fetchplayerskl3= _player.FetchSkillSlot3();
		return _fetchplayerskl3;
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
		_player.TakeDamage(_enemy.Damage); // Enemy attacks the player with 1 damage
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

	private Random _random = new Random();

	public Enemy GetRandomEnemy(){
			using (var context = new GameContext())
			{
				var enemies = context.Enemies.ToList();
				var randomIndex = _random.Next(0, enemies.Count);
				return enemies[randomIndex];
			}
		}
}
