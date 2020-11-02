using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public class Monster : Character
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string AbilityScores { get; set; }
    public Dictionary<string, string> Type { get; set; }
    public int CR { get; set; }
    public int HP { get; set; }
    public int MP { get; set; }
    public Status Status { get; set; }
    public string Inv { get; set; }
    public Equip Equip { get; set; }
    public int BaseAC { get; set; }
    public string Behaviors { get; set; }

    public Monster(int id, string name, string abilityScores, string mainType, int cr, int hp, int mp, string inv, string behaviors)
    {
      // super();
      this.Id = id;
      this.Name = name;
      this.AbilityScores = abilityScores;
      this.Type = new Dictionary<string, string>() { { "main", mainType } };
      this.CR = cr;
      this.HP = hp;
      this.MP = mp;
      this.Status = new Status();
      this.Inv = inv;
      this.Equip = new Equip();
      this.BaseAC = 10 + abilityScores.ScoreMod("Dex");
      this.Behaviors = behaviors;
    }
  }
}
