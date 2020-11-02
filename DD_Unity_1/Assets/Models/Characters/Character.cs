using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public class Character
  {
    public void AddItemInv(Item item)
    {
      this.Inv.Add(item);
    }

    public void AddItemEquip(Item item)
    {
      // let slot = item.Slot;
      this.Equip[item.Slot].Add(item);
    }

    public int roll(int num, int side, int mod, int adj)
    {
      Random _random = new Random();
      int total;
      if (!mod)
      {
        total = 0;
      }
      else
      {
        total = mod;
      }
      int min;
      if (!adj)
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

    public bool AbilityScoreMatch(string score, int target)
    {
      AbilityScores abilityScores = this.abilityScores;
      int checked = abilityScores[score];
      if (checked >= target){
        return true;
      }
      else
      {
        return false;
      }
    }

    public int AbilityScoreCheck(int score)
    {
      AbiliyScores abilityScores = this.abilityScores;
      int mod = abilityScores.scoreMod[score];
      return this.roll(1, 20, mod);
    }

    public void EquipCheck()
    {
      int totalAcBonus = 0;
      foreach (var equipSlot in this.equip)
      {
        foreach (var eqpiece in this.equip[equipSlot])
        {
          totalAcBonus += eqpiece.acBonus;
        }
      }
      this.baseAc += totalAcBonus;
    }

    public int AttackRoll()
    {
      Weapon weapon;
      int attackMod;
      if (this.equip.mainHand[0])
      {
        weapon = this.equip.mainHand[0];
        attackMod = this.abilityScores.scoreMod[weapon.atk[0]] + weapon.atk[1] + this.level;
      }
      else
      {
        attackMod = this.abilityScores.scoreMod("str") + this.level;
      }
      return this.roll(1, 20, attackMod);
    }

    public int DamageRoll()
    {
      Weapon weapon;
      int damageMod;
      int damageDiceNumber;
      int damageDiceSides;
      if (this.equip.mainHand[0])
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
      return this.roll(damageDiceNumber, damageDiceSides, damageMod);
    }

    public void Hide()
    {
      this.Status.hidden = "true";
    }
  }
}

