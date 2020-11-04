using System.Collections.Generic;
using UnityEngine;

namespace Dungeon_Darkly
{
  public partial class Action
  {
    public static void Equip(string target)
    {
      // FIRST SCAN INVENTORY
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
              return;
            }
            else
            {
              Interpreter.DisplayOutput($"[-] You already have something equipped in {equip.Slot} slot");
              return;
            }
          }
        }
        // else
        // {
        //   Interpreter.DisplayOutput($"You can't equip {target}");
        //   return;
        // }
      }
      Debug.Log("didn't find in inventory");
      // THEN SCAN THE ENVIRONMENT
      Environment current_location = TerminalManager.game.Environments[TerminalManager.game.Players[0].Location];
      for (int i=0; i<current_location.Items.Count; i++)
      {
        Debug.Log(target);
        Debug.Log(current_location.Items[i].Name);
        if (current_location.Items[i].Name.ToLower().Contains(target))
        {
          Item equip = current_location.Items[i];
          Debug.Log("match!"+current_location.Items[i].Name+target);
          if (current_location.Items[i].Slot != null)
          {
            Debug.Log("E- is equip");
            if (TerminalManager.game.Players[0].Equip[current_location.Items[i].Slot][0] == null)
            {
              Debug.Log("Slot free, can equip");
              TerminalManager.game.Players[0].AddItemEquip(current_location.Items[i]);
              for (int x=0;x<current_location.Items.Count;x++)
              {
                if (current_location.Items[x] == equip)
                {
                  Debug.Log($"p inv remove {current_location.Items[x].Name}");
                  current_location.Items.RemoveAt(x);
                }
              }
              Interpreter.DisplayOutput($"[+] {equip.Name} equipped to {equip.Slot}!");
              return;
            }
            else
            {
              Interpreter.DisplayOutput($"[-] You already have something equipped in {equip.Slot} slot");
              return;
            }
          }
        }  
      }
      Interpreter.DisplayOutput($"You can't equip {target}");
      return;
    }
  }  // Action.UpdateInvDisplay();      
}