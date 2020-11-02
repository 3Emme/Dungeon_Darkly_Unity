using System;
using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public class Combat
  {
    public int RoundCount { get; set; }
    public List<object> TurnOrder { get; set; }
    public int TurnIndex { get; set; }
    public List<object> Loot { get; set; }

    public Combat()
    {
      this.RoundCount = 1;
      this.TurnOrder = TurnOrder;
      this.TurnIndex = 0;
      this.Loot = Loot;
    }

    public void CombatTurn(object participant, object target)
    {
      // Display.output(`[${participant.name}'s turn!]`);
      // Display.output(`***<span class="purple">combatTurn function running.  ${participant.name}, is moving to attack target: ${target.name}***</span>`);
      if (participant.status.surprised == false)
      {
        int attack = participant.AttackRoll();
        // Display.output(`${participant.name}'s ATK ROLL: ${attack} vs ${target.name}'s AC: ${target.baseAc}`);
        if (attack >= target.baseAc)
        {
          // Display.output(`<span class="red">*** HIT! ***</span>`);
          int damage = participant.DamageRoll();
          // Display.output(`${participant.name}'s DMG ROLL = ${damage}`);
          target.hp -= damage;
          // Display.output(`${target.name} took ${damage} damage, leaving them with ${target.hp} HP`);
        } 
        else 
        {
          // Display.output(`<span class="red">*** MISS! ***</span>`);
        }
      }
      if (participant.hp <= 0 || target.hp <= 0)
      {
        // return this.CombatEnd(this.turnOrder);
      }
      if (this.TurnIndex == (this.TurnOrder.length -1))
      {
        // return this.RoundEnd(participant,target);
      }
      this.TurnIndex += 1;
      // return this.CombatTurn(target,participant);
    }

    public void RoundEnd(object participant, object target)
    {
      participant.Status.Hidden = false;
      participant.Status.Surprised = false;
      target.Status.Hidden = false;
      target.Status.Surprised = false;
      if (participant.Type) 
      {
        // console.log("DISPLAY MONSTER TRUE");
        // Display.displayMonsterStats(participant);
        // Display.displayCharStats(target);
      } 
      else 
      {
        // Display.displayMonsterStats(target);
        // Display.displayCharStats(participant);
      } 
      // Display.output(`Combat round ${this.roundCount} has ended. Continue to <span class="cyan">fight</span>, or <span class="cyan">flee</span> instead?`);
      this.RoundCount += 1;
      this.TurnIndex = 0;
    }

    public void CombatEnd(List<object> characterArray)
    {
      // console.log(`combatEnd has been triggered. characterArray: ${characterArray[0].name} and ${characterArray[1].name}`);
      this.deathCheck(characterArray);
      this.TurnOrder = List<object>;
      this.RoundCount = 1;
      // console.log(`combatEnd has been completed. this.turnOrder: ${this.turnOrder} and this.roundCount: ${this.roundCount} now, after resetting.`);
    }
  }
}