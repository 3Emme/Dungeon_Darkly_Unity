using System;
using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public class Player : Character
  {
    public Player(string name, AbilityScores abilityScores, string race, string pClass, int level, int xp, int hp, int mp, int hunger, List<Item> inv)
    {
      this.Name = name;
      this.AbilityScores = abilityScores;
      this.Race = race;
      this.PClass = pClass;
      this.Level = level;
      this.XP = xp;
      this.HP = hp;
      this.MP = mp;
      this.Hunger = hunger;
      this.Status = new Status();
      this.Inv = inv;
      this.Equip = new Dictionary<string, Item[]>() 
      {
        {"Head",new Item[1]},
        {"Face",new Item[1]},
        {"Torso",new Item[1]},
        {"Back",new Item[1]},
        {"Neck",new Item[1]},
        {"Arm",new Item[1]},
        {"Hand",new Item[1]},
        {"Rings",new Item[2]},
        {"Body",new Item[1]},
        {"Waist",new Item[1]},
        {"Legs",new Item[1]},
        {"Main hand",new Item[1]},
        {"Off hand",new Item[1]}
      };
      this.BaseAc = 10 + abilityScores.ScoreMod("dex");
      this.Coordinates = new int[] { 0, 0, 0 };
      this.Location = 0;
    }

  }
}
