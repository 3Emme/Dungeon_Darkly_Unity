using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dungeon_Darkly
{
  public class Combat
  {
    public int RoundCount { get; set; }
    public List<Character> TurnOrder { get; set; }
    public int TurnIndex { get; set; }
    public List<object> Loot { get; set; }

    public Combat()
    {
      this.RoundCount = 1;
      this.TurnIndex = 0;
    }

    public void CombatTurn(Character participant, Character target)
    {
      // Display.output("[${participant.Name}'s turn!]");
      Interpreter.DisplayOutput($"{participant.Name}'s turn!");
      // Display.output("***<span class="purple">combatTurn function running.  ${participant.Name}, is moving to attack target: ${target.Name}***</span>");
      Interpreter.DisplayOutput($"***combatTurn function running. {participant.Name}, is moving to attack target: {target.Name}***");
      if (participant.Status.Surprised == false)
      {
        int attack = participant.AttackRoll();
        // Display.output("${participant.Name}'s ATK ROLL: ${attack} vs ${target.Name}'s AC: ${target.BaseAc}");
        Interpreter.DisplayOutput($"{participant.Name}'s ATK ROLL: {attack} vs {target.Name}'s AC: {target.BaseAc}");
        if (attack >= target.BaseAc)
        {
          // Display.output("<span class="red">*** HIT! ***</span>");
          Interpreter.DisplayOutput($"*** HIT! ***");
          int damage = participant.DamageRoll();
          // Display.output("${participant.Name}'s DMG ROLL = ${damage}")
          Interpreter.DisplayOutput($"{participant.Name}'s DMG ROLL = {damage}");
          target.HP -= damage;
          // Display.output("${target.Name} took ${damage} damage, leaving them with ${target.HP} HP");
          Interpreter.DisplayOutput($"{target.Name} took {damage} damage, leaving them with {target.HP} HP");
        } 
        else 
        {
          Interpreter.DisplayOutput("*** MISS! ***");
        }
      }
      if (participant.HP <= 0 || target.HP <= 0)
      {
        this.CombatEnd(this.TurnOrder);
      }
      if (this.TurnIndex == (this.TurnOrder.Count -1))
      {
        this.RoundEnd(participant,target);
      }
      this.TurnIndex += 1;
      this.CombatTurn(target,participant);
    }

    public void RoundEnd(Character participant, Character target)
    {
      participant.Status.Hidden = false;
      participant.Status.Surprised = false;
      target.Status.Hidden = false;
      target.Status.Surprised = false;
      //display end of round options to player and await command
      // if (participant.Type != null) 
      // {
      //   Debug.Log("DISPLAY MONSTER TRUE");
      //   Display.displayMonsterStats(participant);
      //   Display.displayCharStats(target);
      // } 
      // else
      // {
      //   Display.displayMonsterStats(target);
      //   Display.displayCharStats(participant);
      // } 
      // Display.output("Combat round ${this.roundCount} has ended. Continue to <span class="cyan">fight</span>, or <span class="cyan">flee</span> instead?");
      Interpreter.DisplayOutput($"Combat round {this.RoundCount} has ended. Continue to fight, or flee instead?");
      this.RoundCount += 1;
      this.TurnIndex = 0;
    }

    public void CombatEnd(List<Character> characterArray)
    {
      // console.log("combatEnd has been triggered. characterArray: ${characterArray[0].name} and ${characterArray[1].name}");
      this.DeathCheck(characterArray);
      this.TurnOrder.Clear();
      this.RoundCount = 1;
      // console.log("combatEnd has been completed. this.turnOrder: ${this.turnOrder} and this.roundCount: ${this.roundCount} now, after resetting.");
    }

    public void DeathCheck(List<Character> characterArray)
    {
      // Debug.Log($"deathCheck has been triggered. characterArray: {characterArray[0].Name} and {characterArray[1].Name}");
      // Character deadCharacter;
      // Character aliveCharacter;
      // foreach (Character character in characterArray)
      // {
      //   if (character.HP <= 0)
      //   {
      //     deadCharacter = character;
      //   }
      //   if (character.HP >= 0)
      //   {
      //     aliveCharacter = character;
      //   }
      // }
      // Debug.Log($"deadCharacter: {deadCharacter.Name}, aliveCharacter: {aliveCharacter.Name}");
      Debug.Log($"{characterArray[0].Name}");
      if (characterArray[0].HP <= 0 && characterArray[0].PClass != null)
      {
        // return this.PlayerDeath(aliveCharacter,deadCharacter); //dunno why this was return
        // this.PlayerDeath(characterArray[1],characterArray[0]);
        Interpreter.DisplayOutput($"Bummer {TerminalManager.game.Players[0].Name}, you died to {TerminalManager.game.Monsters[0].Name}!");
        TerminalManager.game.Players[0].Status.Dead = true;
      } 
      else if (characterArray[1].HP <= 0 && characterArray[0].PClass == null)
      {
        // this.MonsterDeath(characterArray[0],characterArray[1]);
        Interpreter.DisplayOutput($"Congrats {TerminalManager.game.Players[0].Name}, you killed {TerminalManager.game.Monsters[0].Name}!");
        TerminalManager.game.Monsters[0].Status.Dead = true;
        this.Corpsification(TerminalManager.game.Monsters[0]);
      }


    //   for (let i = 0; i > characterArray.Count; i++)
    //   {        
    //     if (characterArray[i]<= 0)
    //     {
    //       if (characterArray[i] != null)
    //         {
    //           // return this.PlayerDeath(aliveCharacter,deadCharacter); //dunno why this was return
    //           this.PlayerDeath(aliveCharacter,characterArray[i]);
    //         } 
    //     } 
    //     else
    //     {
    //       this.MonsterDeath(aliveCharacter,characterArray[i]);
    //     }
        
    }

    // public void PlayerDeath(Character aliveCharacter, Character deadCharacter)
    // {
    //   Debug.Log($"playerDeath has been triggered. {deadCharacter.Name} died to {aliveCharacter.Name}");
    //   Interpreter.DisplayOutput($"Bummer {deadCharacter.Name}, you died to {aliveCharacter.Name}!");
    //   deadCharacter.Status.Dead = true;
    //   Debug.Log($"deadCharacter.Status.dead = {deadCharacter.Status.Dead}");

    //   // restartGame();
    // }

    // public void MonsterDeath(Character aliveCharacter, Character deadCharacter)
    // {
    //   Debug.Log($"monsterDeath has been triggered. {deadCharacter.Name} died to {aliveCharacter.Name}");
    //   Interpreter.DisplayOutput($"Congrats {aliveCharacter.Name}, you killed ${deadCharacter.Name}!");
    //   deadCharacter.Status.Dead = true;
    //   Debug.Log($"deadCharacter.Status.dead = {deadCharacter.Status.Dead}");
    //   //exp and etc that go to the player
    //   // Display.displayMonsterStats("none");
    //   this.Corpsification(deadCharacter);
    // }

    public void Corpsification(Character deadCharacter)
    {
      Interpreter.DisplayOutput($"{deadCharacter.Name} falls to the floor in a limp and bloody pile. Their life is now empty, but their pockets may be full! Loot corpse?");
      //create a container body item that will hold all of deadCharacter's inv and equip
      Container newCorpse = new Container("corpse",100,$"Corpse of {deadCharacter.Name}",6,1,1,1,new List<string>(),new List<string>(){"container"},"common");
      //newCorpse.description = "The fresh corpse of a ${deadCharacter.MainType}."
      //move weapons into the environment
      if (deadCharacter.Equip["MainHand"][0] != null)
      {
        Debug.Log($"about to push the deadCharacter's weapon into the combat.loot. the weapon's name is: {deadCharacter.Equip["Main hand"][0].Name}");
        this.Loot.Add(deadCharacter.Equip["Main hand"][0]);
      }
      else
      {
        Debug.Log("deadCharacter has no weapon to pass into the combat.loot. Moving onto corpsemaking");
      }
      //push items from deadCharacter into corpse
      foreach (Item item in deadCharacter.Inv)
      {
        newCorpse.Contents.Add(item);
      }
      //push equip from deadCharacter into corpse
      foreach (KeyValuePair<string, Item[]> deadEquip in deadCharacter.Equip)
      {
        foreach (Item eqpiece in deadEquip.Value)
        {
          newCorpse.Contents.Add(eqpiece);
        }
      }
      //push corpse into combat.loot for later migration into environment.items
      this.Loot.Add(newCorpse); 
    }
  }
}