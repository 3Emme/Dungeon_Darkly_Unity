using System.Reflection;

namespace Dungeon_Darkly
{
  public partial class Action
  {
    public static void ViewStats()
    {
      Player player = TerminalManager.game.Players[0];
      Interpreter.DisplayOutput($"***STATS***");
      Interpreter.DisplayOutput($"Name: {player.Name}");
      Interpreter.DisplayOutput($"Race: {player.Race}");
      Interpreter.DisplayOutput($"Class: {player.PClass} lvl {player.Level} XP: {player.XP}");
      Interpreter.DisplayOutput($"HP: {player.HP} MP: {player.MP}");
      Interpreter.DisplayOutput($"AC: {player.BaseAc}");
      // foreach (PropertyInfo prop in player.Status.GetType().GetProperties())
      // {
      //   if (prop.GetValue() == true)
      //   {
      //     Interpreter.DisplayOutput($"Afflicted by {prop}");
      //   }
      // }
    }
  }
}