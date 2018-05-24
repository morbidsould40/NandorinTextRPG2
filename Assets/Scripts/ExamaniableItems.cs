using UnityEngine;

public class ExamaniableItems : MonoBehaviour
{          
    [HideInInspector] public string examinableDescription;
    GameController controller;
    RoomNavigation roomNavigation;

    void Awake()
    {
        controller = GetComponent<GameController>();
        roomNavigation = GetComponent <RoomNavigation>();
    }

    public void ExamineKeyword(string[] keywordNoun)
    {
        if (keywordNoun.Length > 1)
        {
            if (roomNavigation.examineDictionary.ContainsKey(keywordNoun[1]) &&
                controller.examinableDescriptionsInRoom.Contains(keywordNoun[1]))
            {
                roomNavigation.examineDictionary.TryGetValue(keywordNoun[1], out examinableDescription);
                controller.LogStringWithReturn("<color=#ff00ffff>" + examinableDescription + "</color>");
            }
            else
            {
                controller.LogStringWithReturn("<color=#ff00ffff>There is no <i>" + keywordNoun[1] + "</i> to examine here</color>");
            }
        }
        else
        {
            controller.LogStringWithReturn("You must include what to examine in your command.");
        }
    }
}