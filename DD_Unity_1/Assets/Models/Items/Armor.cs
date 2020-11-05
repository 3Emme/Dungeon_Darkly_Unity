using System;
using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public class Armor : Item
  {
    public Armor (string slot, int acBonus, string type, string name, int id, int worth, int hp, int level,List<string> properties,List<string> flags,string rarity,string description) : base(name,id,worth,hp,level,properties,flags,rarity,description)
    {
      this.AcBonus = acBonus;
      this.Type = type;
      this.Slot = slot;
    }
  }
}