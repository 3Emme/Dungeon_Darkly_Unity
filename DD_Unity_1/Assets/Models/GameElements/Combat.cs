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
      Interpreter.DisplayOutput($"{participant.Name}'s turn!");
      Interpreter.DisplayOutputColor($"***combatTurn function running. {participant.Name}, is moving to attack target: {target.Name}***","orange");
      if (participant.Status.Surprised == false)
      {
        //make attack roll
        int attack = participant.AttackRoll();
        Interpreter.DisplayOutput($"{participant.Name}'s ATK ROLL: {attack} vs {target.Name}'s AC: {target.BaseAc}");
        if (attack >= target.BaseAc)
        {
          //make damage roll
          // Interpreter.DisplayOutput($"<color=red>*** HIT! ***</color>");
          Interpreter.DisplayOutputColor("<size=50>*** HIT! ***</size>","red");
          int damage = participant.DamageRoll();
          //inflict the damage
          Interpreter.DisplayOutput($"{participant.Name}'s DMG ROLL = {damage}");
          target.HP -= damage;
          Interpreter.DisplayOutput($"{target.Name} took {damage} damage, leaving them with {target.HP} HP");
        } 
        else 
        {
          Interpreter.DisplayOutputColor("<size=50>*** MISS! ***</size>","red");
        }
      }
      if (participant.HP <= 0 || target.HP <= 0)
      {
        Player player = TerminalManager.game.Players[0];
        Monster monster = current_location.Monsters[0];
        this.CombatEnd(player, monster);
        return;
      }
      if (this.TurnIndex == (this.TurnOrder.Count -1))
      {
        this.RoundEnd(participant,target);
        return;
      }
      this.TurnIndex += 1;
      this.CombatTurn(target,participant);
      return;
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

    public void CombatEnd(Player player, Monster monster)
    {
      this.TurnOrder.Clear();
      this.RoundCount = 1;
      if (player.HP <= 0)
      {
        Interpreter.DisplayOutput($"Bummer {player.Name}, you died to {monster.Name}!");
        player.Status.Dead = true;
        Interpreter.DisplayOutput("<size=100>***** GAME OVER *****</size>");
        Game newGame = GameInit.GetGame();
        Player player1 = newGame.AddPlayer("P name", "P race", "P class", 1, 0, 10, 10, 0, new List<Item>(), 10, 10, 10, 10, 10, 10, 10);
        newGame.Environments[0].Players.Add(player1);
        newGame.Players.Add(player1);
        TerminalManager.game = newGame;

        return;
      } 
      else if (monster.HP <=0)
      {
        Interpreter.DisplayOutput($"Congrats {player.Name}, you killed {monster.Name}!");
        monster.Status.Dead = true;
        this.Corpsification(monster);
      }
    }

    public void Corpsification(Character deadCharacter)
    {
      Environment current_location = TerminalManager.game.Environments[TerminalManager.game.Players[0].Location];
      Interpreter.DisplayOutput($"{deadCharacter.Name} falls to the floor in a limp and bloody pile. Their life is now empty, but their pockets may be full! Loot corpse?");
      Container newCorpse = new Container("corpse", 100, $"Corpse of {deadCharacter.Name}", 6, 1 , 1, 1, new List<string>(), new List<string>(){"container"}, "common");
      //newCorpse.description = "The fresh corpse of a ${deadCharacter.MainType}."
      //move weapons into the environment
      if (deadCharacter.Equip["Main hand"][0] != null)
      {
        current_location.Items.Add(deadCharacter.Equip["Main hand"][0]);
      }
      foreach (Item item in deadCharacter.Inv)
      {
        newCorpse.Contents.Add(item);
      }
      foreach (KeyValuePair<string, Item[]> deadEquip in deadCharacter.Equip)
      {
        if (deadEquip.Value[0] != null) // MIGHT NOT WORK WITH RINGS
        {
          foreach (Item eqpiece in deadEquip.Value)
          {
            if (eqpiece != null)
            {
              newCorpse.Contents.Add(eqpiece);
            }
          }
        }
      }
      for (int i = 0; i < current_location.Monsters.Count; i++)
      {
        if (current_location.Monsters[i].Status.Dead == true)
        {
          current_location.Monsters.RemoveAt(i);
        } 
      }
      current_location.Items.Add(newCorpse);
    }
  }
}