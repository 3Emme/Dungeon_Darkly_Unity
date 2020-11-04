using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Dungeon_Darkly
{
  public class Interpreter : MonoBehaviour
  {
    Dictionary<string, string> colors = new Dictionary<string, string>()
        {
            {"black",   "#021b21"},
            {"gray",    "#555d71"},
            {"red",     "#ff5879"},
            {"yellow",  "#f2f1b9"},
            {"blue",    "#9ed9d8"},
            {"purple",  "#d926ff"},
            {"orange",  "#ef5847"}
        };
    static List<string> response = new List<string>();

    public List<string> Interpret(string userInput)
    {
      response.Clear();

      string[] args = userInput.ToLower().Split();

      Environment current_location = TerminalManager.game.Environments[TerminalManager.game.Players[0].Location];
      Debug.Log("Interpreter p location:"+TerminalManager.game.Players[0].Location);
      if (args[0] == "--help"||args[0] == "?"||args[0] == "help")
      {
        // //Return some info
        // response.Add("If you want to use the terminal, type \"boop\" ");
        // response.Add("This is the second line that we are returning.");

        // return response;
        // ListEntry("help", "returns a list of commands");
        // ListEntry("stop", "pauses the game.");
        // ListEntry("run", "resumes the game");
        // ListEntry("four", "blah blah blah");
        // ListEntry("look", "Provides details about the room you're in.");

        Action.Help();

        return response;
      }

      if (args[0] == "ascii")
      {
        LoadTitle("ascii.txt", "red", 2);
        return response;
      }

      // LOOK
      if (args[0] == "look" || args[0] == "l")
      {
        Debug.Log($"Length: {args.Length}");
        if (args.Length > 1)
        {
          // foreach (Monster monster in current_location.Monsters)
          // {
          //   if (monster.Name.Contains(args[1]))
          //   {
          //     Action.Look(args[1]);
          //     return response;
          //   }
          // }
          // foreach (Item item in current_location.Items)
          // {
          //   if (item.Name.Contains(args[1]))
          //   {
          //     Action.Look(args[1]);
          //     return response;
          //   }
          // }
          Action.Look(args[1]);
          // response.Add($"Can't find {args[1]}");
          return response;
        }
        Action.Look("");
        return response;
      }

      // ATTACK
      if (args[0] == "attack" || args[0] == "at" || args[0] == "fight")
      {
        if (args.Length > 1) // Unity change != null to check length
        {
          // foreach (Monster monster in current_location.Monsters)
          // {
          // if (monster.Name.Contains(args[1]))
          // {
          //   target = args[1];
          //   Action.Attack(target);
          //   return response;
          // }
          // }
          // else
          // {
          //   response.Add($"Can't find {args[1]}");
          //   return response;
          // }
          Debug.Log("multiple args detected");
          Action.Attack(args[1]);
          return response;
        }
        else
        {
          response.Add("Attack what?");
          return response;
        }
      }

      // MOVE
      if (args[0] == "north" || args[0] == "n")
      {          
          Action.Move("North",0,1); 
          return response; 
      }
      if (args[0] == "east" || args[0] == "e")
      {          
          Action.Move("East",1,1);
          return response;  
      }
      if (args[0] == "south" || args[0] == "s")
      {          
          Action.Move("South",0,-1); 
          return response; 
      }
      if (args[0] == "west" || args[0] == "w")
      {          
          Action.Move("West",1,-1);
          return response;  
      }
      if (args[0] == "up" || args[0] == "u")
      {          
          Action.Move("Up",2,1);
          return response;  
      }
      if (args[0] == "down" || args[0] == "d")
      {          
          Action.Move("Down",2,-1);
          return response;  
      }

      //GET
      if (args[0] == "get") 
      {
          if (args.Length > 1)
          {
            // foreach (Item item in current_location.Items)
            // {
            //   if (item.Name.Contains(args[1]))
            //   {
            //     Action.Get(args[1]);
            //     return response;
            //   }
            // }
            // response.Add($"Can't find {args[1]}");
            // return response;
            Action.Get(args[1]);
            return response;
          }
          else 
          {
              response.Add("Get what?");
              return response;
          }
      }

      //EQUIP
      if (args[0] == "equip") 
      {
          if (args.Length > 1)
          {
            // foreach (Item item in current_location.Players[0].Inv)
            // {
            //   if (item.Name.ToLower().Contains(args[1]))
            //   {
            //     Action.Equip(args[1]);
            //     return response;
            //   }
            // }
            // response.Add($"Can't find {args[1]}");
            // return response;
              Action.Equip(args[1]);
              return response;
          }
          else
          {
              response.Add("Equip what?");
              return response;
          }
      }

      //VIEWEQUIP
      if (args[0] == "viewequip" || args[0] == "ve")
      {
        Action.ViewEquip();
        return response;
      }

      //LOOT
      if (args[0] == "loot") 
      {
          if (args.Length > 1)
          {
            // foreach (Item item in current_location.Items)
            // {
            //   if (item.Name.Contains(args[1]))
            //   {
            //     Action.Loot(args[1]);
            //     return response;
            //   }
            // }
            // response.Add($"Can't find {args[1]}");
            // return response;
            Action.Loot(args[1]);
            return response;
          }
          else 
          {
            response.Add("Loot what?");
            return response;
          }
      }

      // VIEW INV
      if (args[0] == "inv")
      {
        Action.ViewInventory();
        return response;
      }

      //USE
      if (args[0] == "use") 
      {
          if (args.Length > 1) 
          {
              Action.Use(args[1]);
              return response;
          } 
          else
          {
              response.Add("Use what?");
              return response;
          }
      }
      else
      {
        response.Add("Command not recognized. Type help for a list of commands.");
        return response;
      }
    }

    public static void DisplayOutput(string output)
    {
      response.Add(output);
    }

    public string ColorString(string s, string color)
    {
      string leftTag = "<color=" + color + ">";
      string rightTag = "</color>";

      return leftTag + s + rightTag;
    }

    void ListEntry(string a, string b)
    {
      response.Add(ColorString(a, colors["orange"]) + ": " + ColorString(b, colors["yellow"]));
    }

    void LoadTitle(string path, string color, int spacing)
    {
      StreamReader file = new StreamReader(Path.Combine(Application.streamingAssetsPath, path));

      for (int i = 0; i < spacing; i++)
      {
        response.Add("");
      }

      while (!file.EndOfStream)
      {
        response.Add(ColorString(file.ReadLine(), colors[color]));
      }

      for (int i = 0; i < spacing; i++)
      {
        response.Add("");
      }

      file.Close();
    }
  }
}