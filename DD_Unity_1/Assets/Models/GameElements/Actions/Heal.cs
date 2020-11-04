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
      // // console.log("effectOrigin.name: ${ effectOrigin.name}, effectTarget: ${ effectTarget}, diceAmount: ${ diceAmount}, sideNumber: ${ sideNumber}, mod: ${ mod} ");
      // // console.log("typeof effectOrigin.name: ${ typeof effectOrigin.name}, typeof effectTarget: ${ typeof effectTarget}, typeof diceAmount: ${ typeof diceAmount}, typeof sideNumber: ${ typeof sideNumber}, typeof mod: ${ typeof mod} ");
      // // console.log("heal function activated");
      // Debug.Log("Heal function activated");
      // int healAmount = this.Roll(diceAmount, sideNumber, mod);
      // if (effectTarget == "self")
      // {
      //   // console.log("${ effectOrigin.name}'s HP is first ${effectOrigin.hp}");
      //   Debug.Log($"{effectOrigin.Name}'s HP is first {effectOrigin.HP}");
      //   effectOrigin.hp += healAmount;
      //   // console.log("${ effectOrigin.name} just healed by ${ healAmount}");
      //   Interpreter.DisplayOutput($"{effectOrigin.Name} was healed for {healAmount} points");
      //   // console.log("${ effectOrigin.name}'s HP is now ${effectOrigin.hp}");
      //   Debug.Log($"{effectOrigin.Name}'s HP is now {effectOrigin.HP}");
      //   // Display.displayCharStats(effectOrigin);
      // }
      // // console.log("heal function completed");
      // Debug.Log("heal function completed");
    }
  }
}