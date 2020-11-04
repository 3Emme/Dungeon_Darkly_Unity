using System;
using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public class Consumable : Item
  {
    public string[] Action { get; set; }    
    public string Type { get; set; }  

    public Consumable (string[] action, string type, string name, int id, int worth, int hp, int level, List<string> properties, List<string> flags, string rarity) : base(name,id,worth,hp,level,properties,flags,rarity)
    {
      this.Action = action;
      this.Type = type;      
    }
  }
}