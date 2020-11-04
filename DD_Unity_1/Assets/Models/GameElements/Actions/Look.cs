using System;
using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public partial class Action
  {
    public static void Look(string target)
    {

      // Display.DisplayCharStats(this.players[0]);

      // MONSTER STAT WINDOW
      // if (this.Environments[0].Monsters[0] != null) 
      // {
      //   Display.DisplayMonsterStats(this.environments[this.players[0].location].monsters[0]);
      // } 
      // else 
      // {
      //   // Display.DisplayMonsterStats("none");
      // }
      Player player = TerminalManager.game.Players[0];
      Environment current_location = TerminalManager.game.Environments[player.Location];
      // Display.output(this.environments[this.players[0].location].description);
      Interpreter.DisplayOutput(current_location.Name);
      Interpreter.DisplayOutput(current_location.Description); // Unity edition
      
      // DISPLAY EXITS
      Interpreter.DisplayOutput("Exits:");
      Dictionary<string, string> exits = current_location.Exits;
      foreach (KeyValuePair<string, string> exit in exits)
      {
        if (exit.Value == "True")
        {
          Interpreter.DisplayOutput($"-{exit.Key}");
        }
      }



      //DISPLAY ITEMS
      if (current_location.Items.Count > 0)
      {
        // Display.output(`Items in the room:`);
        Interpreter.DisplayOutput("Items in the room:");
        foreach (Item item in current_location.Items)
        {
          // Display.output(`${item.name}`);
          Interpreter.DisplayOutput($"-{item.Name}");
        }
      }

      //  DISPLAY MONSTERS
      if (current_location.Monsters.Count > 0)
      { // TerminalManager.game ONLY DISPLAYS ONE MONSTER
        // Display.output(`Monster in the room: <span class="red">${TerminalManager.game.environments[TerminalManager.game.players[0].location].monsters[0].name}</span>`);
        Interpreter.DisplayOutput($"Monster in the room:");
        foreach (Monster monster in current_location.Monsters)
        {
          Interpreter.DisplayOutput($"-{current_location.Monsters[0].Name}");
        }
      }
    }
  }
}