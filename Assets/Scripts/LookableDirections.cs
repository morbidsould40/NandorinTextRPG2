using UnityEngine;

public class LookableDirections : MonoBehaviour {

    [HideInInspector] public Room lookRoom;
    [HideInInspector] public string lookDescription;

    GameController controller;
    RoomNavigation roomNavigation;
    
    void Awake()
    {
        controller = GetComponent<GameController>();
        roomNavigation = GetComponent<RoomNavigation>();
    }

    public void LookKeyword(string directionNoun)
    {
        if (roomNavigation.exitDictionary.ContainsKey(directionNoun))
        {
            lookRoom = roomNavigation.exitDictionary[directionNoun];
            lookDescription = lookRoom.roomName;
            controller.LogStringWithReturn("To the <b>" + directionNoun + "</b> you see <color=#ffff00ff>" +
                lookDescription + "</color>.");
        }
        else
        {
            controller.LogStringWithReturn("You do not see anything <b> " + directionNoun + "</b>.");
        }        
        // TODO once monsters and other players are implemented, also show them in the room being looked into
    }

}
