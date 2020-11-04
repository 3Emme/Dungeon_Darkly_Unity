using System;
using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public class Player
  {
    public string Name { get; set; }
    public AbilityScores AbilityScores { get; set; }
    public string Race { get; set; }
    public string PClass { get; set; }
    public int Level { get; set; }
    public int Xp { get; set; }
    public int Hp { get; set; }
    public int Mp { get; set; }
    public int Hunger { get; set; }
    public Status Status { get; set; }
    public List<Item> Inv { get; set; }
    public Dictionary<string, Item[]> Equip { get; set; }
    public int BaseAc { get; set; }
    public int[] Coordinates { get; set; }

    public int Location { get; set; }

    public Player(string name, AbilityScores abilityScores, string race, string pClass, int level, int xp, int hp, int mp, int hunger, List<Item> inv)
    {
      this.Name = name;
      this.AbilityScores = abilityScores;
      this.Race = race;
      this.PClass = pClass;
      this.Level = level;
      this.Xp = xp;
      this.Hp = hp;
      this.Mp = mp;
      this.Hunger = hunger;
      this.Inv = inv;
      // this.Equip = new Equip();
      this.Equip = new Dictionary<string, Item[]>() 
      {
        {"head",new Item[1]},
        {"face",new Item[1]},
        {"torso",new Item[1]},
        {"back",new Item[1]},
        {"neck",new Item[1]},
        {"arm",new Item[1]},
        {"hand",new Item[1]},
        {"rings",new Item[2]},
        {"body",new Item[1]},
        {"waist",new Item[1]},
        {"legs",new Item[1]},
        {"mainHand",new Item[1]},
        {"offHand",new Item[1]}
      };
      this.BaseAc = 10 + abilityScores.ScoreMod("dex");
      this.Coordinates = new int[] { 0, 0, 0 };
      this.Location = 0;
    }
        //Below are the things originally inherited from character class
    // public void AddItemInv(Item item)
    // {
    //   this.Inv.Add(item);
    // }

    public void AddItemEquip(Item item)
    {
      // let slot = item.Slot;
      this.Equip[item.Slot][0] = item;
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

    public bool AbilityScoreMatch(string score, int target)
    {
      int scoreChecked = this.AbilityScores[score];
      if (scoreChecked >= target)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public int AbilityScoreCheck(string score)
    {
      int mod = this.AbilityScores.ScoreMod(score);
      return this.Roll(1, 20, mod);
    }

    public void EquipCheck()
    {
      int totalAcBonus = 0;
      foreach (KeyValuePair<string, Item[]> equipment in this.Equip)
      {
        foreach (Item eqpiece in equipment.Value)
        {
          totalAcBonus += eqpiece.acBonus;
        }
      }
      this.BaseAc += totalAcBonus;
    }

    public int AttackRoll()
    {
      Weapon weapon;
      int attackMod;
      if (this.equip.mainHand[0])
      {
        weapon = this.equip.mainHand[0];
        attackMod = this.AbilityScores.ScoreMod[weapon.atk[0]] + weapon.atk[1] + this.level;
      }
      else
      {
        attackMod = this.AbilityScores.ScoreMod("str") + this.level;
      }
      return this.Roll(1, 20, attackMod);
    }

    public int DamageRoll()
    {
      Weapon weapon;
      int damageMod;
      int damageDiceNumber;
      int damageDiceSides;
      if (this.Equip["mainHand"][0])
      {
        weapon = this.equip.mainHand[0];
        damageMod = this.abilityScores.scoreMod[weapon.atk[0]];
        damageDiceNumber = weapon.dam[0];
        damageDiceSides = weapon.dam[2];
      }
      else
      {
        damageMod = this.abilityScores.ScoreMod("str");
        damageDiceNumber = 1;
        damageDiceSides = 4;
      }
      return this.Roll(damageDiceNumber, damageDiceSides, damageMod);
    }

    public void Hide()
    {
      this.Status.Hidden = "true";
    }

  }
}
