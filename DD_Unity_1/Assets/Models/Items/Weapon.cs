using System;
using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public class Weapon : Item
  {
    public string[] Atk { get; set; }
    public string[] Dam { get; set; }
    // public string Slot { get; set; }  

    public Weapon (string slot, string[] atk, string[] dam, string name, int id, int worth, int hp, int level, List<string> properties, List<string> flags, string rarity) : base(name,id,worth,hp,level,properties,flags,rarity)
    {
      this.Atk = atk;
      this.Dam = dam;
      this.Slot = slot;
    }
  }
}