using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public class Player : Character
  {
    public string Name { get; set; }
    public AbilityScore AbilityScores { get; set; }
    public string Race { get; set; }
    public string PClass { get; set; }
    public int Level { get; set; }
    public int Xp { get; set; }
    public int Hp { get; set; }
    public int Mp { get; set; }
    public Status Status { get; set; }
    public int hunger { get; set; }
    public List<Object> Inv { get; set; }
    public Equip Equip { get; set; }
    public int BaseAc { get; set; }
    public int[] Coordinates { get; set; }

    public Player(string name, AbilityScore abilityScores, string race, string pclass, int level, int xp, int hp, int mp, int hunger, List<object> inv)
    {
      this.Name = name;
      this.AbilityScores = abilityScores;
      this.Race = race;
      this.PClass = pClass;
      this.Level = level;
      this.Xp = xp;
      this.Hp = hp;
      this.Mp = mp;
      this.Hunger = hunger;
      this.Inv = inv;
      this.Equip = new Equip();
      this.BaseAc = 10 + abilityScores.ScoreMod("dex");
      this.Coordinates = new int[] { 0, 0, 0 };
    }
  }
}
