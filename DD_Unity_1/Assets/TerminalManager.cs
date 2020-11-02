using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalManager : MonoBehaviour
{
    public GameObject directoryLine;
    public GameObject responseLine;

    public InputField terminalInput;
    public GameObject userInputLine;
    public ScrollRect sr;
    public GameObject msgList;

    Interpreter interpreter;
    private void Start()
    {
        interpreter = GetComponent<Interpreter>();
    }

    private void OnGUI()
    {
        if(terminalInput.isFocused && terminalInput.text != "" && Input.GetKeyDown(KeyCode.Return))
        {
            //Store whatever the user typed.
            string userInput = terminalInput.text;

            //Clear the input field.
            ClearInputField();

            //Instantiate a gameobject with a directory prefix
            AddDirectoryLine(userInput);

            //Add the interpretation lines
            int lines = AddInterpreterLines(interpreter.Interpret(userInput));

            //Scroll to the bottom of the scrollrect.
            ScrollToBottom(lines);

            //Move the user input line to the end.
            userInputLine.transform.SetAsLastSibling();

            //Refocus the input field
            terminalInput.ActivateInputField();
            terminalInput.Select();

        }
    }
    void ClearInputField()
    {
        terminalInput.text = "";
    }

    void AddDirectoryLine(string userInput)
    {
        //Resizing the command line container, so the scrollRect doesn't throw a fit.
        Vector2 msgListSize = msgList.GetComponent<RectTransform>().sizeDelta;
        msgList.GetComponent<RectTransform>().sizeDelta = new Vector2(msgListSize.x, msgListSize.y + 35.0f);

        //Instantiate the directory line.
        GameObject msg = Instantiate(directoryLine, msgList.transform);

        //Set it's child index.
        msg.transform.SetSiblingIndex(msgList.transform.childCount - 1);

        //Set the text of this new gameobject.
        msg.GetComponentsInChildren<Text>()[1].text = userInput;
    }

    int AddInterpreterLines(List<string> interpretation)
    {
        for (int i = 0; i < interpretation.Count; i++)
        {
            //Instantiate the response line.
            GameObject res = Instantiate(responseLine, msgList.transform);

            //Set it to the end of all the messages
            res.transform.SetAsLastSibling();

            //Get the size of the message list, and resize
            Vector2 listSize = msgList.GetComponent<RectTransform>().sizeDelta;
            msgList.GetComponent<RectTransform>().sizeDelta = new Vector2(listSize.x, listSize.y +35.0f);

            //Set the text of this response line to be whatever the interpreter string is.
            res.GetComponentInChildren<Text>().text = interpretation[i];
        }

        return interpretation.Count;
    }
    void ScrollToBottom(int lines)
    {
        if(lines > 4)
        {
            sr.velocity = new Vector2(0,450);
        }
        else
        {
            sr.verticalNormalizedPosition = 0;
        }
    }
}
