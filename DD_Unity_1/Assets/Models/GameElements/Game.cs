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

    public Monster AddMonster(int id, string name, string mainType, int level, int hp, int mp, List<Item> inv, List<string> behaviors, int str, int dex, int con, int wis, int intel, int chr, int lck, string description)
    {
      AbilityScores abilityScores = new AbilityScores(str, dex, con, wis, intel, chr, lck);
      Monster newMonster = new Monster(id, name, abilityScores, mainType, level, hp, mp, inv, behaviors, description);
      return newMonster;
    }

    public Weapon AddWeapon(string slot, string[] atk, string[] dam, string name, int Id, int worth, int Hp, int level, List<string> status, List<string> flags, string rarity,string description)
    {
      Weapon newWeapon = new Weapon(slot, atk, dam, name, Id, worth, Hp, level, status, flags, rarity, description);
      return newWeapon;
    }

    public Armor AddArmor(string slot, int acBonus, string type, string name, int Id, int worth, int Hp, int level, List<string> status, List<string> flags, string rarity,string description)
    {
      Armor newArmor = new Armor(slot, acBonus, type, name, Id, worth, Hp, level, status, flags, rarity, description);
      return newArmor;
    }

    public Container AddContainer(string type, int capacity, string name, int Id, int worth, int Hp, int level, List<string> status, List<string> flags, string rarity, string description)
    {
      Container newContainer = new Container(type, capacity, name, Id, worth, Hp, level, status, flags, rarity, description);
      return newContainer;
    }

    public Consumable AddConsumable(string[] action, string type, string name, int Id, int worth, int Hp, int level, List<string> status, List<string> flags, string rarity, string description)
    {
      Consumable newConsumable = new Consumable(action, type, name, Id, worth, Hp, level, status, flags, rarity, description);
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

  }
}
