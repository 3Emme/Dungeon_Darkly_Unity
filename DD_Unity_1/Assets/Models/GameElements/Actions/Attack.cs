using System;
using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public partial class Action
  {
    // public static void Attack(string target)
    // {
    //   string location = TerminalManager.game.Environments[TerminalManager.game.Players[0].Location];
    //   if (location.Combat.RoundCount == 1)
    //   {
    //     Monster targetMonster;
    //     foreach (Monster monster in TerminalManager.game.Environments[TerminalManager.game.Players[0].Location].Monsters)
    //     {
    //       if (monster.Name.ToLower().includes(target))
    //       {
    //         targetMonster = monster;
    //       }
    //     }
    //     Interpreter.DisplayOutput($"You join in battle with the {TerminalManager.game.Environments[TerminalManager.game.Players[0].Location].Monsters[0].Name}!");
    //     TerminalManager.game.CombatStart(TerminalManager.game.Environments[TerminalManager.game.Players[0].Location].Players[0], targetMonster);
    //   }
    //   else
    //   {
    //     location.Combat.CombatTurn(location.Combat.TurnOrder[0], location.Combat.TurnOrder[1]);
    //     if (location.Combat.Loot[0])
    //     {
    //       foreach (Item loot in location.Combat.Loot)
    //       {
    //         location.Items.Add(loot);
    //       }
    //     }
    //     location.Combat.Loot.Clear();
    //     foreach (Monster combatMonster in location.Monsters)
    //     {
    //       if (combatMonster.Status.Dead == true)
    //       {
    //         location.monsters = [];
    //       }
    //     }
    //   }
    // }
  }
}