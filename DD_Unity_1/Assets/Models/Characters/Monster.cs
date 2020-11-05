using System;
using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public class Monster : Character
  {
    public Monster(int id, string name, AbilityScores abilityScores, string mainType, int level, int hp, int mp, List<Item> inv, List<string> behaviors, string description)
    {
      // super();
      this.Id = id;
      this.Name = name;
      this.AbilityScores = abilityScores;
      this.Type = new Dictionary<string, string>() { { "main", mainType } };
      this.Level = level;
      this.HP = hp;
      this.MP = mp;
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
      this.BaseAc = 10 + abilityScores.ScoreMod("Dex");
      this.Behaviors = behaviors;
      this.Description = description;
    }
  }
}
