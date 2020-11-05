using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public partial class Action
  {
    public static void Unequip(string target)
    {
      Player player = TerminalManager.game.Players[0];
      foreach (KeyValuePair<string, Item[]> thing in player.Equip)
      {
        if (thing.Value[0] != null && thing.Value[0].Name.ToLower().Contains(target))
        {
          Interpreter.DisplayOutput($"[+] You unequip {thing.Value[0].Name} to your inventory");
          player.Inv.Add(thing.Value[0]);
          thing.Value[0] = null;
          return;
        }
      }
      Interpreter.DisplayOutput($"[-] Can't find {target} to unequip");
    }
  }
} 