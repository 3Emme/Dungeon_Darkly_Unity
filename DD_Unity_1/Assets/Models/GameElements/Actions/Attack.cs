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
      bool targetFound = false;
      if (current_location.Combat.RoundCount == 1)
      { //only works for one monster int the env
        if (current_location.Monsters[0].Name.ToLower().Contains(target))
        {
          targetFound = true;
          Interpreter.DisplayOutput($"You join in battle with the {current_location.Monsters[0].Name}!");
          Action.CombatStart(player, current_location.Monsters[0]);
        }
        if (targetFound == false)
        {
          Interpreter.DisplayOutput("Attack what?");
          return;
        }
      }
      else
      {
        current_location.Combat.CombatTurn(current_location.Combat.TurnOrder[0], current_location.Combat.TurnOrder[1]);
      }
    }
  }
}