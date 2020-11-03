using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dungeon_Darkly
{
  public partial class Action
  {
      public static void Equip(string target)
      {
        foreach (Item equip in TerminalManager.game.Players[0].Inv)
        {
          if (equip.Name.ToLower().Contains(target))
          {
            // var temp = equip;
            // if (equip.Flags.Contains("weapon"))
            // {
            //   Weapon temp = (Weapon)Convert.ChangeType(equip, typeof(Weapon));
            // }
            // if (equip.Flags.Contains("armor"))
            // {
            //   Armor temp = (Armor)Convert.ChangeType(equip, typeof(Armor));
            // }
            if (equip.Slot != null) {
              Debug.Log("E- is equip");
              if (TerminalManager.game.Players[0].Equip[equip.Slot][0] == null)
              {
                // go ahead and equip here
                TerminalManager.game.Players[0].AddItemEquip(equip);
                // remove rom inv!
                for (int i=0;i<TerminalManager.game.Players[0].Inv.Count;i++)
                {
                  if (TerminalManager.game.Players[0].Inv[i] == equip)
                  {
                    TerminalManager.game.Players[0].Inv.RemoveAt(i);
                  }
                }
                Debug.Log("Test log"+TerminalManager.game.Players[0].Equip[equip.Slot]);
                Interpreter.DisplayOutput($"[+] {equip.Name} equipped to {equip.Slot} slot!");
              } else {
                Interpreter.DisplayOutput($"[-] You already have something equiped in {equip.Slot} slot");
              }
            } else {
              Interpreter.DisplayOutput($"You can't equip {target}");
            }
          } else {
            Debug.Log("equip cmd scan envir");
            foreach (Item thing in TerminalManager.game.Environments[TerminalManager.game.Players[0].Location].Items)
            {
              if (thing.Name.ToLower().Contains(target)) //POTENTIALLY EQUIP FROM ENVIRONMENT
              {
                //equip
              } 
              else {
                //Display.output("[-] You can't equip that");
              }
            }
          }
        }
        // Action.UpdateInvDisplay(); 
      }
  }
}

