using System;
using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public class Game
  {
    public List<Player> Players { get; set; }
    public List<Item> Items { get; set; }
    public List<Monster> Monsters { get; set; }
    public List<Environment> Environments { get; set; }
    public int GameClock { get; set; }

    public Game(List<Player> players, List<Item> items, List<Monster> monsters, List<Environment> environments)
    {
      this.Players = players;
      this.Items = items;
      this.Monsters = monsters;
      this.Environments = environments;
      this.GameClock = 0;
    }

    public void AddEnvironment(string name, string description, List<Item> items, List<Monster> monsters, List<Player> players, Dictionary<string,string> exits)
    {
      Environment newEnvironment = new Environment(name,description,items,monsters,players,exits);
      this.Environments.Add(newEnvironment);
    }

    public Player AddPlayer(string name, string race, string pclass, int level, int xp, int hp, int mp, int hunger, List<Item> inv, int str, int dex, int con, int wis, int intel, int chr, int lck)
    {
      AbilityScores abilityScores = new AbilityScores(str,dex,con,wis,intel,chr,lck);
      Player newPlayer = new Player(name,abilityScores,race,pclass,level,xp,hp,mp,hunger,inv);
      return newPlayer;
    }

    public Monster AddMonster(int id, string name, string mainType, int cr, int hp, int mp, List<Item> inv, List<string> behaviors, int str, int dex, int con, int wis, int intel, int chr, int lck)
    {
      AbilityScores abilityScores = new AbilityScores(str,dex,con,wis,intel,chr,lck);
      Monster newMonster = new Monster(id,name,abilityScores,mainType,cr,hp,mp,inv,behaviors);
      return newMonster;
    }

    public Item AddItem(string name, int Id, int worth, int Hp, int level, List<string> status, List<string> flags, string rarity)
    {
      Item newItem = new Item(name,Id,worth,Hp,level,status,flags,rarity);
      return newItem;
    }

    public Weapon AddWeapon(string slot, string[] atk, string[] dam, string name, int Id, int worth, int Hp, int level, List<string> status, List<string> flags, string rarity)
    {
      Weapon newWeapon = new Weapon(slot,atk,dam,name,Id,worth,Hp,level,status,flags,rarity);
      return newWeapon;
    }

    public Armor AddArmor(string slot, int acBonus, string type, string name, int Id, int worth, int Hp, int level, List<string> status, List<string> flags, string rarity) {
      Armor newArmor = new Armor(slot,acBonus,type,name,Id,worth,Hp,level,status,flags,rarity);
      return newArmor;
    }

    public Container AddContainer(string type, int capacity, string name, int Id, int worth, int Hp, int level, List<string> status, List<string> flags, string rarity)
    {
      Container newContainer = new Container(type,capacity,name,Id,worth,Hp,level,status,flags,rarity);
      return newContainer;
    }

    public Consumable AddConsumable(string action, string type, string name, int Id, int worth, int Hp, int level, List<string> status, List<string> flags, string rarity) 
    {
      Consumable newConsumable = new Consumable(action,type,name,Id,worth,Hp,level,status,flags,rarity);
      return newConsumable;
    }

    public int Roll(int num, int side, int mod, int adj)
    {
      Random _random = new Random();
      int total;
      if (mod == null) // Unity swtich from ! to = null
      {
        total = 0;
      }
      else
      {
        total = mod;
      }
      int min;
      if (adj == null)
      {
        min = 1;
      }
      else
      {
        min = 1 + adj;
      }
      for (int i = 0; i < num; i++)
      {
        // int roll = ((min-1) + Math.ceil(Math.random() * (side-min + 1)));
        int roll = _random.Next(min, (side + min));
        total += roll;
      }
      if (total < num)
      {
        total = num;
      }
      return total;
    }

    // public void InputParser(string input)
    // {
    //   string[] splitString = input.ToLower().Split(" ");

    //   // LOOK
    //   if (splitString[0] == "look" || splitString[0] == "l")
    //   {
    //     string target;
    //     if (splitString[1]) {
    //       target = splitString[1];
    //     } else {
    //       target = "";
    //     }
    //     this.Look(target);
    //   }

      // // ATTACK
      // if (splitString[0] == "attack"||splitString[0] == "at"||splitString[0] == "fight")
      // { 
      //   string target;
      //   if (splitString[1]) {
      //     target = splitString[1];
      //     this.Attack(target);
      //   } else {
      //     target = "";
      //     Display.output("<span class='cyan'>Attack</span> what?");
      //   }
      // } 

      // // MOVE
      // if (splitString[0] == "move")
      // {          
      //   this.Move();  
      // }

      // //GET
      // if (splitString[0] == "get") {
      //   string target;
      //   if (splitString[1]) {
      //     target = splitString[1];
      //     this.Get(target);
      //   } else {
      //     target = "";
      //     // Display.output("<span class='cyan'>Get</span> what?");     
      //   }
      // }

      // //EQUIP
      // if (splitString[0] == "equip") {
      //   string target;
      //   if (splitString[1]) {
      //     target = splitString[1];
      //     this.Equip(target);
      //   } else {
      //     target = "";
      //     this.ViewEquip();
      //     //Display.output("Equip what?")      
      //   }
      // }

      // //LOOT
      // if (splitString[0] == "loot") {
      //   string target;
      //   if (splitString[1]) {
      //     target = splitString[1];
      //     this.Loot(target);
      //   } else {
      //     target = "";
      //     // Display.output("Loot what?");
      //   }
      // }

      // //USE
      // if (splitString[0] == "use") {
      //   string target;
      //   if (splitString[1]) {
      //     target = splitString[1];
      //     this.Use(target);
      //   } else {
      //     target = "";
      //     // Display.output("Use what?");     
      //   }
      // }

      // //HELP
      // if (splitString[0] == "--help"||splitString[0] == "?"||splitString[0] == "help") {
      //   this.Help();
      // }
    // }

    //look(target);
    public string Look(string target) 
    {
      // Display.DisplayCharStats(this.players[0]);
      if (this.Environments[0].Monsters[0] != null) 
      {
        // Display.DisplayMonsterStats(this.environments[this.players[0].location].monsters[0]);
      } 
      else 
      {
        // Display.DisplayMonsterStats("none");
      }
      // console.log("player look function:",target);      
      // console.log(this.environments[this.players[0].location].name);
      // Display.output(this.environments[this.players[0].location].description);
      return this.Environments[0].Description;
      if (this.Environments[0].Items.Count > 0) 
      {
        // Display.output(`Items in the room:`);
        foreach(Item item in this.Environments[0].Items)
        {
          // Display.output(`${item.name}`);
        }
      }
      if (this.Environments[0].Monsters.Count > 0) {
        // Display.output(`Monster in the room: <span class="red">${this.environments[this.players[0].location].monsters[0].name}</span>`);
      }
    }
  }
}
    

//   //attack(target);
//   attack(target) {
//     let location = this.environments[this.players[0].location];
//     console.log(`player attack function. target: ${target}`);
//     if (location.combat.roundCount == 1){
//       let targetMonster;     
//       this.environments[this.players[0].location].monsters.forEach(function(monster){
//         if (monster.name.toLowerCase().includes(target)) {
//           targetMonster = monster;
//         }
//       });
//       // this.environments[0].monsters[0]
//       //$("#terminalOutput").append("<br>>" + this.environments[0].name);
//       Display.output(`<br>You join in battle with the ${this.environments[this.players[0].location].monsters[0].name}!`);
//       this.combatStart(this.environments[this.players[0].location].players[0],targetMonster);
//     } else {
//       location.combat.combatTurn(location.combat.turnOrder[0],location.combat.turnOrder[1]);
//       //begin combat loot migration protocol
//       if (location.combat.loot[0]){
//         console.log(`combat environment has loot. Loot push to environment engaged.`);
//         for (let loot of location.combat.loot){
//           location.items.push(loot);
//           console.log(`loot pushed: ${loot.name}`);
//         }
//         location.combat.loot = [];
//         console.log(`combat loot emptied. See? combat.loot = ${location.combat.loot}`);
//         // console.log(`environment items = ${location.items[0].name} and ${location.items[1].name} and ${location.items[2].name} and ${location.items[3].name} and ${location.items[4].name}. Inside of ${location.items[4].name}: ${location.items[4].contents[0].name}`);
//         for (let combatMonster of location.monsters){
//           if (combatMonster.status.dead === true){
//             console.log(`${combatMonster.name} is dead and should be removed from environment.monsters now.`);
//             location.monsters = [];
//             //remove this monster from location.monsters
//           }
//         }
//       }
//     }
//   }

//   // equip
//   equip(target) {
//     for (let element of this.players[0].inv) {
//       console.log("E- equip cmd scan inv");
//       if (element.name.toLowerCase().includes(target)) {
//         let equip = element;
//         console.log("E-",equip);
//         //equip
//         if (equip.slot) {
//           console.log("E- is equip");
//           let slot = equip.slot;
//           if (!this.players[0].equip[slot][0]) {
//             // go ahead and equip here
//             this.players[0].addItemEquip(equip);
//             // remove rom inv!
//             for (let i=0;i<this.players[0].inv.length;i++) {
//               if (this.players[0].inv[i] === equip) {
//                 this.players[0].inv.splice(i,1);
//               }
//             }
//             console.log(this.players[0].equip);
//             Display.output(`[+] ${equip.name} equipped to ${equip.slot}!`);
//           } else {
//             Display.output("[-] You Already have something equiped there");
//           }
//         } else {
//           //Display.output("[-] You can't equip that");
//         }
//       } else {
//         console.log("equip cmd scan envir");
//         for (let element of this.environments[this.players[0].location].items) {
//           if (element.name.toLowerCase().includes(target)) {
//             //equip
//           } else {
//             //Display.output("[-] You can't equip that");
//           }
//         }
//       }
//     }
//     this.updateInvDisplay(); 
//   }

//   viewEquip() {
//     for (const slot in this.players[0].equip) {
//       if (this.players[0].equip[slot][0]) {
//         console.log(this.players[0].equip[slot]);
//         Display.output(`-${slot}: <span class=blue">${this.players[0].equip[slot][0].name}</span>`);
//       } else {
//         Display.output(`-${slot}: <span class="red">nothing</span>`);
//       }
      
//     }
//   }
  
  

//   combatStart(participant,target){
//     let turnOrder = [];
//     // stealth-surprise check
//     // if (this.status.some(status => status.hidden === true)){
//     //   let stealthCheck = this.abilityScoreCheck('dex');
//     //   let perceptionCheck = [target].abilityScoreCheck('wis');
//     //   if (stealthCheck > perceptionCheck){
//     //   [target].status.surprised = true;
//     //   }
//     // }
//     // roll for initiative, fill turnOrder
//     let participantInit = participant.abilityScoreCheck('dex');
//     let targetInit = target.abilityScoreCheck('dex');
//     Display.output(`---rolling combat initiative---<br>${participant.name}'s init roll = ${participantInit} / ${target.name}'s init roll = ${targetInit}`);
//     console.log(`targetInit: ${targetInit}`);
//     if (participantInit >= targetInit){
//       turnOrder.push(participant);
//       turnOrder.push(target);
//     } else {
//       turnOrder.push(target);
//       turnOrder.push(participant);
//     }
//     let location = this.environments[participant.location];
//     // set the Combat turnOrder
//     location.combat.turnOrder = turnOrder;
//     // begin the combatTurn!
//     location.combat.combatTurn(location.combat.turnOrder[0],location.combat.turnOrder[1]);
//     //begin combat loot migration protocol
//     if (location.combat.loot[0]){
//       console.log(`combat environment has loot. Loot push to environment engaged.`);
//       for (let loot of location.combat.loot){
//         location.items.push(loot);
//         console.log(`loot pushed: ${loot.name}`);
//       }
//       location.combat.loot = [];
//       console.log(`combat loot emptied. See? combat.loot = ${location.combat.loot}`);
//       // console.log(`environment items = ${location.items[0].name} and ${location.items[1].name} and ${location.items[2].name} and ${location.items[3].name} and ${location.items[4].name}. Inside of ${location.items[4].name}: ${location.items[4].contents[0].name}`);
//       for (let combatMonster of location.monsters){
//         if (combatMonster.status.dead === true){
//           console.log(`${combatMonster.name} is dead and should be removed from environment.monsters now.`);
//           location.monsters = [];
//           //remove this monster from location.monsters
//         }
//       }
//     }
//   } // end combatStart

//   move() {
//     let current_location = this.players[0].location;
//     if (current_location  >= this.environments.length-1) {
//       Display.output(`<br> You can't move anymore!`);
//     } else {
//       this.players[0].location +=1;
//       console.log(current_location);
//       Display.output("You bravely advance into the next area!");
//       this.environments[this.players[0].location].players.push( this.players[0]);
//       this.environments[this.players[0].location-1].players.shift();
//       this.look("");
//       Display.updateMap(this.players[0].location);
//     }    
//   }

//   get(target) {
//     let current_location = this.environments[this.players[0].location];
//     for (let i=0;i<current_location.items.length;i++) {
//       if (current_location.items[i].name.toLowerCase().includes(target)) {        
//         //this.look("")
//         Display.output(`[+] You pick up the ${current_location.items[i].name}`);
//         this.players[0].inv.push(current_location.items[i]);

//         current_location.items.splice(i,1);
//         console.log("location items:",current_location.items);
//         console.log("INV",this.players[0].inv);
//         // current_location.items = newArray        
//         break;
//       }   
//     } 
//     this.updateInvDisplay(); 
//   } 

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

//   heal(effectOrigin,effectTarget,diceAmount,sideNumber,mod){
//     console.log(`effectOrigin.name: ${effectOrigin.name}, effectTarget: ${effectTarget}, diceAmount: ${diceAmount}, sideNumber: ${sideNumber}, mod: ${mod} `);
//     console.log(`typeof effectOrigin.name: ${typeof effectOrigin.name}, typeof effectTarget: ${typeof effectTarget}, typeof diceAmount: ${typeof diceAmount}, typeof sideNumber: ${typeof sideNumber}, typeof mod: ${typeof mod} `);
//     console.log(`heal function activated`);
//     let healAmount = this.roll(diceAmount,sideNumber,mod);
//     if (effectTarget === "self"){ //"self"
//       console.log(`${effectOrigin.name}'s HP is first ${effectOrigin.hp}`);
//       effectOrigin.hp += healAmount;
//       console.log(`${effectOrigin.name} just healed by ${healAmount}`);
//       console.log(`${effectOrigin.name}'s HP is now ${effectOrigin.hp}`);
//       Display.displayCharStats(effectOrigin);
//     }
//     console.log(`heal function completed`);
//   }
  
//   updateInvDisplay() {
//     Display.clearInv();
//     this.players[0].inv.forEach(function(item){
//       Display.addInv(item.name);
//     });
//   }

//   loot(target) {
//     let player = this.players[0];
//     let current_location = this.environments[this.players[0].location];
//     for (const item of current_location.items) {
//       console.log("L-",item);
//       if (item.name.toLowerCase().includes(target)) {
//         console.log("L- found target");
//         if (item.flags.includes("container")) {
//           console.log("L- is a cont..");
//           if (item.contents.length === 0) {
//             Display.output(`[-] It's empty!`);
//           } else {
//             item.contents.forEach(function(thing){  
//               console.log("L- ",thing);
//               // console.log(player.inv);      
//               player.inv.push(thing);
//               Display.output(`[+] Looted ${thing.name}`);
//             });
//             item.contents = [];
//             // console.log
//             item.name = item.name.concat(" (looted)");
//           }
//         } else {
//           this.get(target);
//         }
//       } else {
//         //Display.output(`[-] Loot what?`);
//         //break;
//       }
//     }
//     this.updateInvDisplay();
//   }

  //     if (item.flags.includes("container")) {

  //       if (item.contents.length === 0) {
  //         Display.output(`[-] It's empty!`);
  //       } else {
  //         console.log("L- found a container");

  //         if (item.name.toLowerCase().includes(target)) {
  //           console.log("L- found loot target");
  //           item.contents.forEach(function(thing){  
  //             console.log("L- ",thing);
  //             console.log(player.inv);      
  //             player.inv.push(thing);
  //           });
  //           item.contents = [];
  //           item.name.concat(" (looted)");
  //         } else {
  //             Display.output(`[-] Loot what?`)
  //             break;
  //         }
  //       }        
  //     } else {
  //       //Display.output(`[-] You can't loot that`);
  //       this.get(target);
  //       break;
  //     }
  //   }
  //   this.updateInvDisplay();
  // }

  // help() {
  //   Display.output(`<span class="white"><HELP FILE>
  //   Hello adventurer! A little hooked are ya? No worries! Here's a list of commands that could be helpful!
  //   <span class="cyan"><br>Commands:</span><br>
  //   <movement> -> type "move"<br>
  //   <sight-based> -> type "look" (looks at room.) or type "look at ___" to look at something specific.<br>
  //   <combat> -> type "attack *enemy*" or "fight *enemy*" If an enemy is not specified, you will be asked what you're attacking.<br>
  //   <looting> type "loot corpse" when an enemy is defeated. If an item is present in the environment, type "get item"<br>
  //   <equip> type <equip item *body part*> to equip an item to the appropriate slot on your character.</span>`);
  // }
    // }
//   }
// }