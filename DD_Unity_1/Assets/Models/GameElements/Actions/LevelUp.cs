using System.Collections.Generic;
using UnityEngine;

namespace Dungeon_Darkly
{
  public partial class Action
  {
    public static void LevelUp()
    {
      Player player = TerminalManager.game.Players[0];
      Interpreter.DisplayOutput(" *** YOU LEVELED UP! ***");
      player.Level += 1;
      Interpreter.DisplayOutput($"You are now level {player.Level}");
    } 
  }
} 