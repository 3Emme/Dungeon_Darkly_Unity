// using UnityEngine;

// namespace Dungeon_Darkly
// {
//   public partial class Action
//   {
//     public static void Use(string target)
//     {
//       Environment current_location = TerminalManager.game.Environments[TerminalManager.game.Players[0].Location];
//       // first check in inv to use this.players[0].inv
//       // console.log(`use function activated. Checking inv for target`);
//       Debug.Log("use function activated. Checking inv for target");
//       for (int i=0;i<TerminalManager.Players[0].Inv.Count;i++)
//       {
//         if (TerminalManager.game.Players[0].Inv[i].Name.ToLower().Contains(target))
//         {        
//           // Display.output(`[+] You use the ${this.players[0].inv[i].name}`);
//           Interpreter.DisplayOutput($"[+] You use the {TerminalManager.game.Players[0].Inv[i].Name}");
//           //perform the changing action of whatever you used, based on the qualities property of consumable item
//           string effectTarget = TerminalManager.game.Players[0].Inv[i].Action[1];
//           int diceAmount = Int32.Parse(TerminalManager.game.Players[0].Inv[i].Action[2]);
//           int sideNumber = Int32.Parse(TerminalManager.game.Players[0].Inv[i].Action[4]);
//           int mod = Int32.Parse(TerminalManager.game.Players[0].Inv[i].Action[5]);
//           this[this.players[0].inv[i].action[0]](this.players[0],effectTarget,diceAmount,sideNumber,mod); // what
//           if (TerminalManager.game.Players[0].Inv[i].Flags[0] == "consume on use")
//           {
//             TerminalManager.game.Players[0].Inv.RemoveAt(i-1); //removes the item. should only happen to consumable
//             // console.log(`item has been consumed and removed`);
//             Debug.Log("item has been consumed and removed");
//           }
//           // console.log(`this.players inv: ${this.players[0].inv}`);
//           Debug.Log($"Players inv: {TerminalManager.game.Players[0].Inv}");
//           // this.updateInvDisplay();        
//         }
//       }
//       // then check in environment to use
//       // console.log(`Could not find target in inv. Checking environment.items for target`);
//       Debug.Log("Could not find target in inv. Checking environment.items for target");
//       for (int i=0;i<current_location.Items.Count;i++)
//       {
//         if (current_location.Items[i].Name.ToLower().Contains(target))
//         {        
//           Interpreter.DisplayOutput($"[+] You use the {current_location.Items[i].Name}");
//           //perform the changing action of whatever you used, based on the qualities property of consumable item
//           string effectTarget = current_location.Items[i].Action[1];
//           int diceAmount = current_location.Items[i].Action[2];
//           int sideNumber = current_location.Items[i].Action[4];
//           int mod = current_location.Items[i].Action[5];
//           this[current_location.items[i].action[0]](this.players[0],effectTarget,diceAmount,sideNumber,mod); // what
//           if (current_location.Items[i].Flags[0] == "consume on use")
//           {
//             current_location.Items.RemoveAt(i-1); //removes the item. should only happen to consumable
//             // console.log(`item has been consumed and removed`);
//             Debug.Log("item has been consumed and removed");
//           }
//           // console.log(current_location.items);
//           Debug.Log($"{current_location.Items}");
//           // this.updateInvDisplay();        
//         }   
//       } 
//       // this.updateInvDisplay();
//     } // end use method
//   }
// }




//   use(target) {
//     let current_location = this.environments[this.players[0].location];
//     // first check in inv to use this.players[0].inv
//     console.log(`use function activated. Checking inv for target`);
//     for (let i=0;i<this.players[0].inv.length;i++) {
//       if (this.players[0].inv[i].name.toLowerCase().includes(target)) {        
//         Display.output(`[+] You use the ${this.players[0].inv[i].name}`);
//         //perform the changing action of whatever you used, based on the qualities property of consumable item
//         let effectTarget = this.players[0].inv[i].action[1];
//         let diceAmount = this.players[0].inv[i].action[2];
//         let sideNumber = this.players[0].inv[i].action[4];
//         let mod = this.players[0].inv[i].action[5];
//         this[this.players[0].inv[i].action[0]](this.players[0],effectTarget,diceAmount,sideNumber,mod);
//         if (this.players[0].inv[i].flags[0] === "consume on use"){
//           this.players[0].inv.splice(i-1,1); //removes the item. should only happen to consumable
//           console.log(`item has been consumed and removed`);
//         }
//         console.log(`this.players inv: ${this.players[0].inv}`);
//         this.updateInvDisplay();        
//         return;
//       }
//     }
//     // then check in environment to use
//     console.log(`Could not find target in inv. Checking environment.items for target`);
//     for (let i=0;i<current_location.items.length;i++) {
//       if (current_location.items[i].name.toLowerCase().includes(target)) {        
//         Display.output(`[+] You use the ${current_location.items[i].name}`);
//         //perform the changing action of whatever you used, based on the qualities property of consumable item
//         let effectTarget = current_location.items[i].action[1];
//         let diceAmount = current_location.items[i].action[2];
//         let sideNumber = current_location.items[i].action[4];
//         let mod = current_location.items[i].action[5];
//         this[current_location.items[i].action[0]](this.players[0],effectTarget,diceAmount,sideNumber,mod);
//         if (current_location.items[i].flags[0] === "consume on use"){
//           current_location.items.splice(i-1,1); //removes the item. should only happen to consumable
//           console.log(`item has been consumed and removed`);
//         }
//         console.log(current_location.items);        
//         this.updateInvDisplay();        
//         return;
//       }   
//     } 
//     // this.updateInvDisplay();
//   } // end use method