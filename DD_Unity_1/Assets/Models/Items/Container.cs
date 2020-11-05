using System;
using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public class Container : Item
  {
    public int Capacity { get; set; }  

    public Container (string type, int capacity, string name,int id,int worth,int hp,int level,List<string> properties,List<string> flags,string rarity,string description) : base(name,id,worth,hp,level,properties,flags,rarity,description)
    {
      this.Type = type;
      this.Contents = new List<Item>();
      this.Capacity = capacity;
    }
  }
}