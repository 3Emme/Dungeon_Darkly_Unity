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
    public Equip Equip { get; set; }
    public int BaseAc { get; set; }
    public int[] Coordinates { get; set; }

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
      this.Equip = new Equip();
      this.BaseAc = 10 + abilityScores.ScoreMod("dex");
      this.Coordinates = new int[] { 0, 0, 0 };
    }
        //Below are the things originally inherited from character class
    // public void AddItemInv(Item item)
    // {
    //   this.Inv.Add(item);
    // }

    // public void AddItemEquip(Item item)
    // {
    //   // let slot = item.Slot;
    //   this.Equip[item.Slot].Add(item);
    // }

    // public int Roll(int num, int side, int mod, int adj)
    // {
    //   Random _random = new Random();
    //   int total;
    //   if (!mod)
    //   {
    //     total = 0;
    //   }
    //   else
    //   {
    //     total = mod;
    //   }
    //   int min;
    //   if (!adj)
    //   {
    //     min = 1;
    //   }
    //   else
    //   {
    //     min = 1 + adj;
    //   }
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
    //   AbilityScores abilityScores = this.abilityScores;
    //   int scoreChecked = abilityScores[score];
    //   if (scoreChecked >= target)
    //   {
    //     return true;
    //   }
    //   else
    //   {
    //     return false;
    //   }
    // }

    // public int AbilityScoreCheck(int score)
    // {
    //   AbiliyScores abilityScores = this.abilityScores;
    //   int mod = abilityScores.scoreMod[score];
    //   return this.Roll(1, 20, mod);
    // }

    // public void EquipCheck()
    // {
    //   int totalAcBonus = 0;
    //   foreach (var equipSlot in this.equip)
    //   {
    //     foreach (var eqpiece in this.equip[equipSlot])
    //     {
    //       totalAcBonus += eqpiece.acBonus;
    //     }
    //   }
    //   this.baseAc += totalAcBonus;
    // }

    // public int AttackRoll()
    // {
    //   Weapon weapon;
    //   int attackMod;
    //   if (this.equip.mainHand[0])
    //   {
    //     weapon = this.equip.mainHand[0];
    //     attackMod = this.abilityScores.scoreMod[weapon.atk[0]] + weapon.atk[1] + this.level;
    //   }
    //   else
    //   {
    //     attackMod = this.abilityScores.ScoreMod("str") + this.level;
    //   }
    //   return this.Roll(1, 20, attackMod);
    // }

    // public int DamageRoll()
    // {
    //   Weapon weapon;
    //   int damageMod;
    //   int damageDiceNumber;
    //   int damageDiceSides;
    //   if (this.equip.mainHand[0])
    //   {
    //     weapon = this.equip.mainHand[0];
    //     damageMod = this.abilityScores.scoreMod[weapon.atk[0]];
    //     damageDiceNumber = weapon.dam[0];
    //     damageDiceSides = weapon.dam[2];
    //   }
    //   else
    //   {
    //     damageMod = this.abilityScores.ScoreMod("str");
    //     damageDiceNumber = 1;
    //     damageDiceSides = 4;
    //   }
    //   return this.Roll(damageDiceNumber, damageDiceSides, damageMod);
    // }

    // public void Hide()
    // {
    //   this.Status.hidden = "true";
    // }

  }
}
