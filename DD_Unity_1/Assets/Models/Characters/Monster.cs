using System;
using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public class Monster : Character
  {
    // public int Id { get; set; }
    // public string Name { get; set; }
    // public AbilityScores AbilityScores { get; set; }
    // public Dictionary<string, string> Type { get; set; }
    // public int Level { get; set; }
    // public int HP { get; set; }
    // public int MP { get; set; }
    // public Status Status { get; set; }
    // public List<Item> Inv { get; set; }
    // public Dictionary<string, Item[]> Equip { get; set; }
    // public int BaseAc { get; set; }
    // public List<string> Behaviors { get; set; }

    public Monster(int id, string name, AbilityScores abilityScores, string mainType, int level, int hp, int mp, List<Item> inv, List<string> behaviors)
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
    }
    //Below are the things originally inherited from character class
    // public void AddItemInv(Item item)
    // {
    //   this.Inv.Add(item);
    // }

    // public void AddItemEquip(Item item)
    // {
    //   // let slot = item.Slot;
    //   this.Equip[item.Slot][0] = item;
    // }

    // public int Roll(int num, int side, int mod)
    // {
    //   Random _random = new Random();
    //   int total = mod;
    //   int min = 1;
    //   for (int i = 0; i < num; i++)
    //   {
    //     // int roll = ((min-1) + Math.ceil(Math.random() * (side-min + 1)));
    //     int roll = _random.Next(min, (side + min));
    //     total += roll;
    //   }
    //   if (total < num)
    //   {
    //     total = num;
    //   }
    //   return total;
    // }

    // public int Roll(int num, int side, int mod, int adj)
    // {
    //   Random _random = new Random();
    //   int total = mod;
    //   int min = 1 + adj;
    //   for (int i = 0; i < num; i++)
    //   {
    //     // int roll = ((min-1) + Math.ceil(Math.random() * (side-min + 1)));
    //     int roll = _random.Next(min, (side + min));
    //     total += roll;
    //   }
    //   if (total < num)
    //   {
    //     total = num;
    //   }
    //   return total;
    // }

    // public bool AbilityScoreMatch(string score, int target)
    // {
    //   // int scoreChecked = this.AbilityScores[score];

    //   System.Reflection.PropertyInfo temp = this.AbilityScores.GetType().GetProperty(score);
    //   int scoreChecked = (int)(temp.GetValue(this.AbilityScores, null));

    //   if (scoreChecked >= target)
    //   {
    //     return true;
    //   }
    //   else
    //   {
    //     return false;
    //   }
    // }

    // public int AbilityScoreCheck(string score)
    // {
    //   int mod = this.AbilityScores.ScoreMod(score);
    //   return this.Roll(1, 20, mod);
    // }

    // public void EquipCheck()
    // {
    //   int totalAcBonus = 0;
    //   foreach (KeyValuePair<string, Item[]> equipment in this.Equip)
    //   {
    //     foreach (Item eqpiece in equipment.Value)
    //     {
    //       totalAcBonus += eqpiece.AcBonus;
    //     }
    //   }
    //   this.BaseAc += totalAcBonus;
    // }

    // public int AttackRoll()
    // {
    //   Item weapon;
    //   int attackMod;
    //   if (this.Equip["Main hand"][0] != null)
    //   {
    //     weapon = this.Equip["Main hand"][0];
    //     attackMod = this.AbilityScores.ScoreMod(weapon.Atk[0]) + Int32.Parse(weapon.Atk[1]) + this.Level;
    //   }
    //   else
    //   {
    //     attackMod = this.AbilityScores.ScoreMod("str") + this.Level;
    //   }
    //   return this.Roll(1, 20, attackMod);
    // }

    // public int DamageRoll()
    // {
    //   Item weapon;
    //   int damageMod;
    //   int damageDiceNumber;
    //   int damageDiceSides;
    //   if (this.Equip["Main hand"][0] != null)
    //   {
    //     weapon = this.Equip["Main hand"][0];
    //     damageMod = this.AbilityScores.ScoreMod(weapon.Atk[0]);
    //     damageDiceNumber = Int32.Parse(weapon.Dam[0]);
    //     damageDiceSides = Int32.Parse(weapon.Dam[2]);
    //   }
    //   else
    //   {
    //     damageMod = this.AbilityScores.ScoreMod("str");
    //     damageDiceNumber = 1;
    //     damageDiceSides = 4;
    //   }
    //   return this.Roll(damageDiceNumber, damageDiceSides, damageMod);
    // }

    // public void Hide()
    // {
    //   this.Status.Hidden = true;
    // }
  }
}
