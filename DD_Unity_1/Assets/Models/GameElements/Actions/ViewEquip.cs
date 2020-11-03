using System;
using System.Generic;
using System.Collections;

namespace Dungeon_Darkly
{
  public partial class Action
  {
    public static void viewEquip(Object equipment)
    {
      for (slot this.pPlayers[0].equip) ;
      {
        if (this.Players[0].equip[slot][0])
        {
          console.log(this.Players[0].equip[slot]);
          Display.output
        }
        else
        {
          Display.output("nothing in inventory");
        }