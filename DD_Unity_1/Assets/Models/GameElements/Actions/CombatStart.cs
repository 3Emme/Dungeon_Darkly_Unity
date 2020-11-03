using System;
using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public partial class Action
  {
    //   public static void CombatStart(object participant, object target){
    //     let turnOrder = []; // d
    //      List<object> turnOrder = new List<object>{};
    //     // stealth-surprise check
    //     // if (this.status.some(status => status.hidden === true)){
    //     //   let stealthCheck = this.abilityScoreCheck('dex');
    //     //   let perceptionCheck = [target].abilityScoreCheck('wis');
    //     //   if (stealthCheck > perceptionCheck){
    //     //   [target].status.surprised = true;
    //     //   }
    //     // }
    //     // roll for initiative, fill turnOrder
    //     int participantInit = participant.AbilityScoreCheck("dex");
    //     int targetInit = target.AbilityScoreCheck("dex");
    //     Display.output(`---rolling combat initiative---<br>${participant.name}'s init roll = ${participantInit} / ${target.name}'s init roll = ${targetInit}`); //d
    //      Interpreter.DisplayOutput($"---rolling combat initiative---{participant.Name}'s init roll = {participantInit} / {target.Name}'s init roll = {targetInit});
    //     if (participantInit >= targetInit){
    //       turnOrder.Add(participant);
    //       turnOrder.Add(target);
    //     } else {
    //       turnOrder.Add(target);
    //       turnOrder.Add(participant);
    //     }
    //     string location = TerminalManager.game.Environments[participant.Location];
    //     // set the Combat turnOrder
    //     location.Combat.TurnOrder = turnOrder;
    //     // begin the combatTurn!
    //     location.Combat.CombatTurn(location.Combat.TurnOrder[0],location.Combat.TurnOrder[1]);
    //     //begin combat loot migration protocol
    //     if (location.Combat.Loot[0]){
    //       foreach (Item loot of location.Combat.Loot){
    //         location.Items.Add(loot);
    //       }
    //       location.Combat.Loot = [];
    //       // console.log(`environment items = ${location.items[0].name} and ${location.items[1].name} and ${location.items[2].name} and ${location.items[3].name} and ${location.items[4].name}. Inside of ${location.items[4].name}: ${location.items[4].contents[0].name}`);
    //       foreach (Monster combatMonster in location.Monsters){
    //         if (combatMonster.Status.Dead == true){
    //           location.Monsters = [];
    //           //remove this monster from location.monsters
    //         }
    //       }
    //     }
    //   } // end combatStart
  }
}

