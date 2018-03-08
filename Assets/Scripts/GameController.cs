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
        DisplayRoomText();
        DisplayLoggedText();

        Room[] rooms = Resources.LoadAll<Room>("ScriptableObjects/Rooms");
        foreach (Room room in rooms)
        {
            room.mobsAlreadySpawned = false;
        }
    }

    public void DisplayLoggedText()
    {
        string logAsText = string.Join("\n", actionLog.ToArray());
        displayText.text = logAsText;        
    }

    public void DisplayRoomText()
    {        
        ClearCollectionsForNewRoom();
        UnpackRoom();        
        string joinedInteractionDescriptions = string.Join("\n", interactiveDescriptionsInRoom.ToArray());        
        string combinedText = "<color=#ffff00ff>" + roomNavigation.currentRoom.roomName + "</color> \n" +
            roomNavigation.currentRoom.description + "\n" + "<color=#c0c0c0ff>" + joinedInteractionDescriptions + "</color>";       
        LogStringWithReturn(combinedText);

        if (roomNav.mobsSpawnedInRoom.Count > 0)
        {
            var lookup = roomNav.mobsSpawnedInRoom.ToLookup(kvp => kvp.Key, kvp => kvp.Value);
            //string[] monsters;
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