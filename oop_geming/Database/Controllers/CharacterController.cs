using Godot;
using System;

public partial class CharacterController : Character {

  public void addCharacter(Character character, GameContext context){
    context.Characters.Add(character);
    context.SaveChanges();
  }

  public void updateCharacter(Character character, GameContext context){
    context.Characters.Update(character);
    context.SaveChanges();
  }

  public void deleteCharacter(Character character, GameContext context){
    context.Characters.Remove(character);
    context.SaveChanges();
  }

  public Character getCharacter(int id, GameContext context){
    return context.Characters.Find(id);
  }

  public Character getCharacter(string name, GameContext context){
    return context.Characters.Where(c => c.Name == name).FirstOrDefault();
  }

  public List<Character> getCharacters(GameContext context){
    return context.Characters.ToList();
  }



}