using System.Collections.Generic;
using UnityEngine;

namespace Dungeon_Darkly
{
  public partial class Action
  {
      public static void Equip(string target)
      {
        List<Item> inventory = TerminalManager.game.Players[0].Inv;
        for (int i=0; i<inventory.Count; i++)
        {
          Debug.Log(inventory[i].Name);
          if (inventory[i].Name.ToLower().Contains(target))
          {
            Item equip = inventory[i];
            Debug.Log("match!"+inventory[i].Name+target);
            if (inventory[i].Slot != null)
            {
              Debug.Log("E- is equip");
              if (TerminalManager.game.Players[0].Equip[inventory[i].Slot][0] == null)
              {
                Debug.Log("Slot free, can equip");
                // go ahead and equip here
                TerminalManager.game.Players[0].AddItemEquip(inventory[i]);
                Debug.Log($"p equip! {TerminalManager.game.Players[0].Equip[inventory[i].Slot][0].Name}");
                // remove rom inv!
                for (int x=0;x<inventory.Count;x++)
                {
                  if (inventory[x] == equip)
                  {
                    Debug.Log($"p inv remove {inventory[x].Name}");
                    inventory.RemoveAt(x);
                  }
                }
                // Debug.Log("Test log "+TerminalManager.game.Players[0].Equip[equip.Slot]);
                Interpreter.DisplayOutput($"[+] {equip.Name} equipped to {equip.Slot}!");
              }
              else
              {
                Interpreter.DisplayOutput($"[-] You already have something equipped in {equip.Slot} slot");
              }
            }
          }
          else
          {
            Interpreter.DisplayOutput($"You can't equip {target}");
          }
          
          //      
          //   } 
          // } else {
          //   Debug.Log("equip cmd scan envir");
          //   foreach (Item thing in TerminalManager.game.Environments[TerminalManager.game.Players[0].Location].Items)
          //   {
          //     if (thing.Name.ToLower().Contains(target)) //POTENTIALLY EQUIP FROM ENVIRONMENT
          //     {
          //       //equip
          //     } 
          //     else {
          //       //Display.output("[-] You can't equip that");
          //     }
          //   }
          // }
        }
        // Action.UpdateInvDisplay(); 
      }
  }
}

