namespace Dungeon_Darkly
{
  public partial class Action
  {
      public static void Get(string target)
      {
      bool gotAThing = false;
      Environment current_location = TerminalManager.game.Environments[TerminalManager.game.Players[0].Location];
        for (int i=0;i<current_location.Items.Count;i++)
        {
          if (current_location.Items[i].Name.ToLower().Contains(target))
          {
            Interpreter.DisplayOutput($"[+] You pick up the {current_location.Items[i].Name}");
            TerminalManager.game.Players[0].Inv.Add(current_location.Items[i]);
            current_location.Items.RemoveAt(i);
            gotAThing = true;
            break;
          }
        }
        if (!gotAThing)
        {
          Interpreter.DisplayOutput($"You didn't find {target}");
        }
        // Action.UpdateInvDisplay(); 
      }
  }
}
