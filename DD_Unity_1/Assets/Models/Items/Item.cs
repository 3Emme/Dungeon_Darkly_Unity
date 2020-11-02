using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public class Item 
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Worth { get; set; }
    public int Hp { get; set; }
    public int Level { get; set; }
    public Status Status { get; set; }
    public List<string> Flags { get; set; }
    public string Rarity { get; set; }

    public Item(string name,int Id, int worth,int Hp,int level,Status status,List<string> flags,string rarity)
    {
      this.Name = name;
      this.Id = id;
      this.Worth = id;
      this.Hp = hp;
      this.Level = level;
      this.Status = status;
      this.Flags = flags;
      this.Rarity = rarity;
    }
  }
}

