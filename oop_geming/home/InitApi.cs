using Godot;
using System;
using LeaderboardAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;

public partial class InitApi : Node
{

  public override void _Ready()
  {
	StartApi();
  }

}
