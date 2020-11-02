using System;
using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public class Environment
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public List<Monster> Monsters { get; set; }
    public List<Player> Players { get; set; }
    public Dictionary<string, string> Exits { get; set; }
    public Combat Combat { get; set; }

    public Environment(string name, string description, List<Item> items, List<Monster> monsters, List<Player> players, Dictionary<string, string> exits)
    {
      this.Name = name;
      this.Description = description;
      this.Items = items;
      this.Monsters = monsters;
      this.Players = players;
      this.Exits = exits;
      this.Combat = new Combat();
    }
  }
}



// import Combat from './combat_class.js';

// export default class Environment {
//   constructor(name,description,items,monsters,players,exits) {
//     this.name = name;
//     this.description = description;
//     this.items = items;
//     this.monsters = monsters;
//     this.players = players;
//     this.exits = exits;
//     this.combat = new Combat();
//   }  
// } 