using UnityEngine;

public class ExamaniableItems : MonoBehaviour
{          
    [HideInInspector] public string examinableDescription;
    GameController controller;
    RoomNavigation roomNavigation;
    Room currentRoom;

    void Awake()
    {
        controller = GetComponent<GameController>();
        roomNavigation = GetComponent <RoomNavigation>();
    }

    public void ExamineKeyword(string keywordNoun)
    {
        if (roomNavigation.examineDictionary.ContainsKey(keywordNoun) &&
            controller.examinableDescriptionsInRoom.Contains(keywordNoun))
        {            
            roomNavigation.examineDictionary.TryGetValue(keywordNoun, out examinableDescription);
            controller.LogStringWithReturn("<color=#ff00ffff>" + examinableDescription + "</color>");
        }
        else
        {
            controller.LogStringWithReturn("<color=#ff00ffff>There is no <i>" + keywordNoun + "</i> to examine here</color>");
        }        
    }
}