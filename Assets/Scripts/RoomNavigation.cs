using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoomNavigation : MonoBehaviour
{

    public Room currentRoom;
    public Player player;
    [HideInInspector] public Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>();
    [HideInInspector] public Dictionary<string, string> examineDictionary = new Dictionary<string, string>();
    [HideInInspector] public Dictionary<string, string> mobsDictionary = new Dictionary<string, string>();
       

    private GameController controller;
    
    private void Awake()
    {
        controller = GetComponent<GameController>();              
    }

    private void Start()
    {        
        currentRoom = player.CurrentRoom;
    }    
    
    public void UnpackExitsInRoom()
    {
        for (int i = 0; i < currentRoom.exits.Length; i++)
        {
            // find all exits for this room and put them into a dictionary (direction, room)
            exitDictionary.Add(currentRoom.exits[i].keyString, currentRoom.exits[i].valueRoom);
            // find all descriptions for exits and put them into a list in GameController
            controller.interactiveDescriptionsInRoom.Add(currentRoom.exits[i].exitDescription);
        }
    }

    public void UnpackExaminablesInRoom()
    {
        for (int i = 0; i < currentRoom.examinableObjectsInRoom.Length; i++)
        {
            // finds all examinable objects in this room and puts them into a dictionary (object, description)
            examineDictionary.Add(currentRoom.examinableObjectsInRoom[i].noun, currentRoom.examinableObjectsInRoom[i].description);
            // finds all descriptions for examinable objects and puts them into a list in GameController
            controller.examinableDescriptionsInRoom.Add(currentRoom.examinableObjectsInRoom[i].noun);
        }
    }

    // TODO Need to set spawn % values for each mob that can spawn in a room (ex. more skeletons than ghouls should spawn in cemetery)
    public void UnpackMobsInRoom()
    {
        if (currentRoom.mobsInRoom.Length == 0 && currentRoom.mobsAlreadySpawned == false && currentRoom.canMobsSpawnHere == true)
        {
            // Spawn between 0-3 mobs in the room when a player enters it
        }   
    }

    public void AttemptToChangeRooms(string directionNoun)
    {
        // if there is an exit in the direction the player typed
        if (exitDictionary.ContainsKey(directionNoun))
        {
            currentRoom = exitDictionary[directionNoun];
            controller.LogStringWithReturn("You head to the " + directionNoun);
            controller.DisplayRoomText();
            player.CurrentRoom = currentRoom;
            player.PlayerCurrentRoom = currentRoom.roomCode;
        }
        else
        {
            controller.LogStringWithReturn("There is no exit to the " + directionNoun);
        }
    }

    // clear all dictionaries to prepare for next room population
    public void ClearExits()
    {
        exitDictionary.Clear();
    }

    public void ClearExaminables()
    {
        examineDictionary.Clear();
    }

    public void ClearMobs()
    {
        mobsDictionary.Clear();
    }
}
