using Godot;
using System;

using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


using System.Reflection;

public partial class gameplay : Node2D
{
	public player _player;
	public enemy1 _enemy;
	private int turn_number =0;
	private int buff_effect = 0;
	private int buff = 1;
	private bool _isPlayerTurn = true;
	private Node _attackbutton;
	public int health_player;
	public int health_enemy;
	public skillslot1 _fetchplayerskl1;
	public skillslot2 _fetchplayerskl2;
	public skillslot3 _fetchplayerskl3;
	public skillslot4 _fetchplayerskl4;
	public override void _Ready()
	{
		Node parentnode = GetParent();
		 _attackbutton = parentnode.GetNode("Attack");
		// Initialize player and enemy nodes
		_player = GetNode<player>("Player"); // Adjust path as needed
		_enemy = GetNode<enemy1>("Enemy1");   // Adjust path as needed

		_player.MaxHp = Global.getHealth();
		//Generate random enemy
		Enemy loadedEnemy = GetRandomEnemy();
		_enemy.Hp = loadedEnemy.Health;
		_enemy.Damage = loadedEnemy.Damage;
		Global.EnemyName = loadedEnemy.Name;
		GD.Print("Enemy Health: " + loadedEnemy.Health);
		GD.Print("Enemy DAmage: " + loadedEnemy.Damage);
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
	public skillslot4 PlayerSlot4()
	{
		_fetchplayerskl4= _player.FetchSkillSlot4();
		return _fetchplayerskl4;
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
		
		GD.Print($"Player attacks and dealt {amount} amount!");
		_enemy.TakeDamage(amount*buff*Global.EventBuff); // Player attacks the enemy with 2 damage
		
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
	public void PlayerPoisoned()
	{
		if (!_isPlayerTurn) return; 
		GD.Print("Player got poisoned!");
		_player.TakeDamage(1);
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
	if (IsEnemyDefeated())
	{
		HandleVictory();
		return;
	}

	if (IsPlayerDefeated())
	{
		HandleDefeat();
		return;
	}

	TogglePlayerTurn();
	StartTurn();
}

private bool IsEnemyDefeated()
{
	return _enemy.Hp <= 0;
}

private bool IsPlayerDefeated()
{
	return _player.Hp <= 0;
}

private void HandleVictory()
{
	Global.IncrementStage();
	GD.Print($"Stage: {Global.getStage()}");
	GD.Print("You win!");
	GD.Print($"Your Health: {_player.Hp}");
	Global.updateHealth(_player.Hp);
	LoadScene("res://map/map.tscn");
}

private void HandleDefeat()
{
	GD.Print("You lose!");
	LoadScene("res://ui_general/gameover.tscn");
}

private void TogglePlayerTurn()
{
	_isPlayerTurn = !_isPlayerTurn;
}

private void LoadScene(string scenePath)
{
	GetTree().ChangeSceneToFile(scenePath);
}


	private void StartTurn()
	{
		// Trigger the attack for the current turn
		if (_isPlayerTurn)
		{
			health_player = _player.Hp;
			health_enemy = _enemy.Hp;
			
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
