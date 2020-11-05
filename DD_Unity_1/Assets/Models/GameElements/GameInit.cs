using System;
using System.Collections;
using System.Collections.Generic;

namespace Dungeon_Darkly
{
  public class GameInit
  {
    public static Game GetGame()
    {
      Game game = new Game(new List<Player>(), new List<Item>(), new List<Monster>(),new List<Environment>());
      //0
      game.AddEnvironment("Castle Entrance", "Whew! That was quite the trek! But you've finally found it! Ravenhill Castle... You've heard a lot about it. Some strange things have been going on here, including, but not limited to kidnappings, experiments, torture... atrocious interior decorating... such HORRORS! And they must be stopped! Go now my friend!",
      new List<Item>(),
      new List<Monster>(),
      new List<Player>(), 
      new Dictionary<string, string>(){{"North","True"},{"East","False"},{"South","False"},{"West","False"},{"Up","False"},{"Down","False"}},
      new int[] { 0, 0, 0 });

      Monster rabidWolf = game.AddMonster(1, "Rabid Wolf", "Canis Lupis", 10, 1, 0, new List<Item>(), new List<string>(), 8, 12, 8, 6, 6, 6, 6, "Ah yes... the majestic canis lupis...unfortunately this guy seems a little worse for wear... It's probably best to put him out of his misery, but be careful he doesn't put you out of yours!");
      game.Environments[0].Monsters.Add(rabidWolf);

      Container bonePile1 = game.AddContainer("box", 1000, "Pile of bones", 1, 500, 30, 1, new List<string>(), new List<string>(){"container"}, "common", "Looks like you weren't the only one the wolf tried to snack on. Looking at these makes you realize it could have been a LOT worse! You could probably turn them in at the nearby village.");
      Armor rustedBreastplate = game.AddArmor("Body", 1, "medium", "Rusted Breastplate", 3, 1, 5, 1, new List<string>(), new List<string>(){"armor"}, "common", "This looks like it's been out here for a *long* time. Probably longer than the wolf lived here... The rust on this nearly gives you tetanous just looking at it, but it's *probably* better than nothing!");

      bonePile1.Contents.Add(rustedBreastplate);

      game.Environments[0].Items.Add(bonePile1);

      // game.Environments[0].Items[0].Contents.Add(rustedBreastplate);
      Weapon dagger = game.AddWeapon("Main hand", new string[]{"str", "0"}, new string[]{"1", "d", "6"}, "Goblin Dagger", 2, 1, 5, 1, new List<string>(), new List<string>(){"weapon"}, "common", "Unlike the breastplate, this dagger looks fairly newly crafted. Not a bad find! Although if it were rusted it might do more damage over time...");

      game.Environments[0].Items.Add(dagger);

      //1
      game.AddEnvironment("Foyer", "Quite the entrance! The room is filled with grandiose decor, with a huge piano, some suits of armor, a massive chandelier worth more than its weight in gold, and plenty of other trinkets the owner has most likely acquired COMPLETELY legally in their past adventures. There's a strange energy towards the corridor to the east.", 
      new List<Item>(),
      new List<Monster>(),
      new List<Player>(), 
      new Dictionary<string, string>(){{"North","False"},{"East","True"},{"South","True"},{"West","False"},{"Up","False"},{"Down","False"}},
      new int[] { 1, 0, 0 });
      Monster demonButt = game.AddMonster(2, "Demonic Butler", "Demon", 2, 8, 0, new List<Item>(), new List<string>(), 6, 8, 10, 8, 8, 6, 6,"Upon walking in, you can see this rather unfriendly looking gent standing near the opposite end of the Foyer. He definitely doesn't look like he's going to ask you if you'd like a beverage if you approached him. Be careful fighting this one.");
      game.Environments[1].Monsters.Add(demonButt);
      Armor rottingBoots = game.AddArmor("Legs", 1, "light", "Rotting Boots",1,1,5,1, new List<string>(), new List<string>(){"armor"}, "common","hey *really* didn't spare any expenses clothing this guy. These boots are only holding together by the grace of the gods, but if you wear them over your stockings, they may give you some traction!");
      game.Environments[1].Items.Add(rottingBoots);
      Consumable healingPotion1 = game.AddConsumable(new string[]{"heal","self","1","d","8","1"}, "potion", "Healing Potion",1,100,1,5, new List<string>(), new List<string>(){"consume on use","useable"}, "common","Red liquid in a bottle!");
      game.Environments[1].Items.Add(healingPotion1);
      Consumable healingPotion2 = game.AddConsumable(new string[]{"heal","self","1","d","8","1"}, "potion", "Demon Butler's Healing Potion",1,100,1,5, new List<string>(), new List<string>(){"consume on use","useable"}, "common","Red liquid in a bottle!");
      demonButt.AddItemInv(healingPotion2);

      //2
      game.AddEnvironment("Dining Hall", "Jeez, the table in here is longer than the distance it took you to get to the castle... Does this guy really have that many friends? Nevertheless the table seemed to be being prepared at some point, but was interrupted. The a fire burns bright in the fireplace and only half of the chairs seem to have any settings. There is some sort of smell in the air though. There's a door open on the other side of the room to the north and stairs leading down to the kitchen",
      new List<Item>(),
      new List<Monster>(),
      new List<Player>(), 
      new Dictionary<string, string>(){{"North","True"},{"East","False"},{"South","False"},{"West","True"},{"Up","False"},{"Down","True"}},
      new int[] { 1, 1, 0 });
      Monster goblin = game.AddMonster(3, "Goblin", "Goblinski", 2, 7, 0, new List<Item>(), new List<string>(), 6, 12, 8, 8, 6, 6, 6,"Though the room is dimly lit, you can see movement in the opposite corner. It seems to be a goblin servant licking the leftover food off a plate. He notices you and hucks the plate at you! It's time for him to learn some table manners...");
      game.Environments[2].Monsters.Add(goblin);

      //3
      game.AddEnvironment("Kitchen", "Now that you're in here... That smell is DEFINITELY not appealing... You do not dare to look inside the cauldron boiling with some unknown contents in the corner. Other than this, it seems like a fairly standard kitchen. Surely there's SOMETHING edible in here.", 
      new List<Item>(),
      new List<Monster>(),
      new List<Player>(), 
      new Dictionary<string, string>(){{"North","False"},{"East","False"},{"South","False"},{"West","False"},{"Up","True"},{"Down","False"}},
      new int[] { 1, 1, -1 });

      Monster creepyChef = game.AddMonster(4, "Creepy Chef", "Human(?)", 3, 10, 0, new List<Item>(), new List<string>(), 10, 8, 12, 6, 8, 6, 6,"Although we're not the types to pass judgement here at Dungeon Darkly, we recommend when you're face to face with a creepy chef cooking a dish with fingers for decoration: You're probably wise to fight back...");
      game.Environments[3].Monsters.Add(creepyChef);
      Weapon knife = game.AddWeapon("Main hand", new string[]{"str", "2"}, new string[] {"1", "d", "6"}, "Butcher's Knife", 1, 1, 5, 1, new List<string>(), new List<string>() {"weapon"}, "common", "A long and sharp knife used by that creepy cook for... nefarious deeds. It may do those who fell victim to it justice if you used it for good!");
      game.Environments[3].Items.Add(knife);

      //4
      game.AddEnvironment("Castle Room", "After meandering through the halls for a short time, you come across a dark, dank room. The feng shuay in here leaves a lot to be desired... A simple study, a very stained rug, and some very strange paintings occupy this room. There is a door to the stairs landing to the west",
      new List<Item>(),
      new List<Monster>(),
      new List<Player>(), 
      new Dictionary<string, string>(){{"North","False"},{"East","False"},{"South","True"},{"West","True"},{"Up","False"},{"Down","False"}},
      new int[] { 2, 1, 0 });
      Monster zombie = game.AddMonster(5, "Zombie", "Undead", 1, 6, 0, new List<Item>(), new List<string>(), 10, 10, 6, 6, 6, 6, 6,"Compared to the other things you've seen, this guy seems pretty tame. He's not hanging on by much, but if he's any indication of what's going on in this castle, you'd better beat him and make your way to the source.");
      game.Environments[4].Monsters.Add(zombie);
      
      //5
      game.AddEnvironment("Stairs Landing", "The first step you take into this room, you feel a heavy weight on your shoulders. Like someone is pressing down on you. You'd really like to leave, but you've got your quest... It's your job to finish it. The room appears to be a pantry of sorts and there seems to be a some spooky stairs leading up...", 
      new List<Item>(),
      new List<Monster>(),
      new List<Player>(), 
      new Dictionary<string, string>(){{"North","False"},{"East","True"},{"South","False"},{"West","False"},{"Up","True"},{"Down","False"}},
      new int[] { 2, 0, 0 });
      Monster banshee = game.AddMonster(6, "Banshee", "Spectre", 3, 9, 0, new List<Item>(), new List<string>(), 2, 10, 10, 6, 6, 10, 6,"After a few steps into the landing, you hear a blood curdling scream, but it is unfortunately familiar: The scream of a banshee. This could get about as ugly as she is...");
      game.Environments[5].Monsters.Add(banshee);
      Armor necklace = game.AddArmor("Neck", 1, "light", "Pearl Necklace", 1, 1, 5, 1, new List<string>(), new List<string>(){"armor"},"common","A lusterous pearl necklace. This appears to be what the Banshee was protecting. It could sell for a pretty penny, but it may also give you an advantage by wearing it.");
      game.Environments[5].Items.Add(necklace);

      //6
      game.AddEnvironment("Torture Chamber", "Considering the amount of blood and strange contraptions, lord only knows the unfortunate things that have occured down here. It sends a shiver down your spine even thinking about it.",
      new List<Item>(),
      new List<Monster>(),
      new List<Player>(), 
      new Dictionary<string, string>(){{"North","False"},{"East","False"},{"South","True"},{"West","False"},{"Up","False"},{"Down","True"}},
      new int[] { 2, 0, 1 });
      Monster goblinTort = game.AddMonster(7, "Goblin Torturer", "shiz", 3, 11, 0, new List<Item>(), new List<string>(), 12, 12, 10, 8, 4, 4, 6,"This Goblin makes the other one look like a shrimp. He's covered in blood, so it would be wise to approach this fight with caution: This guy is no joke.");
      game.Environments[6].Monsters.Add(goblinTort);
      
      //7
      game.AddEnvironment("Dungeon", "This room has barely any light to it. A single torch hanging on the wall does little to illuminate this dungeon. Although considering the many hanging chains and the fact that you can hear some type of liquid dripping, maybe that's for the best...",
      new List<Item>(),
      new List<Monster>(),
      new List<Player>(), 
      new Dictionary<string, string>(){{"North","True"},{"East","False"},{"South","True"},{"West","false"},{"Up","False"},{"Down","false"}},
      new int[] { 1, 0, 1 });
      Monster toadKing = game.AddMonster(8, "Toad King", "Amphibian", 3, 12, 0, new List<Item>(), new List<string>(), 14, 12, 10, 6, 8, 2, 2,"You can hear a wet slapping approaching you. Out of the darkness you see him: The Toad King... You know he's the king because he's about eight feet taller and wider than your average toad... and eight times meaner.");
      game.Environments[7].Monsters.Add(toadKing);

      //8
      game.AddEnvironment("The Altar", "The room is massive... way bigger than you'd think to be in a castle by itself... But at the far end you can see it: A man! Who is also a demon! A demon man if you will... And he's opening a portal to hell to summon more demon men! This is it! The final battle! You must do your duty and stop him!",
      new List<Item>(),
      new List<Monster>(),
      new List<Player>(), 
      new Dictionary<string, string>(){{"North","True"},{"East","False"},{"South","False"},{"West","False"},{"Up","False"},{"Down","False"}},
      new int[] { 0, 0, 1 });
      Monster demonMan = game.AddMonster(9, "Demon", "Man", 4, 20, 0, new List<Item>(), new List<string>(), 10, 12, 10, 10, 10, 10, 10,"The second you see him, you know that he's behind all of the disappearances around here. The energy around him chills your spine, and he's not about to let you get away with interfering with his evil demon summoning ritual. Prepare yourself, as this is sure to be your toughest fight yet!");
      game.Environments[8].Monsters.Add(demonMan);
      Armor demonMask = game.AddArmor("Face", 10, "light", "Demon's Mask", 666, 1, 5, 1, new List<string>(), new List<string>(){"armor"},"rare","On the sacrificial altar, a poor sap who was unlucky enough to be the next vessel for summoning a hell-portal. But strangely, he is wearing some sort of mask in the shape of a demon's face. While touching it makes you feel a blood curdling sensation, you should probably take it back to the village to have it examined...");
      game.Environments[8].Monsters[0].AddItemEquip(demonMask);

      return game;
    }
  }
}