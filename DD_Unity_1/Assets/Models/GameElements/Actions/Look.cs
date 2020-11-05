using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dungeon_Darkly
{
  public partial class Action
  {
    public static void Look(string target)
    {
      Player player = TerminalManager.game.Players[0];
      Environment current_location = TerminalManager.game.Environments[player.Location];
      bool foundTarget = false;
      if (target != "")
      {
        foreach (Monster monster in current_location.Monsters)
        {
          if (monster.Name.ToLower().Contains(target))
          {
            Interpreter.DisplayOutput("[+] You examine the monster closely...");
            Interpreter.DisplayOutput("Name: "+monster.Name);
            Interpreter.DisplayOutput("Type: "+monster.Type["main"]);
            Interpreter.DisplayOutput("");
            Interpreter.DisplayOutput("Description: "+monster.Description);
            Interpreter.DisplayOutput("");
            Interpreter.DisplayOutput("Level: "+monster.Level);
            Interpreter.DisplayOutput("HP: "+monster.HP);
            Interpreter.DisplayOutput("MP: "+monster.MP);
            Interpreter.DisplayOutput("AC: "+monster.BaseAc);
            foundTarget = true;
            return;
          }
        }
        foreach (Item item in current_location.Items)
        {
          if (item.Name.ToLower().Contains(target))
          {
            Interpreter.DisplayOutput("[+] You examine the item in the room closely...");
            Interpreter.DisplayOutput("Name: "+item.Name);
            Interpreter.DisplayOutput("");
            Interpreter.DisplayOutput("Description: "+item.Description);
            Interpreter.DisplayOutput("");
            Interpreter.DisplayOutput("Worth: "+item.Worth+" gold");
            if (item.Flags.Contains("weapon"))
            {
              Interpreter.DisplayOutput($"Slot: {item.Slot}");
              Interpreter.DisplayOutput($"Attack: {item.Atk[0]} +{item.Atk[1]}");
              Interpreter.DisplayOutput($"Damage: {item.Dam[0]}{item.Dam[1]}{item.Dam[2]}");
            }
            if (item.Flags.Contains("armor"))
            {
              Interpreter.DisplayOutput($"Slot: {item.Slot}");
              Interpreter.DisplayOutput($"AC: +{item.AcBonus}");
              Interpreter.DisplayOutput($"Type: {item.Type}");
            }
            if (item.Flags.Contains("consume on use"))
            {
              Interpreter.DisplayOutput($"{item.Action[0]} {item.Action[1]} for {item.Action[2]}{item.Action[3]}{item.Action[4]}+{item.Action[5]}");              
            }
            if (item.Flags.Contains("container") && item.Contents.Count > 0)
            {
              Interpreter.DisplayOutput("Contents:");
              foreach (Item thing in item.Contents)
              {
                Interpreter.DisplayOutput($"-{thing.Name}");
              }
            }
            foundTarget = true;
            return;
          }
        }
        foreach (Item item in player.Inv)
        {
          if (item.Name.ToLower().Contains(target))
          {
            Interpreter.DisplayOutput("[+] You examine the item in your inventory closely...");
            Interpreter.DisplayOutput("Name: "+item.Name);
            Interpreter.DisplayOutput("");
            Interpreter.DisplayOutput("Description: "+item.Description);
            Interpreter.DisplayOutput("");
            Interpreter.DisplayOutput("Worth: "+item.Worth+" gold");
            if (item.Flags.Contains("weapon"))
            {
              Interpreter.DisplayOutput($"Slot: {item.Slot}");
              Interpreter.DisplayOutput($"Attack: {item.Atk[0]} +{item.Atk[1]}");
              Interpreter.DisplayOutput($"Damage: {item.Dam[0]}{item.Dam[1]}{item.Dam[2]}");
            }
            if (item.Flags.Contains("armor"))
            {
              Interpreter.DisplayOutput($"Slot: {item.Slot}");
              Interpreter.DisplayOutput($"AC: {item.AcBonus}");
              Interpreter.DisplayOutput($"Type: {item.Type}");
            }
            if (item.Flags.Contains("consume on use"))
            {
              Interpreter.DisplayOutput($"{item.Action[0]} {item.Action[1]} for {item.Action[2]}{item.Action[3]}{item.Action[4]}+{item.Action[5]}");              
            }
            if (item.Flags.Contains("container") && item.Contents.Count > 0)
            {
              Interpreter.DisplayOutput("Contents:");
              foreach (Item thing in item.Contents)
              {
                Interpreter.DisplayOutput($"-{thing.Name}");
              }
            }
            foundTarget = true;
            return;
          }
        }
        if (foundTarget == false)
        {
          Interpreter.DisplayOutput($"Can't find {target}");
          return;
        }
      }
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
      // Player player = TerminalManager.game.Players[0];
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
        Interpreter.DisplayOutput("Items in the room:");
        foreach (Item item in current_location.Items)
        {
          Interpreter.DisplayOutput($"-{item.Name}");
        }
      }

      //  DISPLAY MONSTERS
      if (current_location.Monsters.Count > 0)
      {
        Interpreter.DisplayOutput($"Monster in the room:");
        foreach (Monster monster in current_location.Monsters)
        {
          Interpreter.DisplayOutput($"-{current_location.Monsters[0].Name}");
        }
      }

    }
  }
}