using Godot;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public partial class GenerateRoom : Node {
  private Godot.Collections.Dictionary<Room.Type, int> RoomTypeWeights = new Godot.Collections.Dictionary<Room.Type, int>
  {
	{ Room.Type.FIGHT, 50 },  // Higher weight means higher chance
	{ Room.Type.STORE, 30 },
	{ Room.Type.EVENT, 20 }
  };

  public override void _Ready(){
	var rooms = GenerateRooms();

	foreach (var room in rooms)
	  {
		GD.Print("Room Type: " + room.RoomType);
		switch (room.RoomType)
		{
	  	case Room.Type.FIGHT:
	  	  GD.Print("Enemies: " + room.Enemies.Count);
		
	  	  break;
	  	case Room.Type.STORE:
	  	  GD.Print("Store Items: " + room.StoreItems.Count);
	  	  break;
	  	case Room.Type.EVENT:
	  	  GD.Print("Event: " + room.EventDescription);
	  	  break;
		}
	  }
	Node parentNode = GetParent();
	var gameState = parentNode.GetNode<GameState>("GameState");
	gameState.Rooms = rooms;
	
  }

  private RandomNumberGenerator random = new RandomNumberGenerator();

  private Room.Type GetWeightedRoomType(){
	random.Randomize();
	int totalWeight = 0;
	foreach (var weight in RoomTypeWeights.Values)
	{
	  totalWeight += weight;
	}
	int randomValue = random.RandiRange(0, totalWeight-1);
	int currentWeight = 0;

	foreach (var entry in RoomTypeWeights)
	{
	  currentWeight += entry.Value;
	  if (randomValue < currentWeight)
	  {
		return entry.Key;
	  }
	}
	return Room.Type.UNAVAILABLE;
  }

  private Enemy GetRandomEnemy(){
	using (var context = new GameContext())
	{
	  var enemies = context.Enemies.ToList();
	  var randomIndex = random.RandiRange(0, enemies.Count - 1);
	  return enemies[randomIndex];
	}
  }

  private PackedScene GetRandomStoreItem(){
	// Placeholder for now
	return null;
  }

  private string GetRandomEvent(){
	var events = new string[]
	{
	  "You find a chest with a shiny sword inside!",
	  "You find a chest with a shiny shield inside!",
	  "You find a chest with a shiny potion inside!"
	};
	var randomIndex = random.RandiRange(0, events.Length - 1);
	return events[randomIndex];
  }

  private Room GenerateRandomRoom(){
	Room room = new Room();
	room.RoomType = GetWeightedRoomType();

	switch (room.RoomType)
	{
	  case Room.Type.FIGHT:
		room.AddEnemy(GetRandomEnemy());
		room.AddEnemy(GetRandomEnemy());
		break;
	  case Room.Type.STORE:
		room.AddStoreItem(GetRandomStoreItem());
		break;
	  case Room.Type.EVENT:
		room.SetEvent(GetRandomEvent());
		break;
	}
	return room;
  }

  public List<Room> GenerateRooms(){
	 var rooms = new List<Room>();
		for (int i = 0; i < 3; i++)
		{
			rooms.Add(GenerateRandomRoom());
		}
		return rooms;
  }
}
