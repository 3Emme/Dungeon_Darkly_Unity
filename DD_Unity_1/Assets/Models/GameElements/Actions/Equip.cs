using System;
using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public partial class Action
  {
    //   public static void Equip(target) {
    //     foreach (Item element of TerminalManager.game.Players[0].Inv) {
    //       if (element.Name.ToLower().includes(target)) {
    //         Item equip = element;
    //         //equip
    //         if (equip.Slot != null) {
    //           console.log("E- is equip");
    //           string slot = equip.Slot;
    //           if (!TerminalManager.game.Players[0].Equip[slot][0]) {
    //             // go ahead and equip here
    //             Terminal.game.players[0].addItemEquip(equip);
    //             // remove rom inv!
    //             for (let i=0;i<Terminal.game.players[0].inv.length;i++) {
    //               if (Terminal.game.players[0].inv[i] === equip) {
    //                 Terminal.game.players[0].inv.splice(i,1);
    //               }
    //             }
    //             console.log(this.players[0].equip);
    //            Interpreter.DisplayOutput($"[+] {equip.Name} equipped to {equip.Slot}!");
    //           } else {
    //             Interpreter.DisplayOutput($"[-] You already have something equiped in {equip.Slot} slot");
    //           }
    //         } else {
    //           //Display.output("[-] You can't equip that");
    //         }
    //       } else {
    //         console.log("equip cmd scan envir");
    //         foreach (Item element of Terminal.game.environments[Terminal.game.players[0].location].items) {
    //           if (element.Name.ToLower().includes(target)) {
    //             //equip
    //           } else {
    //             //Display.output("[-] You can't equip that");
    //           }
    //         }
    //       }
    //     }
    //     Action.UpdateInvDisplay(); 
    //   }
  }
}

