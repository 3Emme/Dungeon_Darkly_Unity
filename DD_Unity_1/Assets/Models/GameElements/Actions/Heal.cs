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
      int healAmount = TerminalManager.game.Roll(diceAmount, sideNumber, mod);
      if (effectTarget == "self")
      {
        effectOrigin.HP += healAmount;
        Interpreter.DisplayOutputColor($"[+] {effectOrigin.Name} was healed for {healAmount} points","#FF00E5");
        // Display.displayCharStats(effectOrigin);
      }
    }
  }
}