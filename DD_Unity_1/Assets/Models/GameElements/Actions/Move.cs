using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dungeon_Darkly
{
  public partial class Action
  {
    public static void Move(string direction,int axis,int number)
    {

      // OVER ENCUMBERED CHECK HERE
      
      Player player = TerminalManager.game.Players[0];
      Environment current_location = TerminalManager.game.Environments[player.Location];
      if (current_location.Exits[direction] == "False")
      {
        Interpreter.DisplayOutput($"[-] You can't go {direction}!");
      }
      else if (current_location.Exits[direction] == "True")
      {
        Interpreter.DisplayOutput($"[+] You bravely advance {direction}");
        //AXIS: 0=X, 1=Y, 2=Z
        player.Coordinates[axis] += number;

        // MOVE ACTION        
        for (int i = 0; i < TerminalManager.game.Environments.Count; i++ )
        {
          if (player.Coordinates.SequenceEqual(TerminalManager.game.Environments[i].Coordinates))
          {
            player.Location = i;
            Action.Look("");
          }
        }
      }
    }
  }
}
