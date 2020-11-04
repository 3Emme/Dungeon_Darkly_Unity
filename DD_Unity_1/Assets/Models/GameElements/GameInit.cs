using System;
using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  //addMonster(id,name,mainType,cr,hp,mp,[],[],str,dex,con,wis,int,chr,lck)
  // Double check that values are up to date! :D

  public class GameInit {
    public static Game GetGame() {
      Game game = new Game(new List<Player>(), new List<Item>(), new List<Monster>(),new List<Environment>());
      //0
      game.AddEnvironment("Castle Entrance", "Whew! That was quite the trek! But you've finally found it! Ravenhill Castle... You've heard a lot about it. Some strange things have been going on here, including, but not limited to kidnappings, experiments, torture... atrocious interior decorating... such HORRORS! And they must be stopped! Go now my friend!</span>",
      new List<Item>(),
      new List<Monster>(),
      new List<Player>(), 
      new Dictionary<string, string>(){{"North","True"},{"East","False"},{"South","False"},{"West","False"},{"Up","False"},{"Down","False"}},
      new int[] { 0, 0, 0 });

      Monster rabidWolf = game.AddMonster(1, "Rabid Wolf", "Canis Lupis", 1, 5, 0, new List<Item>(), new List<string>(), 8, 12, 8, 6, 6, 6, 6);
      game.Environments[0].Monsters.Add(rabidWolf);

      Container bonePile1 = game.AddContainer("box", 1000, "Pile of bones", 1, 500, 30, 1, new List<string>(), new List<string>(){"container"}, "common");
      Armor rustedBreastplate = game.AddArmor("Body", 1, "medium", "Rusted Breastplate", 3, 1, 5, 1, new List<string>(), new List<string>(){"armor"}, "common");

      bonePile1.Contents.Add(rustedBreastplate);

      game.Environments[0].Items.Add(bonePile1);

      // game.Environments[0].Items[0].Contents.Add(rustedBreastplate);
      Weapon dagger = game.AddWeapon("Main hand", new string[]{"str", "0"}, new string[]{"0", "d", "6"}, "Goblin Dagger", 2, 1, 5, 1, new List<string>(), new List<string>(){"weapon"}, "common");

      game.Environments[0].Items.Add(dagger);

      //1
      game.AddEnvironment("Foyer", "Quite the entrance! The room is filled with grandiose decor, with a huge piano, some suits of armor, a massive chandelier worth more than its weight in gold, and plenty of other trinkets the owner has most likely acquired COMPLETELY legally in their past adventures. There's two stairways and multiple hallways but feel a strange energy towards the corridor in front of you.</span>", 
      new List<Item>(),
      new List<Monster>(),
      new List<Player>(), 
      new Dictionary<string, string>(){{"North","False"},{"East","True"},{"South","True"},{"West","False"},{"Up","False"},{"Down","False"}},
      new int[] { 1, 0, 0 });
      Monster demonButt = game.AddMonster(2, "Demonic Butler", "Demon", 2, 8, 0, new List<Item>(), new List<string>(), 6, 8, 10, 8, 8, 6, 6);
      game.Environments[1].Monsters.Add(demonButt);
      Armor rottingBoots = game.AddArmor("Legs", 1, "light", "Rotting Boots",1,1,5,1, new List<string>(), new List<string>(){"armor"}, "common");
      game.Environments[1].Items.Add(rottingBoots);
      Consumable healingPotion1 = game.AddConsumable(["heal","self","1","d","8","1"],"potion","Healing Potion",1,100,1,5,[],["consume on use"],"common");
      game.Environments[1].Items.Add(healingPotion1);
      Consumable healingPotion2 = game.AddConsumable(["heal","self","1","d","8","1"],"potion","Demon Butler's Healing Potion",1,100,1,5,[],["consume on use"],"common");
      demonButt.AddItemInv(healingPotion2);

      //2
      game.AddEnvironment("Dining Hall", "Jeez, the table in here is longer than the distance it took you to get to the castle... Does this guy really have that many friends? Nevertheless the table seemed to be being prepared at some point, but was interrupted. The a fire burns bright in the fireplace and only half of the chairs seem to have any settings. There is some sort of smell in the air though. And there's a door open on the other side of the room...</span>",
      new List<Item>(),
      new List<Monster>(),
      new List<Player>(), 
      new Dictionary<string, string>(){{"North","True"},{"East","False"},{"South","False"},{"West","True"},{"Up","False"},{"Down","True"}},
      new int[] { 1, 1, 0 });
      Monster goblin = game.AddMonster(3, "Goblin", "Goblinski", 2, 7, 0, new List<Item>(), new List<string>(), 6, 12, 8, 8, 6, 6, 6);
      game.Environments[2].Monsters.Add(goblin);

      //3
      game.AddEnvironment("Kitchen", "     <span class='white'>Now that you're in here... That smell is DEFINITELY not appealing... You do not dare to look inside the cauldron boiling with some unknown contents in the corner. Other than this, it seems like a fairly standard kitchen. Surely there's SOMETHING edible in here. The only other door in here leads to an adjacent hallway.</span>", 
      new List<Item>(),
      new List<Monster>(),
      new List<Player>(), 
      new Dictionary<string, string>(){{"North","False"},{"East","False"},{"South","False"},{"West","False"},{"Up","True"},{"Down","False"}},
      new int[] { 1, 1, -1 });

      Monster creepyChef = game.AddMonster(4, "Creepy Chef", "Human(?)", 3, 10, 0, new List<Item>(), new List<string>(), 10, 8, 12, 6, 8, 6, 6);
      game.Environments[3].Monsters.Add(creepyChef);
      Weapon knife = game.AddWeapon("Main hand", new string[]{"str", "2"}, new string[] {"1", "d", "2"}, "Butcher's Knife", 1, 1, 5, 1, new List<string>(), new List<string>() {"weapon"}, "common");
      game.Environments[3].Items.Add(knife);

      //4
      game.AddEnvironment("Castle Room", "     <span class='white'>After meandering through the halls for a short time, you come across a dark, dank room. The feng shuay in here leaves a lot to be desired... A simple study, a very stained rug, and some very strange paintings occupy this room. There is a stairway leading down in here as well.</span>",
      new List<Item>(),
      new List<Monster>(),
      new List<Player>(), 
      new Dictionary<string, string>(){{"North","False"},{"East","False"},{"South","True"},{"West","True"},{"Up","False"},{"Down","False"}},
      new int[] { 2, 1, 0 });
      Monster zombie = game.AddMonster(5, "Zombie", "Undead", 1, 6, 0, new List<Item>(), new List<string>(), 10, 10, 6, 6, 6, 6, 6);
      game.Environments[4].Monsters.Add(zombie);
      
      //5
      game.AddEnvironment("Stairs Landing", "    <span class='white'>The first step you take into this room, you feel a heavy weight on your shoulders. Like someone is pressing down on you. You'd really like to leave, but you've got your quest... It's your job to finish it. The room appears to be a pantry of sorts but there seems to be a long hallway leading somewhere else...</span>", 
      new List<Item>(),
      new List<Monster>(),
      new List<Player>(), 
      new Dictionary<string, string>(){{"North","False"},{"East","True"},{"South","False"},{"West","False"},{"Up","True"},{"Down","False"}},
      new int[] { 2, 0, 0 });
      Monster banshee = game.AddMonster(6, "Banshee", "Spectre", 3, 9, 0, new List<Item>(), new List<string>(), 2, 10, 10, 6, 6, 10, 6);
      game.Environments[5].Monsters.Add(banshee);
      Armor necklace = game.AddArmor("Neck", 1, "light", "Pearl Necklace", 1, 1, 5, 1, new List<string>(), new List<string>(){"armor"},"common");
      game.Environments[5].Items.Add(necklace);

      //6
      game.AddEnvironment("Torture Chamber", "     <span class='white'>Considering the amount of blood and strange contraptions, lord only knows the unfortunate things that have occured down here. It sends a shiver down your spine even thinking about it.</span>",
      new List<Item>(),
      new List<Monster>(),
      new List<Player>(), 
      new Dictionary<string, string>(){{"North","False"},{"East","False"},{"South","True"},{"West","False"},{"Up","False"},{"Down","True"}},
      new int[] { 2, 0, 1 });
      Monster goblinTort = game.AddMonster(7, "Goblin Torturer", "shiz", 3, 11, 0, new List<Item>(), new List<string>(), 12, 12, 10, 8, 4, 4, 6);
      game.Environments[6].Monsters.Add(goblinTort);
      
      //7
      game.AddEnvironment("Dungeon", "     <span class='white'>This room has barely any light to it. A single torch hanging on the wall does little to illuminate this dungeon. Although considering the many hanging chains and the fact that you can hear some type of liquid dripping, maybe that's for the best...</span>",
      new List<Item>(),
      new List<Monster>(),
      new List<Player>(), 
      new Dictionary<string, string>(){{"North","True"},{"East","False"},{"South","True"},{"West","false"},{"Up","False"},{"Down","false"}},
      new int[] { 1, 0, 1 });
      Monster toadKing = game.AddMonster(8, "Toad King", "Amphibian", 3, 12, 0, new List<Item>(), new List<string>(), 14, 12, 10, 6, 8, 2, 2);
      game.Environments[7].Monsters.Add(toadKing);

      //8
      game.AddEnvironment("The Altar", "  The room is massive... way bigger than you'd think to be in a castle by itself... But at the far end you can see it: A man! Who is also a demon! A demon man if you will... And he's opening a portal to hell to summon more demon men! This is it! The final battle! You must do your duty and stop him!",
      new List<Item>(),
      new List<Monster>(),
      new List<Player>(), 
      new Dictionary<string, string>(){{"North","True"},{"East","False"},{"South","False"},{"West","False"},{"Up","False"},{"Down","False"}},
      new int[] { 0, 0, 1 });
      Monster demonMan = game.AddMonster(9, "Demon", "Man", 4, 15, 0, new List<Item>(), new List<string>(), 10, 12, 10, 10, 10, 10, 10);
      game.Environments[8].Monsters.Add(demonMan);
      Armor demonMask = game.AddArmor("Face", 10, "light", "Demon's Mask", 666, 1, 5, 1, new List<string>(), new List<string>(){"armor"},"rare");
      game.Environments[8].Monsters[0].AddItemEquip(demonMask);

      return game;
    }
  }
}