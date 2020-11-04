using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dungeon_Darkly
{
  public partial class Action
  {
    public static void Attack(string target)
    {
      Environment current_location = TerminalManager.game.Environments[TerminalManager.game.Players[0].Location];
      Character player = TerminalManager.game.Players[0];
      Character targetMonster = current_location.Monsters[0];
      // Monster targetMonster;
      bool targetFound = false;
      if (current_location.Combat.RoundCount == 1)
      {
        foreach (Monster monster in TerminalManager.game.Environments[TerminalManager.game.Players[0].Location].Monsters)
        {
          if (monster.Name.ToLower().Contains(target))
          {
            targetFound = true;
            targetMonster = monster;
          }
        }
        if (targetFound == false)
        {
          Interpreter.DisplayOutput("Attack what?");
          return;
        }
        Interpreter.DisplayOutput($"You join in battle with the {TerminalManager.game.Environments[TerminalManager.game.Players[0].Location].Monsters[0].Name}!");
        Action.CombatStart(player, targetMonster);
      }
      else
      {
        current_location.Combat.CombatTurn(current_location.Combat.TurnOrder[0], current_location.Combat.TurnOrder[1]);
        //begin combat loot migration protocol
        // if (current_location.Combat.Loot != null)
        // {
        //   foreach (Item loot in current_location.Combat.Loot)
        //   {
        //     current_location.Items.Add(loot);
        //   }
        //   current_location.Combat.Loot.Clear();
        // }
        // foreach (Monster combatMonster in current_location.Monsters)
        // {
        //   if (combatMonster.Status.Dead == true)
        //   {
        //     current_location.Monsters.Remove(combatMonster);
        //   }
        // }
        // Debug.Log("Attack - start death remove loop")
        // for (int i = 0; i > current_location.Monster.Count; i++)
        // {
        //   if (combatMonster.Status.Dead == true)
        //   {
        //     current_location.Monsters.RemoveAt(i);
        //   }
        // }
      }
    }
  }
}