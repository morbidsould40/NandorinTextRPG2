using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text displayText;    
    public Player player;
    public InputAction[] inputActions;
    public PlayerManagement playerManagement;
    public List<KeyValuePair<string, Monsters>> mobsSpawnedInRoom = new List<KeyValuePair<string, Monsters>>();

    [HideInInspector] public RoomNavigation roomNavigation;
    [HideInInspector] public List<string> interactiveDescriptionsInRoom = new List<string>();
    [HideInInspector] public List<string> examinableDescriptionsInRoom = new List<string>();
    [HideInInspector] public InteractableItems interactableItems;
    [HideInInspector] public ExamaniableItems examinableItems;
    [HideInInspector] public LookableDirections lookableDirections;
    [HideInInspector] public List<string> mobsInTheRoom = new List<string>();

    private List<string> actionLog = new List<string>();
    private RoomNavigation roomNav;

    private void Awake()
    { 
        interactableItems = GetComponent<InteractableItems>();
        roomNavigation = GetComponent<RoomNavigation>();
        examinableItems = GetComponent<ExamaniableItems>();
        lookableDirections = GetComponent<LookableDirections>();
        playerManagement = GetComponent<PlayerManagement>();
        roomNav = GetComponent<RoomNavigation>();
    }

    private void Start()
    {
        SpawnAllMobs();
        DisplayRoomText();
        DisplayLoggedText();
    }

    private void SpawnAllMobs()
    {
        // TODO: Implement mobs spawn percentages
        
        Room[] rooms = Resources.LoadAll<Room>("ScriptableObjects/Rooms");
        foreach (Room room in rooms)
        {
            // Resets all rooms that can spawn mobs to be able to spawn them again on player entering
            room.mobsAlreadySpawned = false;
            if (room.canMobsSpawnHere)
            {
                // starts player in the same room they logged off
                var numberToSpawn = Random.Range(0, 4);
                if (!room.mobsAlreadySpawned)
                {
                    Debug.Log("Number of mobs to spawn in " + room.roomCode + ": " + numberToSpawn);
                    // find the number of different mobs the room can potentially spawn
                    var numMobs = 0;
                    foreach (var mobs in room.mobsThatCanSpawnHere)
                    {
                        numMobs++;
                    }
                    // spawn x mobs randomly from the list of mobs that can spawn in the room
                    for (int i = 0; i < numberToSpawn; i++)
                    {
                        var index = Random.Range(0, numMobs);
                        mobsSpawnedInRoom.Add(new KeyValuePair<string, Monsters>(room.roomCode, room.mobsThatCanSpawnHere[index]));
                        Debug.Log("Room: " + room.roomCode + " is spawning a " + room.mobsThatCanSpawnHere[index]);
                    }
                    // check to make sure mobs spawned, and if they did, set it so no more spawn until these are dead
                    if (numberToSpawn != 0)
                    {
                        room.mobsAlreadySpawned = true;
                    }
                }
            }
        }
    }

    // keeps track of what has been displayed and creates the scroll of all text in the main display
    public void DisplayLoggedText()
    {
        string logAsText = string.Join("\n", actionLog.ToArray());
        displayText.text = logAsText;        
    }

    // displays all the room info in the main display
    public void DisplayRoomText()
    {
        // color#ffff00ff is yellow. color#c0c0c0ff is gray
        ClearCollectionsForNewRoom();
        UnpackRoom();
        string joinedInteractionDescriptions = string.Join("\n", interactiveDescriptionsInRoom.ToArray());
        string combinedText = "<color=#ffff00ff>" + roomNavigation.currentRoom.roomName + "</color> \n" +
            roomNavigation.currentRoom.description + "\n" + "<color=#c0c0c0ff>" + joinedInteractionDescriptions + "</color>";
        LogStringWithReturn(combinedText);
        CheckRoomForMobs();
    }

    private void CheckRoomForMobs()
    {
        if (mobsSpawnedInRoom.Count > 0)
        {
            // using System.Linq to do a keyvaluepair lookup
            var lookup = mobsSpawnedInRoom.ToLookup(kvp => kvp.Key, kvp => kvp.Value);

            foreach (Monsters x in lookup[roomNav.currentRoom.roomCode])
            {
                mobsInTheRoom.Add(x.monsterName);
            }
            if (mobsInTheRoom.Count > 0)
            {
                string mobsInRoom = string.Join(", and a ", mobsInTheRoom.ToArray());
                string monsterText = "<color=#ff0000ff> You see a " + mobsInRoom + " in the room.</color>";
                LogStringWithReturn(monsterText);
            }
        }
    }

    private void UnpackRoom()
    {
        roomNavigation.UnpackExitsInRoom();
        roomNavigation.UnpackExaminablesInRoom();
        roomNavigation.UnpackMobsInRoom();
        //PrepareObjectsToTakeOrExamine(roomNavigation.currentRoom);        
    }

    //private void PrepareObjectsToTakeOrExamine(Room currentRoom)
    //{
    //    for (int i = 0; i < currentRoom.interactableObjectsInRoom.Length; i++)
    //    {
    //        string descriptionNotInInventory = interactableItems.GetObjectsInRoom(currentRoom, i);
    //        if (descriptionNotInInventory != null)
    //        {
    //            interactiveDescriptionsInRoom.Add(descriptionNotInInventory);
    //        }
    //    }
    //}   

    private void ClearCollectionsForNewRoom()
    {
        interactiveDescriptionsInRoom.Clear();
        mobsInTheRoom.Clear();
        roomNavigation.ClearExaminables();
        roomNavigation.ClearExits();
        roomNavigation.ClearMobs();
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }
}