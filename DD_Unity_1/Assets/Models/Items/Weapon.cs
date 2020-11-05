using System;
using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public class Weapon : Item
  {
    public Weapon (string slot, string[] atk, string[] dam, string name, int id, int worth, int hp, int level, List<string> properties, List<string> flags, string rarity,string description) : base(name,id,worth,hp,level,properties,flags,rarity,description)
    {
      this.Atk = atk;
      this.Dam = dam;
      this.Slot = slot;
    }
  }
}