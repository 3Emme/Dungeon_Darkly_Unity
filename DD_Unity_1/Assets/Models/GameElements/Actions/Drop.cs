using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public partial class Action
  {
    public static void Drop(string target)
    {
      List<Item> inventory = TerminalManager.game.Players[0].Inv;
      Environment current_location = TerminalManager.game.Environments[TerminalManager.game.Players[0].Location];
      for (int i=0; i<inventory.Count; i++)
      {
        if (inventory[i].Name.ToLower().Contains(target))
        {
          Interpreter.DisplayOutputColor($"[+] You drop {inventory[i].Name} to the ground!","#FF00E5");
          current_location.Items.Add(inventory[i]);
          inventory.RemoveAt(i);
          return;
        }
      }
      Interpreter.DisplayOutput($"[-] Drop what?");
    } 
  }
} 