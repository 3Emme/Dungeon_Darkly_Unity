namespace Dungeon_Darkly
{
  public partial class Action
  {
    public static void Help()
    {
      Interpreter.DisplayOutput("Hello adventurer! A little hooked are ya? No worries! Here's a list of commands that could be helpful!");
      Interpreter.DisplayOutput("Commands:");
      Interpreter.DisplayOutput("<movement> -> type 'move'");
      Interpreter.DisplayOutput("<sight-based> -> type 'look' (looks at room.) or type 'look at ___' to look at something specific.");
      Interpreter.DisplayOutput("<combat> -> type 'attack *enemy*' or 'fight *enemy*' If an enemy is not specified, you will be asked what you're attacking.");
      Interpreter.DisplayOutput("<looting> type 'loot corpse' when an enemy is defeated. If an item is present in the environment, type 'get item'");
      Interpreter.DisplayOutput("<equip> type 'equip item' to equip an item to the appropriate slot on your character.");
    }
  }
}

// help() {
//   Display.output(`<span class="white"><HELP FILE>
//   Hello adventurer! A little hooked are ya? No worries! Here's a list of commands that could be helpful!
//   <span class="cyan"><br>Commands:</span><br>
//   <movement> -> type "move"<br>
//   <sight-based> -> type "look" (looks at room.) or type "look at ___" to look at something specific.<br>
//   <combat> -> type "attack *enemy*" or "fight *enemy*" If an enemy is not specified, you will be asked what you're attacking.<br>
//   <looting> type "loot corpse" when an enemy is defeated. If an item is present in the environment, type "get item"<br>
//   <equip> type <equip item *body part*> to equip an item to the appropriate slot on your character.</span>`);
// }