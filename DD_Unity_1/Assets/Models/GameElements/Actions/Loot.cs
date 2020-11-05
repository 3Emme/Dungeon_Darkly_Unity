using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public partial class Action
  {
    public static void Loot(string target)
    {
      Player player = TerminalManager.game.Players[0];
      Environment current_location = TerminalManager.game.Environments[TerminalManager.game.Players[0].Location];
      bool isContainer = false;
      foreach (Item item in current_location.Items)
      {
        if (item.Name.ToLower().Contains(target))
        {
          if (item.Flags.Contains("container"))
          {
            isContainer = true;
            if (item.Contents.Count == 0)
            {
              Interpreter.DisplayOutput("[-] It's empty!");
            }
            else
            {
              foreach (Item thing in item.Contents)
              {
                player.Inv.Add(thing);
                Interpreter.DisplayOutputColor($"[+] Looted {thing.Name}","#FF00E5");
              }
              item.Contents.Clear();
              item.Name += " (looted)";
            }
          }
        }
      }
      if (!isContainer)
      {
        Action.Get(target);
      }
      // Action.UpdateInvDisplay();
    }
  }
}