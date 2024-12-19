using Godot;
using System.Collections.Generic;

public partial class Room : Resource
{
	// Enum for Room Type
	public enum Type
	{
		UNAVAILABLE,
		FIGHT,
		STORE,
		EVENT
	}

	// Properties
	[Export]
	public Type RoomType { get; set; }

	// Fight-related properties
   [Export]
	public Godot.Collections.Array<Enemy> Enemies { get; set; } = new Godot.Collections.Array<Enemy>();

	// Store-related properties
	[Export]
	public Godot.Collections.Array<PackedScene> StoreItems { get; set; } = new Godot.Collections.Array<PackedScene>();

	// Event-related properties
	[Export]
	public string EventDescription { get; set; } = "";

	// Utility Methods
	public void AddEnemy(Enemy enemy)
	{
		if (RoomType == Type.FIGHT && Enemies.Count < 2)
			Enemies.Add(enemy);
	}

	public void AddStoreItem(PackedScene item)
	{
		if (RoomType == Type.STORE)
			StoreItems.Add(item);
	}

	public void SetEvent(string description)
	{
		if (RoomType == Type.EVENT)
			EventDescription = description;
	}
}
