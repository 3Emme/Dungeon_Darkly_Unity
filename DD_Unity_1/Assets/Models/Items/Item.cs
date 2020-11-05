using System;
using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public abstract class Item 
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Worth { get; set; }
    public int Hp { get; set; }
    public int Level { get; set; }
    public string Type { get; set; }
    public List<string> Properties { get; set; }
    public List<string> Flags { get; set; }
    public string Rarity { get; set; }
    public string Slot { get; set; }
    public int AcBonus { get; set; }
    public string[] Atk { get; set; }
    public string[] Dam { get; set; }
    public string[] Action { get; set; }
    public List<Item> Contents { get; set; }

    public string Description { get; set; }

    public Item(string name, int id, int worth, int hp, int level, List<string> properties, List<string> flags, string rarity,string description)
    {
      this.Name = name;
      this.Id = id;
      this.Worth = worth;
      this.Hp = hp;
      this.Level = level;
      this.Properties = properties;
      this.Flags = flags;
      this.Rarity = rarity;
      this.Slot = null;
      this.AcBonus = 0;
      this.Atk = null;
      this.Dam = null;
      this.Action = null;
      this.Contents = null;
      this.Description = description;
    }
  }
}
