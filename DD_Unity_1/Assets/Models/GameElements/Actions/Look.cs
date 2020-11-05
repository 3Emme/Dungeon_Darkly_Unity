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
      // LOOK AT MONSTER
      if (target != "")
      {
        foreach (Monster monster in current_location.Monsters)
        {
          if (monster.Name.ToLower().Contains(target))
          {
            Interpreter.DisplayOutputColor("[+] You examine the monster closely...","#FF00E5");
            Interpreter.DisplayOutput("<color=yellow>Name</color>: "+monster.Name);
            Interpreter.DisplayOutput("<color=yellow>Type</color>: "+monster.Type["main"]);
            Interpreter.DisplayOutput("");
            Interpreter.DisplayOutput("<color=yellow>Description</color>: "+monster.Description);
            Interpreter.DisplayOutput("");
            Interpreter.DisplayOutput($"<color=yellow>Level</color>: {monster.Level}");
            Interpreter.DisplayOutput($"<color=yellow>HP</color>: {monster.HP} <color=yellow>MP</color>: {monster.MP} <color=yellow>AC</color>: {monster.BaseAc}");
            // Interpreter.DisplayOutput("MP: "+monster.MP);
            // Interpreter.DisplayOutput("AC: "+monster.BaseAc);
            foundTarget = true;
            return;
          }
        }
        // LOOK AT ITEM
        foreach (Item item in current_location.Items)
        {
          if (item.Name.ToLower().Contains(target))
          {
            Interpreter.DisplayOutputColor("[+] You examine the item in the room closely...","#FF00E5");
            Interpreter.DisplayOutput("<color=yellow>Name:</color> "+item.Name);
            Interpreter.DisplayOutput("");
            Interpreter.DisplayOutput("<color=yellow>Description:</color> "+item.Description);
            Interpreter.DisplayOutput("");
            Interpreter.DisplayOutput("<color=yellow>Worth:</color> "+item.Worth+" gold");
            if (item.Flags.Contains("weapon"))
            {
              Interpreter.DisplayOutput($"<color=yellow>Slot:</color> {item.Slot}");
              Interpreter.DisplayOutput($"<color=yellow>Attack:</color> {item.Atk[0]} +{item.Atk[1]}");
              Interpreter.DisplayOutput($"<color=yellow>Damage:</color> {item.Dam[0]}{item.Dam[1]}{item.Dam[2]}");
            }
            if (item.Flags.Contains("armor"))
            {
              Interpreter.DisplayOutput($"<color=yellow>Slot:</color> {item.Slot}");
              Interpreter.DisplayOutput($"<color=yellow>AC:</color> +{item.AcBonus}");
              Interpreter.DisplayOutput($"<color=yellow>Type:</color> {item.Type}");
            }
            if (item.Flags.Contains("consume on use"))
            {
              Interpreter.DisplayOutput($"{item.Action[0]} {item.Action[1]} for {item.Action[2]}{item.Action[3]}{item.Action[4]}+{item.Action[5]}");              
            }
            if (item.Flags.Contains("container") && item.Contents.Count > 0)
            {
              Interpreter.DisplayOutput("<color=yellow>Contents:</color>");
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
            Interpreter.DisplayOutputColor("[+] You examine the item in your inventory closely...","#FF00E5");
            Interpreter.DisplayOutput("<color=yellow>Name:</color> "+item.Name);
            Interpreter.DisplayOutput("");
            Interpreter.DisplayOutput("<color=yellow>Description:</color> "+item.Description);
            Interpreter.DisplayOutput("");
            Interpreter.DisplayOutput("<color=yellow>Worth:</color> "+item.Worth+" gold");
            if (item.Flags.Contains("weapon"))
            {
              Interpreter.DisplayOutput($"<color=yellow>Slot:</color> {item.Slot}");
              Interpreter.DisplayOutput($"<color=yellow>Attack:</color> {item.Atk[0]} +{item.Atk[1]}");
              Interpreter.DisplayOutput($"<color=yellow>Damage:</color> {item.Dam[0]}{item.Dam[1]}{item.Dam[2]}");
            }
            if (item.Flags.Contains("armor"))
            {
              Interpreter.DisplayOutput($"<color=yellow>Slot:</color> {item.Slot}");
              Interpreter.DisplayOutput($"<color=yellow>AC:</color> {item.AcBonus}");
              Interpreter.DisplayOutput($"<color=yellow>Type:</color> {item.Type}");
            }
            if (item.Flags.Contains("consume on use"))
            {
              Interpreter.DisplayOutput($"{item.Action[0]} {item.Action[1]} for {item.Action[2]}{item.Action[3]}{item.Action[4]}+{item.Action[5]}");              
            }
            if (item.Flags.Contains("container") && item.Contents.Count > 0)
            {
              Interpreter.DisplayOutput("<color=yellow>Contents:</color>");
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

      // LOOK ROOM
      Interpreter.DisplayOutputColor(current_location.Name,"#85FF82");
      Interpreter.DisplayOutput("");
      Interpreter.DisplayOutput("");
      Interpreter.DisplayOutput(current_location.Description); // Unity edition
      Interpreter.DisplayOutput("");
      Interpreter.DisplayOutput("");
      
      // DISPLAY EXITS
      string listExits = "";
      Dictionary<string, string> exits = current_location.Exits;
      foreach (KeyValuePair<string, string> exit in exits)
      {
        if (exit.Value == "True")
        {
          // Interpreter.DisplayOutput($"-{exit.Key}");
          listExits += exit.Key+" ";
        }
      }
      Interpreter.DisplayOutputColor($"[ Exits: {listExits}]", "#85FF82");

      //DISPLAY ITEMS
      if (current_location.Items.Count > 0)
      {
        Interpreter.DisplayOutputColor("Items in the room:","yellow");
        foreach (Item item in current_location.Items)
        {
          Interpreter.DisplayOutputColor($"-{item.Name}","yellow");
        }
      }

      //  DISPLAY MONSTERS
      if (current_location.Monsters.Count > 0)
      {
        Interpreter.DisplayOutputColor($"Monster in the room:","yellow");
        foreach (Monster monster in current_location.Monsters)
        {
          Interpreter.DisplayOutputColor($"-{current_location.Monsters[0].Name}","yellow");
        }
      }

    }
  }
}