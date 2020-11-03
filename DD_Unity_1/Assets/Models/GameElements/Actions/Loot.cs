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
      Debug.Log("L- target: "+target);
      Player player = TerminalManager.game.Players[0];
      Environment current_location = TerminalManager.game.Environments[TerminalManager.game.Players[0].Location];
      foreach (Item item in current_location.Items)
      {
        Debug.Log("L- "+item.Name);
        if (item.Name.ToLower().Contains(target))
        {
          Debug.Log("L- found target");
          Debug.Log(item.GetType());
          if (item.Flags.Contains("container"))
          {
            Debug.Log("L- is a cont..");
            Container temp = (Container)Convert.ChangeType(item, typeof(Container)); // careful, might need to change back
            if (temp.Contents.Count == 0)
            {
              Interpreter.DisplayOutput("[-] It's empty!");
            }
            else
            {
              foreach (Item thing in temp.Contents)
              {
                Debug.Log("L- "+thing);
                player.Inv.Add(thing);
                Interpreter.DisplayOutput($"[+] Looted {thing.Name}");
              }
              temp.Contents.Clear();
              item.Name += " (looted)";
            }
          }
          else
          {

            // Action.Get(target); //NOT WORKING!!!!
          }
        }
        // else
        // {
        //   //Display.output(`[-] Loot what?`);
        //   //break;
        // }
      }
      // Action.UpdateInvDisplay();
    }
  }
}