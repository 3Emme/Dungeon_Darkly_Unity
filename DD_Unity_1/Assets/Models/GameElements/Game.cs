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

    public void AddEnvironment(string name, string description, List<Item> items, List<Monster> monsters, List<Player> players, Dictionary<string, string> exits, int[] coordinates)
    {
      Environment newEnvironment = new Environment(name, description, items, monsters, players, exits, coordinates);
      this.Environments.Add(newEnvironment);
    }

    public Player AddPlayer(string name, string race, string pclass, int level, int xp, int hp, int mp, int hunger, List<Item> inv, int str, int dex, int con, int wis, int intel, int chr, int lck)
    {
      AbilityScores abilityScores = new AbilityScores(str, dex, con, wis, intel, chr, lck);
      Player newPlayer = new Player(name, abilityScores, race, pclass, level, xp, hp, mp, hunger, inv);
      return newPlayer;
    }

    public Monster AddMonster(int id, string name, string mainType, int level, int hp, int mp, List<Item> inv, List<string> behaviors, int str, int dex, int con, int wis, int intel, int chr, int lck)
    {
      AbilityScores abilityScores = new AbilityScores(str, dex, con, wis, intel, chr, lck);
      Monster newMonster = new Monster(id, name, abilityScores, mainType, level, hp, mp, inv, behaviors);
      return newMonster;
    }

    // public Item AddItem(string name, int Id, int worth, int Hp, int level, List<string> status, List<string> flags, string rarity)
    // {
    //   Item newItem = new Item(name, Id, worth, Hp, level, status, flags, rarity);
    //   return newItem;
    // }

    public Weapon AddWeapon(string slot, string[] atk, string[] dam, string name, int Id, int worth, int Hp, int level, List<string> status, List<string> flags, string rarity)
    {
      Weapon newWeapon = new Weapon(slot, atk, dam, name, Id, worth, Hp, level, status, flags, rarity);
      return newWeapon;
    }

    public Armor AddArmor(string slot, int acBonus, string type, string name, int Id, int worth, int Hp, int level, List<string> status, List<string> flags, string rarity)
    {
      Armor newArmor = new Armor(slot, acBonus, type, name, Id, worth, Hp, level, status, flags, rarity);
      return newArmor;
    }

    public Container AddContainer(string type, int capacity, string name, int Id, int worth, int Hp, int level, List<string> status, List<string> flags, string rarity)
    {
      Container newContainer = new Container(type, capacity, name, Id, worth, Hp, level, status, flags, rarity);
      return newContainer;
    }

    public Consumable AddConsumable(string action, string type, string name, int Id, int worth, int Hp, int level, List<string> status, List<string> flags, string rarity)
    {
      Consumable newConsumable = new Consumable(action, type, name, Id, worth, Hp, level, status, flags, rarity);
      return newConsumable;
    }

    public int Roll(int num, int side, int mod)
    {
      Random _random = new Random();
      int total = mod;
      int min = 1;
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

    public int Roll(int num, int side, int mod, int adj)
    {
      Random _random = new Random();
      int total = mod;
      int min = 1 + adj;
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
    // public void Look(string target)
    // {
    //   // Display.DisplayCharStats(this.players[0]);

    //   // MONSTER STAT WINDOW
    //   // if (this.Environments[0].Monsters[0] != null) 
    //   // {
    //   //   Display.DisplayMonsterStats(this.environments[this.players[0].location].monsters[0]);
    //   // } 
    //   // else 
    //   // {
    //   //   // Display.DisplayMonsterStats("none");
    //   // }

    //   // console.log("player look function:",target);      
    //   // console.log(this.environments[this.players[0].location].name);
    //   // Display.output(this.environments[this.players[0].location].description);
    //   Interpreter.DisplayOutput(TerminalManager.game.Environments[0].Description); // Unity edition
    //   // return this.Environments[0].Description;
    //   // if (this.Environments[0].Items.Count > 0) 
    //   {
    //     // Display.output(`Items in the room:`);
    //     Interpreter.DisplayOutput("Items in the room:");
    //     foreach (Item item in this.Environments[0].Items)
    //     {
    //       // Display.output(`${item.name}`);
    //       Interpreter.DisplayOutput($"{item.Name}");
    //     }
    //   }
    //   if (this.Environments[0].Monsters.Count > 0)
    //   { // THIS ONLY DISPLAYS ONE MONSTER
    //     // Display.output(`Monster in the room: <span class="red">${this.environments[this.players[0].location].monsters[0].name}</span>`);
    //     Interpreter.DisplayOutput($"Monster in the room: {this.Environments[0].Monsters[0].Name}");
    //   }
    // }

  }
}
