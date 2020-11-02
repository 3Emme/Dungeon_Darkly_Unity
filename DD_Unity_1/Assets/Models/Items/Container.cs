using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public class Container : Item
  {
    public string Type { get; set; }
    public LIst<object> Contents { get; set; }
    public int Capacity { get; set; }  

    public Weapon (string type, int capacity, string name,int id,int worth,int hp,int level,Status status,List<string> flags,string rarity) : base(name,id,worth,hp,level,status,flags,rarity)
    {
      this.Type = type;
      this.Contents = new List<object>() {};
      this.Capacity = capacity;
    }
  }
}