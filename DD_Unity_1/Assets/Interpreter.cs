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

      if (args[0] == "help")
      {
        // //Return some info
        // response.Add("If you want to use the terminal, type \"boop\" ");
        // response.Add("This is the second line that we are returning.");

        // return response;
        ListEntry("help", "returns a list of commands");
        ListEntry("stop", "pauses the game.");
        ListEntry("run", "resumes the game");
        ListEntry("four", "blah blah blah");
        ListEntry("look", "Provides details about the room you're in.");

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
        string target = "";
        // if (args.Length > 1)
        // {
        //     if (args[1] != null) // Unity added != null
        //     {
        //         target = args[1];
        //     }
        // }
        // else 
        // {
        //     target = "";
        // }
        Action.Look(target);
        return response;
      }

        // // ATTACK
        // if (args[0] == "attack" || args[0] == "at" || args[0] == "fight")
        // {
        //   string target;
        //   if (args.Length > 1) // Unity change != null to check length
        //   {
        //     target = args[1];
        //     TerminalManager.game.Attack(target);
        //   }
        //   else
        //   {
        //     target = "";
        //     // Display.output("<span class='cyan'>Attack</span> what?");
        //     response.Add("Attack what?");
        //     return response;
        //   }
        // }

      //     // MOVE
      //     if (args[0] == "move")
      //     {          
      //         this.Move();  
      //     }

          //GET
          if (args[0] == "get") 
          {
              string target;
              if (args.Length > 1)
              {
                  target = args[1];
                  Action.Get(target);
                  return response;
              }  
              else 
              {
                  target = "";
                  response.Add("Get what?");
                  return response;
              }
          }

          //EQUIP
          if (args[0] == "equip") 
          {
              string target;
              if (args.Length > 1)
              {
                  target = args[1];
                  Action.Equip(target);
                  return response;
              } 
              else
              {
                  target = "";
                  // Action.ViewEquip();
                  //Display.output("Equip what?")
                  response.Add("Equip what?");
                  return response;
              }
          }

          //LOOT
          if (args[0] == "loot") 
          {
              string target;
              if (args.Length > 1)
              {
                target = args[1];
                Action.Loot(target);
                return response;
              }
              else 
              {
                target = "";
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

      //     //USE
      //     if (args[0] == "use") 
      //     {
      //         string target;
      //         if (args[1] != null) 
      //         {
      //             target = args[1];
      //             this.Use(target);
      //         } 
      //         else
      //         {
      //             target = "";
      //             // Display.output("Use what?");
      //             response.Add("Use what?");
      //             return response;
      //         }
      //     }

      //     //HELP
      //     if (args[0] == "--help"||args[0] == "?"||args[0] == "help") 
      //     {
      //         this.Help();
      //     }
      else
      {
        response.Add("Command not recognized. Type help for a list of commands.");
        return response;
      }
    }

    // public static void DisplayCharStats(Player player)
    // {
    //   response.Add(player);
    // }

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