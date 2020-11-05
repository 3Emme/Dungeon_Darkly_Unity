using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dungeon_Darkly
{
  public partial class Action
  {
    public static void CombatStart(Character participant, Character target)
    {
      List<Character> turnOrder = new List<Character>{};
      // stealth-surprise check
      // if (this.status.some(status => status.hidden === true)){
      //   let stealthCheck = this.abilityScoreCheck('dex');
      //   let perceptionCheck = [target].abilityScoreCheck('wis');
      //   if (stealthCheck > perceptionCheck){
      //   [target].status.surprised = true;
      //   }
      // }
      // roll for initiative, fill turnOrder
      int participantInit = participant.AbilityScoreCheck("dex");
      int targetInit = target.AbilityScoreCheck("dex");
      Interpreter.DisplayOutput($"---rolling combat initiative---{participant.Name}'s init roll = {participantInit} // {target.Name}'s init roll = {targetInit}");
      if (participantInit >= targetInit)
      {
        turnOrder.Add(participant);
        turnOrder.Add(target);
      } 
      else 
      {
        turnOrder.Add(target);
        turnOrder.Add(participant);
      }
      Environment location = TerminalManager.game.Environments[participant.Location];
      // set the Combat turnOrder
      location.Combat.TurnOrder = turnOrder;
      // begin the combatTurn!
      location.Combat.CombatTurn(location.Combat.TurnOrder[0],location.Combat.TurnOrder[1]);
    }

  }
}

