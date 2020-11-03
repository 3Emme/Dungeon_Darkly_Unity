namespace Dungeon_Darkly
{
  public partial class Action
  {
      public static void Get(string target)
      {
        Environment current_location = TerminalManager.game.Environments[TerminalManager.game.Players[0].Location];
        for (int i=0;i<current_location.Items.Count;i++)
        {
          if (current_location.Items[i].Name.ToLower().Contains(target))
          {
            //this.look("")
            // Display.output(`[+] You pick up the ${current_location.items[i].name}`);
            Interpreter.DisplayOutput($"[+] You pick up the {current_location.Items[i].Name}");
            TerminalManager.game.Players[0].Inv.Add(current_location.Items[i]);
            current_location.Items.RemoveAt(i);
            // current_location.Items.splice(i,1);
            // console.log("location items:", current_location.Items);
            // console.log("INV", TerminalManager.game.players[0].Inv);
            // current_location.items = newArray
            break;
          }
        }
        // Action.UpdateInvDisplay(); 
      }
  }
}
