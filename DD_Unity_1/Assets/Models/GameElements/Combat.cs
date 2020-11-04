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
    public List<Item> Loot { get; set; }

    public Combat()
    {
      this.RoundCount = 1;
      this.TurnIndex = 0;
      this.Loot = new List<Item>();
    }

    public void CombatTurn(Character participant, Character target)
    {
      Environment current_location = TerminalManager.game.Environments[TerminalManager.game.Players[0].Location];
      Debug.Log("Start of turn. Participant HP: "+participant.HP+" target.HP: "+target.HP);
      Interpreter.DisplayOutput($"{participant.Name}'s turn!");
      Interpreter.DisplayOutput($"***combatTurn function running. {participant.Name}, is moving to attack target: {target.Name}***");
      if (participant.Status.Surprised == false)
      {
        //make attack roll
        int attack = participant.AttackRoll();
        // Display.output("${participant.Name}'s ATK ROLL: ${attack} vs ${target.Name}'s AC: ${target.BaseAc}");
        Interpreter.DisplayOutput($"{participant.Name}'s ATK ROLL: {attack} vs {target.Name}'s AC: {target.BaseAc}");
        if (attack >= target.BaseAc)
        {
          //make damage roll
          // Display.output("<span class="red">*** HIT! ***</span>");
          Interpreter.DisplayOutput($"*** HIT! ***");
          int damage = participant.DamageRoll();
          //inflict the damage
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
      //perform any remaining turn actions
      //check if dead
      if (participant.HP <= 0 || target.HP <= 0)
      {
        Debug.Log("Health dropped below zero. Participant HP: "+participant.HP+"target.HP: "+target.HP);
        Debug.Log("TerminalManager.game.Players[0].Name: "+ TerminalManager.game.Players[0].Name);
        Debug.Log("current_location.Monsters[0].Name: "+ current_location.Monsters[0].Name);
        Player player = TerminalManager.game.Players[0]; // new
        Monster monster = current_location.Monsters[0]; // new
        // this.CombatEnd(this.TurnOrder);
        this.CombatEnd(player, monster); // new
        return;
      }
      //check if all participants have had a turn
      Debug.Log("this.TurnIndex: "+this.TurnIndex);
      Debug.Log("this.TurnOrder.Count: "+this.TurnOrder.Count);
      if (this.TurnIndex == (this.TurnOrder.Count -1))
      {
        this.RoundEnd(participant,target);
        return;
      }
      //action the next participant's turn
      this.TurnIndex += 1;
      this.CombatTurn(target,participant);
      return;
    } // end turn

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

    // public void CombatEnd(Player player, Monster monster)
    // {
    //   // console.log("combatEnd has been triggered. characterArray: ${characterArray[0].name} and ${characterArray[1].name}");
    //   this.DeathCheck(player, monster);
    //   this.TurnOrder.Clear();
    //   this.RoundCount = 1;
    //   // console.log("combatEnd has been completed. this.turnOrder: ${this.turnOrder} and this.roundCount: ${this.roundCount} now, after resetting.");
    // }

    public void CombatEnd(Player player, Monster monster) // renamed from DeathCheck
    {
      this.TurnOrder.Clear();
      this.RoundCount = 1;
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
      // Debug.Log($"{characterArray[0].Name}");
      // Debug.Log($"{characterArray[1].Name}");
      // if (characterArray[0].HP <= 0 && characterArray[0].PClass != null)
      if (player.HP <= 0) // new
      {
        // return this.PlayerDeath(aliveCharacter,deadCharacter); //dunno why this was return
        // this.PlayerDeath(characterArray[1],characterArray[0]);
        Interpreter.DisplayOutput($"Bummer {player.Name}, you died to {monster.Name}!");
        player.Status.Dead = true;
        return;
      } 
      // else if (characterArray[1].HP <= 0 && characterArray[0].PClass == null)
      else if (monster.HP <=0) // new
      {
        // this.MonsterDeath(characterArray[0],characterArray[1]);
        Interpreter.DisplayOutput($"Congrats {player.Name}, you killed {monster.Name}!");
        monster.Status.Dead = true;
        this.Corpsification(monster);
      }
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
      Environment current_location = TerminalManager.game.Environments[TerminalManager.game.Players[0].Location];
      Interpreter.DisplayOutput($"{deadCharacter.Name} falls to the floor in a limp and bloody pile. Their life is now empty, but their pockets may be full! Loot corpse?");
      //create a container body item that will hold all of deadCharacter's inv and equip
      Container newCorpse = new Container("corpse", 100, $"Corpse of {deadCharacter.Name}", 6, 1 , 1, 1, new List<string>(), new List<string>(){"container"}, "common");
      //newCorpse.description = "The fresh corpse of a ${deadCharacter.MainType}."
      //move weapons into the environment
      if (deadCharacter.Equip["Main hand"][0] != null)
      {
        Debug.Log($"about to push the deadCharacter's weapon into the combat.loot. the weapon's name is: {deadCharacter.Equip["Main hand"][0].Name}");
        current_location.Items.Add(deadCharacter.Equip["Main hand"][0]);
      }
      else
      {
        Debug.Log("deadCharacter has no weapon to pass into the combat.loot. Moving onto corpsemaking");
      }
      //push items from deadCharacter into corpse
      Debug.Log("About to push items from deadCharacter into corpse");
      foreach (Item item in deadCharacter.Inv)
      {
        Debug.Log("Adding an item into the corpse. item.Name: " + item.Name);
        newCorpse.Contents.Add(item);
      }
      //push equip from deadCharacter into corpse
      Debug.Log("About to push equip from deadCharacter into corpse");
      foreach (KeyValuePair<string, Item[]> deadEquip in deadCharacter.Equip)
      {
        if (deadEquip.Value[0] != null) // MIGHT NOT WORK WITH RINGS
        {
          foreach (Item eqpiece in deadEquip.Value)
          {
            if (eqpiece != null)
            {
              Debug.Log("Adding an equipment into the corpse. deadEquip.Value.Name: " + deadEquip.Value[0].Name);
              newCorpse.Contents.Add(eqpiece);
            }
          }
        }
      }
      Debug.Log("start death remove loop");
      for (int i = 0; i < current_location.Monsters.Count; i++)
      {
        if (current_location.Monsters[i].Status.Dead == true)
        {
          current_location.Monsters.RemoveAt(i);
        } 
      }
      //push corpse into combat.loot for later migration into environment.items
      Debug.Log("About to push corpse into combat.loot for later migration into environment.items");
      current_location.Items.Add(newCorpse);
      // current_location.Monsters.Remove(deadCharacter);
      // if (current_location.Combat.Loot != null)
      //   {
      //     foreach (Item loot in current_location.Combat.Loot)
      //     {
      //       current_location.Items.Add(loot);
      //     }
      //     current_location.Combat.Loot.Clear();
      //   }
    }
  }
}