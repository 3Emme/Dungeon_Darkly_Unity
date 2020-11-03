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

      foreach (Item item in current_location.Items) 
      {
        // console.log("L-", item);
        if (item.Name.ToLower().Contains(target))
        {
          // console.log("L- found target");
          
          // if (item.Flags.Contains("container"))
          if (item.GetType() == Container)
          {
            // console.log("L- is a cont..");
            if (item.Contents.Count == 0)
            {
              // Display.output(`[-] It's empty!`);
              Interpreter.DisplayOutput("[-] It's empty!");
            }
            else
            {
              // item.Contents.forEach(function(thing)
              foreach (Item thing in item.Contents)
              {
                // console.log("L- ", thing);
                // console.log(player.inv);      
                player.Inv.Add(thing);
                // Display.output(`[+] Looted ${ thing.name}`);
                Interpreter.DisplayOutput($"[+] Looted {thing.Name}");
              }
              item.Contents.Clear();
              // console.log
              // item.Name = item.Name.Concat(" (looted)");
              item.Name += " (looted)";
            }
          }
          else
          {
            // Action.Get(target);
          }
        }
        else
        {
          //Display.output(`[-] Loot what?`);
          //break;
        }
      }
      // Action.UpdateInvDisplay();
    }
  }
}