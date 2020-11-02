using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Interpreter : MonoBehaviour
{
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

        string[] args = userInput.Split();

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

            return response;
        }
        if(args[0] == "ascii")
        {
            LoadTitle("ascii.txt", "red", 2);

            return response;
        }
        if(args[0] == "boop")
        {
            response.Add("Thank you for using the terminal.");

            return response;
        }
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
