using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public class Weapon : Item
  {
    public int Atk { get; set; }
    public int Dam { get; set; }
    public string Slot { get; set; }  

    public Weapon (string slot, int atk,int dam, string name,int id,int worth,int hp,int level,Status status,List<string> flags,string rarity) : base(name,id,worth,hp,level,status,flags,rarity)
    {
      this.Atk = atk;
      this.Dam = dam;
      this.Slot = slot;
    }
  }
}