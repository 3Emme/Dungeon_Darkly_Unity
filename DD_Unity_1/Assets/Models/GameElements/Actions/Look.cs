using System;
using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public partial class Action
  {
    public static void Look(string target)
    {
      if (target != "")
      {
        Environment current_location = TerminalManager.game.Environments[TerminalManager.game.Players[0].Location];
        foreach (Monster monster in current_location.Monsters)
        {
          if (monster.Name.Contains(target))
          {
            Interpreter.DisplayOutput("Name: "+monster.Name);
            Interpreter.DisplayOutput("Type: "+monster.Type["main"]);
            Interpreter.DisplayOutput("Level: "+monster.Level);
            Interpreter.DisplayOutput("HP: "+monster.HP);
            Interpreter.DisplayOutput("MP: "+monster.MP);
            Interpreter.DisplayOutput("AC: "+monster.BaseAc);
            break;
          }
        }
        foreach (Item item in current_location.Items)
        {
          if (item.Name.Contains(target))
          {
            Interpreter.DisplayOutput("Name: "+item.Name);
            Interpreter.DisplayOutput("Worth: "+item.Worth);
            if (item.Flags.Contains("weapon"))
            {
              Interpreter.DisplayOutput($"Slot: {item.Slot}");
              Interpreter.DisplayOutput($"Attack: {item.Atk[0]}{item.Atk[1]}{item.Atk[2]}");
              Interpreter.DisplayOutput($"Damage: {item.Dam[0]}{item.Dam[1]}");
            }
            if (item.Flags.Contains("armor"))
            {
              Interpreter.DisplayOutput($"Slot: {item.Slot}");
              Interpreter.DisplayOutput($"AC: {item.AcBonus}");
              Interpreter.DisplayOutput($"Type: {item.Type}");
            }
            break;
          }
        }
      }
      else
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
        Interpreter.DisplayOutput("");
        Interpreter.DisplayOutput("");
        Interpreter.DisplayOutput(current_location.Description); // Unity edition
        Interpreter.DisplayOutput("");
        Interpreter.DisplayOutput("");
        
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
}