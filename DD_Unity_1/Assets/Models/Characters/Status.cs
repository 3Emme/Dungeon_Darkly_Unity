using System;
using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public class Status
  {
    public bool Blinded { get; set; }
    public bool Charmed { get; set; }
    public bool Dead { get; set; }
    public bool Deafened { get; set; }
    public bool Dehydrated { get; set; }
    public bool Enraged { get; set; }
    public bool Exhausted { get; set; }
    public bool Flying { get; set; }
    public bool Freezing { get; set; }
    public bool Frightened { get; set; }
    public bool Grappled { get; set; }
    public bool Hidden { get; set; }
    public bool Incapacitated { get; set; }
    public bool Invisible { get; set; }
    public bool Paralyzed { get; set; }
    public bool Petrified { get; set; }
    public bool Poisoned { get; set; }
    public bool Prone { get; set; }
    public bool Restrained { get; set; }
    public bool Starving { get; set; }
    public bool Stunned { get; set; }
    public bool Surprised { get; set; }
    public bool Unconscious { get; set; }

    public Status()
    {
      this.Blinded = false;
      this.Charmed = false;
      this.Dead = false;
      this.Deafened = false;
      this.Dehydrated = false;
      this.Enraged = false;
      this.Exhausted = false;
      this.Flying = false;
      this.Freezing = false;
      this.Frightened = false;
      this.Grappled = false;
      this.Hidden = false;
      this.Incapacitated = false;
      this.Invisible = false;
      this.Paralyzed = false;
      this.Petrified = false;
      this.Poisoned = false;
      this.Prone = false;
      this.Restrained = false;
      this.Starving = false;
      this.Stunned = false;
      this.Surprised = false;
      this.Unconscious = false;
    }

  }
}

// export class Status{
//   constructor(){
//     this.blinded = false,
//     this.charmed = false,
//     this.deafened = false,
//     this.dehydrated = false,
//     this.enraged = false,
//     this.exhausted = false,
//     this.flying = false,
//     this.freezing = false,
//     this.frightened = false,
//     this.grappled = false,
//     this.hidden = false,
//     this.incapacitated = false,
//     this.invisible = false,
//     this.paralyzed = false,
//     this.petrified = false,
//     this.poisoned = false,
//     this.prone = false,
//     this.restrained = false,
//     this.starving = false,
//     this.stunned = false,
//     this.surprised = false,
//     this.unconscious = false;
//   }
// }