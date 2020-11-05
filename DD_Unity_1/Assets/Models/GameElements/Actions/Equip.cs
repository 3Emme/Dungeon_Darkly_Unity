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
        if (inventory[i].Name.ToLower().Contains(target))
        {
          Item equip = inventory[i];
          if (inventory[i].Slot != null)
          {
            if (TerminalManager.game.Players[0].Equip[inventory[i].Slot][0] == null)
            {
              TerminalManager.game.Players[0].AddItemEquip(inventory[i]);
              for (int x=0;x<inventory.Count;x++)
              {
                if (inventory[x] == equip)
                {
                  inventory.RemoveAt(x);
                }
              }
              TerminalManager.game.Players[0].EquipCheck();
              Interpreter.DisplayOutputColor($"[+] {equip.Name} equipped to {equip.Slot}!","#FF00E5");
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
      // THEN SCAN THE ENVIRONMENT
      Environment current_location = TerminalManager.game.Environments[TerminalManager.game.Players[0].Location];
      for (int i=0; i<current_location.Items.Count; i++)
      {
        if (current_location.Items[i].Name.ToLower().Contains(target))
        {
          Item equip = current_location.Items[i];
          if (current_location.Items[i].Slot != null)
          {
            if (TerminalManager.game.Players[0].Equip[current_location.Items[i].Slot][0] == null)
            {
              TerminalManager.game.Players[0].AddItemEquip(current_location.Items[i]);
              for (int x=0;x<current_location.Items.Count;x++)
              {
                if (current_location.Items[x] == equip)
                {
                  current_location.Items.RemoveAt(x);
                }
              }
              TerminalManager.game.Players[0].EquipCheck();
              Interpreter.DisplayOutputColor($"[+] {equip.Name} equipped to {equip.Slot}!","#FF00E5");
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
    }
    // Action.UpdateInvDisplay();
  }
}