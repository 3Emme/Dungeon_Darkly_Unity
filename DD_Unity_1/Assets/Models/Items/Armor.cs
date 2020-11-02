using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public class Armor : Item
  {
    public int AcBonus { get; set; }
    public string Type { get; set; }
    public string Slot { get; set; }  

    public Weapon (string slot, string acBonuc,string type, string name,int id,int worth,int hp,int level,Status status,List<string> flags,string rarity) : base(name,id,worth,hp,level,status,flags,rarity)
    {
      this.AcBonus = atk;
      this.Type = type;
      this.Slot = slot;
    }
  }
}