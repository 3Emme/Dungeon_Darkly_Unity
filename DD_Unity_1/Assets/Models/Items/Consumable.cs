using System;
using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public class Consumable : Item
  {
    public Consumable (string[] action, string type, string name, int id, int worth, int hp, int level, List<string> properties, List<string> flags, string rarity,string description) : base(name,id,worth,hp,level,properties,flags,rarity,description)
    {
      this.Action = action;
      this.Type = type;      
    }
  }
}