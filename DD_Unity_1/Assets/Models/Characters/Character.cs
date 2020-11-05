using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dungeon_Darkly
{
  public abstract class Character
  {
    public string Name { get; set; }
    public AbilityScores AbilityScores { get; set; }
    public string Race { get; set; }
    public string PClass { get; set; }
    public int Level { get; set; }
    public int XP { get; set; }
    public int HP { get; set; }
    public int MP { get; set; }
    public int Hunger { get; set; }
    public Status Status { get; set; }
    public List<Item> Inv { get; set; }
    public Dictionary<string, Item[]> Equip { get; set; }
    public int BaseAc { get; set; }
    public int[] Coordinates { get; set; }
    public int Location { get; set; }
    public int Id { get; set; }
    public Dictionary<string, string> Type { get; set; }
    public List<string> Behaviors { get; set; }

    public void AddItemInv(Item item)
    {
      this.Inv.Add(item);
    }

    public void AddItemEquip(Item item)
    {
      this.Equip[item.Slot][0] = item;
    }

    public int Roll(int num, int side, int mod)
    {
      System.Random _random = new System.Random();
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
      System.Random _random = new System.Random();
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
      // int scoreChecked = this.AbilityScores[score];

      System.Reflection.PropertyInfo temp = this.AbilityScores.GetType().GetProperty(score);
      int scoreChecked = (int)(temp.GetValue(this.AbilityScores, null));

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
      Debug.Log("AbilityScoreCheck triggered");
      int mod = this.AbilityScores.ScoreMod(score);
      return this.Roll(1, 20, mod);
    }

    public void EquipCheck()
    {
      int totalAcBonus = 0;
      foreach (KeyValuePair<string, Item[]> equipment in this.Equip)
      {
        if (equipment.Value[0] != null)
        {
          foreach (Item eqpiece in equipment.Value)
          {
            if (eqpiece.Flags.Contains("armor"))
            {
              totalAcBonus += eqpiece.AcBonus;
            }
          }
        }
      }
      this.BaseAc += totalAcBonus;
    }

    public void XPCheck()
    {
      Debug.Log("XP CHECK START");
      
      Debug.Log(XP);
      int N = this.Level+1;
      if (this.XP >= N*(N-1)*500)
      {
        Debug.Log("levelup");
        Action.LevelUp();
      }
    }

    public int AttackRoll()
    {
      Item weapon;
      int attackMod;
      if (this.Equip["Main hand"][0] != null)
      {
        weapon = this.Equip["Main hand"][0];
        attackMod = this.AbilityScores.ScoreMod(weapon.Atk[0]) + Int32.Parse(weapon.Atk[1]) + this.Level;
      }
      else
      {
        attackMod = this.AbilityScores.ScoreMod("str") + this.Level;
      }
      return this.Roll(1, 20, attackMod);
    }

    public int DamageRoll()
    {
      Item weapon;
      int damageMod;
      int damageDiceNumber;
      int damageDiceSides;
      if (this.Equip["Main hand"][0] != null)
      {
        weapon = this.Equip["Main hand"][0];
        damageMod = this.AbilityScores.ScoreMod(weapon.Atk[0]);
        damageDiceNumber = Int32.Parse(weapon.Dam[0]);
        damageDiceSides = Int32.Parse(weapon.Dam[2]);
      }
      else
      {
        damageMod = this.AbilityScores.ScoreMod("str");
        damageDiceNumber = 1;
        damageDiceSides = 4;
      }
      return this.Roll(damageDiceNumber, damageDiceSides, damageMod);
    }

    public void Hide()
    {
      this.Status.Hidden = true;
    }
  }
}