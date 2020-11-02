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
      game.AddEnvironment("Castle Entrance", "     <span class='white'>Whew! That was quite the trek! But you've finally found it! Ravenhill Castle... You've heard a lot about it. Some strange things have been going on here, including, but not limited to kidnappings, experiments, torture... atrocious interior decorating... such HORRORS! And they must be stopped! Go now my friend!</span>", new List<Item>(), new List<Monster>(), new List<Player>(), new Dictionary<string, string>(){{"North","Door"},{"East","False"},{"South","False"},{"West","False"},{"Up","False"},{"Down","False"}});
      Monster rabidWolf = game.AddMonster(1, "Rabid Wolf", "Canis Lupis", 1, 5, 0, new List<object>(), new List<string>(), 8, 12, 8, 6, 6, 6, 6);
      game.Environments[0].Monsters.Add(rabidWolf);
      Container bonePile1 = game.AddContainer("box", 1000, "Pile of bones", 1, 500, 30, 1, new List<string>(), new List<string>(),"common");
      game.Environments[0].Items.AddItem(bonePile1);
      Armor rustedBreastplate = game.AddArmor("body", 1, "medium", "Rusted Breastplate",3,1,5,1,new List<string>(), new List<string>(),"common");
      game.Environments[0].Items[0].contents.Add(rustedBreastplate);
      Weapon dagger = game.AddWeapon("mainHand", new string[]{"str", "0"}, new string[]{"0", "d", "6"}, "Goblin Dagger", 2, 1, 5, 1, new List<string>(), new List<string>(), "common");
      game.Environments[0].Items.Add(dagger);

      // //1
      // game.addEnvironment("Foyer", "     <span class='white'>Quite the entrance! The room is filled with grandiose decor, with a huge piano, some suits of armor, a massive chandelier worth more than its weight in gold, and plenty of other trinkets the owner has most likely acquired COMPLETELY legally in their past adventures. There's two stairways and multiple hallways but feel a strange energy towards the corridor in front of you.</span>", [], [], [], []);
      // let demonButt = game.addMonster(2, "Demonic Butler", "Demon", 2, 8, 0, [], [], 6, 8, 10, 8, 8, 6, 6);
      // game.environments[1].monsters.push(demonButt);
      // let rottingBoots = game.addArmor("legs", 1, "light", "Rotting Boots",1,1,5,1,[],[],"common");
      // game.environments[1].items.push(rottingBoots);
      // let healingPotion1 = game.addConsumable(["heal","self",1,"d",8,1],"potion","Healing Potion",1,100,1,5,[],["consume on use"],"common");
      // game.environments[1].items.push(healingPotion1);
      // let healingPotion2 = game.addConsumable(["heal","self",1,"d",8,1],"potion","Demon Butler's Healing Potion",1,100,1,5,[],["consume on use"],"common");
      // demonButt.addItemInv(healingPotion2);

      // //2
      // game.addEnvironment("Dining Hall", "     <span class='white'>Jeez, the table in here is longer than the distance it took you to get to the castle... Does this guy really have that many friends? Nevertheless the table seemed to be being prepared at some point, but was interrupted. The a fire burns bright in the fireplace and only half of the chairs seem to have any settings. There is some sort of smell in the air though. And there's a door open on the other side of the room...</span>", [], [], [], []);
      // let goblin = game.addMonster(3, "Goblin", "Goblinski", 2, 7, 0, [], [], 6, 12, 8, 8, 6,
      //   6, 6);
      // game.environments[2].monsters.push(goblin);

      // //3
      // game.addEnvironment("Kitchen", "     <span class='white'>Now that you're in here... That smell is DEFINITELY not appealing... You do not dare to look inside the cauldron boiling with some unknown contents in the corner. Other than this, it seems like a fairly standard kitchen. Surely there's SOMETHING edible in here. The only other door in here leads to an adjacent hallway.</span>", [], [], [], []);
      // let creepyChef = game.addMonster(4, "Creepy Chef", "Human(?)", 3, 10, 0, [], [], 10, 8, 12, 6, 8, 6, 6);
      // game.environments[3].monsters.push(creepyChef);
      // let knife = game.addWeapon("mainHand", 2, 2, "Butcher's Knife",1,1,5,1,[],[],"common");
      // game.environments[3].items.push(knife);

      // //4
      // game.addEnvironment("Castle Room", "     <span class='white'>After meandering through the halls for a short time, you come across a dark, dank room. The feng shuay in here leaves a lot to be desired... A simple study, a very stained rug, and some very strange paintings occupy this room. There is a stairway leading down in here as well.</span>", [], [], [], []);
      // let zombie = game.addMonster(5, "Zombie", "Undead", 1, 6, 0, [], [], 10, 10, 6, 6, 6, 6, 6);
      // game.environments[4].monsters.push(zombie);
      
      // //5
      // game.addEnvironment("Stairs Landing", "    <span class='white'>The first step you take into this room, you feel a heavy weight on your shoulders. Like someone is pressing down on you. You'd really like to leave, but you've got your quest... It's your job to finish it. The room appears to be a pantry of sorts but there seems to be a long hallway leading somewhere else...</span>", [], [], [], []);
      // let banshee = game.addMonster(6, "Banshee", "Spectre", 3, 9, 0, [], [], 2, 10, 10, 6, 6, 10, 6);
      // game.environments[5].monsters.push(banshee);
      // let necklace = game.addArmor("neck",1,"light","Pearl Necklace",1,1, 5, 1, [],[],"common");
      // game.environments[5].items.push(necklace);

      // //6
      // game.addEnvironment("Torture Chamber", "     <span class='white'>Considering the amount of blood and strange contraptions, lord only knows the unfortunate things that have occured down here. It sends a shiver down your spine even thinking about it.</span>", [], [], [], []);
      // let goblinTort = game.addMonster(7, "Goblin Torturer", "shiz", 3, 11, 0, [], [], 12, 12, 10, 8, 4,
      //   4, 6);
      // game.environments[6].monsters.push(goblinTort);
      
      // //7
      // game.addEnvironment("Dungeon", "     <span class='white'>This room has barely any light to it. A single torch hanging on the wall does little to illuminate this dungeon. Although considering the many hanging chains and the fact that you can hear some type of liquid dripping, maybe that's for the best...</span>", [], [], [], []);
      // let toadKing = game.addMonster(8, "Toad King", "Amphibian", 3, 12, 0, [], [], 14, 12, 10, 6, 8,
      //   2, 2);
      // game.environments[7].monsters.push(toadKing);

      // //8
      // game.addEnvironment("The Altar", "  The room is massive... way bigger than you'd think to be in a castle by itself... But at the far end you can see it: A man! Who is also a demon! A demon man if you will... And he's opening a portal to hell to summon more demon men! This is it! The final battle! You must do your duty and stop him!", [], [], [], []);
      // let demonMan = game.addMonster(9, "Demon", "Man", 4, 15, 0, [], [], 10, 12, 10, 10, 10, 10, 10);
      // game.environments[8].monsters.push(demonMan);
      // let demonMask = game.addArmor("face", 10, "light", "Demon's Mask",666,1,5,1,[],[],"rare");
      // game.environments[8].monsters[0].addItemEquip(demonMask);

      return game;
    }
  }
}