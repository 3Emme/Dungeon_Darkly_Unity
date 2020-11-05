namespace Dungeon_Darkly
{
  public partial class Action
  {
    public static void Help()
    {
      Interpreter.DisplayOutput("<color=yellow>Hello adventurer! A little hooked are ya? No worries! Here's a list of commands that could be helpful!</color>");
      Interpreter.DisplayOutput("<color=yellow>Commands:</color>");
      Interpreter.DisplayOutput("<color=yellow><movement> -> type 'move'</color>");
      Interpreter.DisplayOutput("<color=yellow><sight-based> -> type 'look' (looks at room.) or type 'look at ___' to look at something specific.</color>");
      Interpreter.DisplayOutput("<color=yellow><combat> -> type 'attack *enemy*' or 'fight *enemy*' If an enemy is not specified, you will be asked what you're attacking.</color>");
      Interpreter.DisplayOutput("<color=yellow><looting> type 'loot corpse' when an enemy is defeated. If an item is present in the environment, type 'get item'</color>");
      Interpreter.DisplayOutput("<color=yellow><equip> type 'equip item' to equip an item to the appropriate slot on your character.</color>");
    }
  }
}
