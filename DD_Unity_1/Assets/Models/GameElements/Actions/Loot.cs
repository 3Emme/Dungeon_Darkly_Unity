using System;
using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public partial class Action
  {
    public static void Loot(string target)
    {
    //   var player = TerminalManager.game.Players[0];
    //   var current_location = TerminalManager.game.Environments[TerminalManager.game.Players[0].location];
    //   for (const item of current_location.items) {
    //     // console.log("L-", item);
    //     if (item.name.toLowerCase().includes(target))
    //     {
    //       // console.log("L- found target");
    //       if (item.flags.includes("container"))
    //       {
    //         // console.log("L- is a cont..");
    //         if (item.contents.length === 0)
    //         {
    //           Display.output(`[-] It's empty!`);
    //         }
    //         else
    //         {
    //           item.contents.forEach(function(thing){
    //             // console.log("L- ", thing);
    //             // console.log(player.inv);      
    //             player.inv.push(thing);
    //             Display.output(`[+] Looted ${ thing.name}`);
    //           });
    //           item.contents = [];
    //           // console.log
    //           item.name = item.name.concat(" (looted)");
    //         }
    //       }
    //       else
    //       {
    //         TerminalManager.game.get(target);
    //       }
    //     }
    //     else
    //     {
    //       //Display.output(`[-] Loot what?`);
    //       //break;
    //     }
    //   }
    //   TerminalManager.game.updateInvDisplay();
    }
  }
}