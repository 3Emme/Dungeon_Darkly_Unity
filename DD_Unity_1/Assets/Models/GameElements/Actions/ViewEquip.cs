using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public partial class Action
  {
    public static void ViewEquip()
    {
      Dictionary<string, Item[]> equipped = TerminalManager.game.Players[0].Equip;
      foreach (KeyValuePair<string, Item[]> entry in equipped)
      {
        string equip = "";
        if (entry.Value[0] != null)
        {
          equip = entry.Value[0].Name;
        }
        else
        {
          equip = "empty";
        }
        Interpreter.DisplayOutput($"{entry.Key}: {equip}");
      }
    }
  }
}
