namespace Dungeon_Darkly
{
  public partial class Action
  {
    public static void ViewInventory()
    {
      if (TerminalManager.game.Players[0].Inv.Count == 0)
      {
        Interpreter.DisplayOutput("Inventory is empty");
      } 
      else
      {
        Interpreter.DisplayOutput("Your Inventory:");
        foreach (Item thing in TerminalManager.game.Players[0].Inv)
        {
          Interpreter.DisplayOutput($"- {thing.Name}");
        }
      }
    }
  }
}