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
      this.roundCount = 1;
      this.turnOrder = TurnOrder;
      this.turnIndex = 0;
      this.loot = Loot;
    }

    combatTurn(object participant,object target)
    {
      // Display.output(`[${participant.name}'s turn!]`);
      // Display.output(`***<span class="purple">combatTurn function running.  ${participant.name}, is moving to attack target: ${target.name}***</span>`);
      if (participant.status.surprised == false)
      {
        int attack = participant.attackRoll();
        // Display.output(`${participant.name}'s ATK ROLL: ${attack} vs ${target.name}'s AC: ${target.baseAc}`);
        if (attack >= target.baseAc)
        {
          // Display.output(`<span class="red">*** HIT! ***</span>`);
          int damage = participant.damageRoll();
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
        return this.combatEnd(this.turnOrder);
      }
      if (this.turnIndex == (this.turnOrder.length -1))
      {
        return this.roundEnd(participant,target);
      }
      this.turnIndex += 1;
      return this.combatTurn(target,participant);
    }

    roundEnd(object participant, object target)
    {
    participant.status.hidden = false;
    participant.status.surprised = false;
    target.status.hidden = false;
    target.status.surprised = false;
    if (participant.type) 
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
    this.roundCount += 1;
    this.turnIndex = 0;
    }

    combatEnd(List<object> characterArray)
    {
    // console.log(`combatEnd has been triggered. characterArray: ${characterArray[0].name} and ${characterArray[1].name}`);
    this.deathCheck(characterArray);
    this.turnOrder = List<object>;
    this.roundCount = 1;
    // console.log(`combatEnd has been completed. this.turnOrder: ${this.turnOrder} and this.roundCount: ${this.roundCount} now, after resetting.`);
    }
  }
}