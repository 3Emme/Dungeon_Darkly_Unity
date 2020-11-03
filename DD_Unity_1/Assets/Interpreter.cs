using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Dungeon_Darkly
{
    public class Interpreter : MonoBehaviour
    {
        Game game;
        private void Start()
        {
            game = GameInit.GetGame();

            Player player1 = game.AddPlayer("P name", "P race", "P class", 1, 0, 10, 10, 0, new List<Item>(), 10, 10, 10, 10, 10, 10, 10);
            game.Environments[0].Players.Add(player1);
            game.Players.Add(player1);
        }
        Dictionary<string,string> colors = new Dictionary<string, string>()
        {
            {"black",   "#021b21"},
            {"gray",    "#555d71"},
            {"red",     "#ff5879"},
            {"yellow",  "#f2f1b9"},
            {"blue",    "#9ed9d8"},
            {"purple",  "#d926ff"},
            {"orange",  "#ef5847"}
        };
        List<string> response = new List<string>();

        public List<string> Interpret(string userInput)
        {
            response.Clear();

            string[] args = userInput.ToLower().Split();

            if(args[0] == "help")
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
            if(args[0] == "ascii")
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


                response.Add(game.Look(target));
                // response.Add("beefaroni");
                return response;
            }

        //     // ATTACK
        //     if (args[0] == "attack"||args[0] == "at"||args[0] == "fight")
        //     { 
        //         string target;
        //         if (args[1] != null)
        //         {
        //             target = args[1];
        //             this.Attack(target);
        //         } else {
        //             target = "";
        //             // Display.output("<span class='cyan'>Attack</span> what?");
        //             response.Add("Attack what?");
        //             return response;
        //         }
        //     } 

        //     // MOVE
        //     if (args[0] == "move")
        //     {          
        //         this.Move();  
        //     }

        //     //GET
        //     if (args[0] == "get") 
        //     {
        //         string target;
        //         if (args[1] != null)
        //         {
        //             target = args[1];
        //             this.Get(target);
        //         }  
        //         else 
        //         {
        //             target = "";
        //             // Display.output("<span class='cyan'>Get</span> what?");
        //             response.Add("Get what?");
        //             return response;
        //         }
        //     }

        //     //EQUIP
        //     if (args[0] == "equip") 
        //     {
        //         string target;
        //         if (args[1] != null) 
        //         {
        //             target = args[1];
        //             this.Equip(target);
        //         } 
        //         else
        //         {
        //             target = "";
        //             this.ViewEquip();
        //             //Display.output("Equip what?")
        //             response.Add("Equip what?");
        //             return response;
        //         }
        //     }

        //     //LOOT
        //     if (args[0] == "loot") 
        //     {
        //         string target;
        //         if (args[1] != null) 
        //         {
        //             target = args[1];
        //             this.Loot(target);
        //         } 
        //         else 
        //         {
        //             target = "";
        //             // Display.output("Loot what?");
        //             response.Add("Loot what?");
        //             return response;
        //         }
        //     }

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

            for(int i = 0; i < spacing; i++)
            {
                response.Add("");
            }

            while(!file.EndOfStream)
            {
                response.Add(ColorString(file.ReadLine(), colors[color]));
            }

            for(int i = 0; i < spacing; i++)
            {
                response.Add("");
            }

            file.Close();
        }
    }
}