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
      // Display.output(this.environments[this.players[0].location].description);
      Interpreter.DisplayOutput(TerminalManager.game.Environments[player.Location].Description); // Unity edition
      // return this.Environments[0].Description;
      if (TerminalManager.game.Environments[player.Location].Items.Count > 0)
      {
        // Display.output(`Items in the room:`);
        Interpreter.DisplayOutput("Items in the room:");
        foreach (Item item in TerminalManager.game.Environments[player.Location].Items)
        {
          // Display.output(`${item.name}`);
          Interpreter.DisplayOutput($"{item.Name}");
        }
      }
      if (TerminalManager.game.Environments[player.Location].Monsters.Count > 0)
      { // TerminalManager.game ONLY DISPLAYS ONE MONSTER
        // Display.output(`Monster in the room: <span class="red">${TerminalManager.game.environments[TerminalManager.game.players[0].location].monsters[0].name}</span>`);
        Interpreter.DisplayOutput($"Monster in the room: {TerminalManager.game.Environments[player.Location].Monsters[0].Name}");
      }
    }
  }
}