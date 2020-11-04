using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dungeon_Darkly
{
  public partial class Action
  {
    public static void Heal(Character effectOrigin, string effectTarget, int diceAmount, int sideNumber, int mod)
    {
      // console.log("effectOrigin.name: ${ effectOrigin.name}, effectTarget: ${ effectTarget}, diceAmount: ${ diceAmount}, sideNumber: ${ sideNumber}, mod: ${ mod} ");
      // console.log("typeof effectOrigin.name: ${ typeof effectOrigin.name}, typeof effectTarget: ${ typeof effectTarget}, typeof diceAmount: ${ typeof diceAmount}, typeof sideNumber: ${ typeof sideNumber}, typeof mod: ${ typeof mod} ");
      Debug.Log("Heal function activated");
      int healAmount = TerminalManager.game.Roll(diceAmount, sideNumber, mod);
      if (effectTarget == "self")
      {
        Debug.Log($"{effectOrigin.Name}'s HP is first {effectOrigin.HP}");
        effectOrigin.HP += healAmount;
        // console.log("${ effectOrigin.name} just healed by ${ healAmount}");
        Interpreter.DisplayOutput($"{effectOrigin.Name} was healed for {healAmount} points");
        Debug.Log($"{effectOrigin.Name}'s HP is now {effectOrigin.HP}");
        // Display.displayCharStats(effectOrigin);
      }
      Debug.Log("heal function completed");
    }
  }
}