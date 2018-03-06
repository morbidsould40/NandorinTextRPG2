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
    public List<KeyValuePair<string, Monsters>> mobsSpawnedInRoom = new List<KeyValuePair<string, Monsters>>();
    

    

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
            exitDictionary.Add(currentRoom.exits[i].keyString, currentRoom.exits[i].valueRoom);            
            controller.interactiveDescriptionsInRoom.Add(currentRoom.exits[i].exitDescription);
        }
    }

    public void UnpackExaminablesInRoom()
    {
        for (int i = 0; i < currentRoom.examinableObjectsInRoom.Length; i++)
        {
            examineDictionary.Add(currentRoom.examinableObjectsInRoom[i].noun, currentRoom.examinableObjectsInRoom[i].description);
            controller.examinableDescriptionsInRoom.Add(currentRoom.examinableObjectsInRoom[i].noun);
        }
    }

    public void UnpackMobsInRoom()
    {        
        if (currentRoom.mobsInRoom.Length == 0 && currentRoom.mobsAlreadySpawned == false && currentRoom.canMobsSpawnHere == true)            
        {
            var lookup = mobsSpawnedInRoom.ToLookup(kvp => kvp.Key, kvp => kvp.Value);
            var numberToSpawn = Random.Range(0, 3);
            if (!currentRoom.mobsAlreadySpawned)
            {                
                Debug.Log("Number to spawn: " + numberToSpawn);
                var numMobs = 0;
                foreach (var mobs in currentRoom.mobsThatCanSpawnHere)
                {
                    numMobs++;
                }
                for (int i = 0; i < numberToSpawn; i++)
                {
                    var index = Random.Range(0, numMobs);
                    mobsSpawnedInRoom.Add(new KeyValuePair<string, Monsters>(currentRoom.roomCode, currentRoom.mobsThatCanSpawnHere[index]));
                }                
                if (numberToSpawn != 0)
                {
                    currentRoom.mobsAlreadySpawned = true;
                }
            }
            else
            {
                Debug.Log("Room already spawned");
            }
                           
            
            for (int i = 0; i < currentRoom.mobsInRoom.Length; i++)
            {
                var chanceToSpawn = Random.Range(1, 100);                
                currentRoom.mobsInRoom[i].monsterID = currentRoom.mobsInRoom[i].monsterKeyword + Random.Range(1, 9999);
                mobsDictionary.Add(currentRoom.mobsInRoom[i].monsterID, currentRoom.mobsInRoom[i].monsterKeyword);
                controller.mobsInTheRoom.Add(currentRoom.mobsInRoom[i].monsterName);
                
            }
        }
        else
        {
            return;
        }
    }

    public void AttemptToChangeRooms(string directionNoun)
    {
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
