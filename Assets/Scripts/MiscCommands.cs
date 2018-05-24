using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscCommands : MonoBehaviour {

    GameController controller;

    private void Start()
    {
        controller = GetComponent<GameController>();
    }

    public void ExamineKeyword(string[] keyword)
    {
        if (keyword[0] == "quit")
        {
            Application.Quit();
        }

        if (keyword[0] == "commands")
        {
            var commands = Resources.LoadAll<InputAction>("ScriptableObjects/Actions");
            foreach (var command in commands)
            {
                controller.LogStringWithoutReturn("<color=#ffff00ff><b>" + command.name + "</b></color>: " + command.description);
            }
        }
    }

    private static string GetItemKeyword(string[] keywordNoun)
    {
        string result = "";

        for (int i = 0; i < keywordNoun.Length; i++)
        {
            if (i > 0)
            {
                result += " ";
            }
            result += keywordNoun[i];
        }

        if (result.Length > 0)
        {
            int i = result.IndexOf(" ") + 1;
            string str = result.Substring(i);
            result = str;
        }

        return result;
    }
}
