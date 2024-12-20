using Godot;
using System;
using System.Net.NetworkInformation;

public partial class Global : Node
{
  private static int HealthDeclare = 40;
  public static int Stage = 0;

  public static void IncrementStage(){
	Stage++;
  }

  public static void ResetStage(){
	Stage = 0;
  }

  public static int getStage(){
	return Stage;
  }

  public static int StartingHealth = HealthDeclare;

  public static void updateHealth(int health){
	StartingHealth = health;
  }

  public static int getHealth(){
	return StartingHealth;
  }

  public static void resetHealth(){
	StartingHealth = HealthDeclare;
  }
	public static string EnemyName = "Villain";
	
	public static int EventBuff = 1;
	
}
