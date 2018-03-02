using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text displayText;
    public Text playerName;
    public Player player;
    public InputAction[] inputActions;


    [HideInInspector] public RoomNavigation roomNavigation;
    [HideInInspector] public List<string> interactiveDescriptionsInRoom = new List<string>();
    [HideInInspector] public List<string> examinableDescriptionsInRoom = new List<string>();
    [HideInInspector] public InteractableItems interactableItems;
    [HideInInspector] public ExamaniableItems examinableItems;
    [HideInInspector] public LookableDirections lookableDirections;

    List<string> actionLog = new List<string>();

    void Awake()
    { 
        interactableItems = GetComponent<InteractableItems>();
        roomNavigation = GetComponent<RoomNavigation>();
        examinableItems = GetComponent<ExamaniableItems>();
        lookableDirections = GetComponent<LookableDirections>();
    }

    void Start()
    {
        DisplayRoomText();
        DisplayLoggedText();
        playerName.text = player.PlayerName;
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
    }

    void UnpackRoom()
    {
        roomNavigation.UnpackExitsInRoom();
        roomNavigation.UnpackExaminablesInRoom();
        PrepareObjectsToTakeOrExamine(roomNavigation.currentRoom);        
    }

    void PrepareObjectsToTakeOrExamine(Room currentRoom)
    {
        for (int i = 0; i < currentRoom.interactableObjectsInRoom.Length; i++)
        {
            string descriptionNotInInventory = interactableItems.GetObjectsInRoom(currentRoom, i);
            if (descriptionNotInInventory != null)
            {
                interactiveDescriptionsInRoom.Add(descriptionNotInInventory);
            }
        }
    }   

    void ClearCollectionsForNewRoom()
    {
        interactiveDescriptionsInRoom.Clear();
        roomNavigation.ClearExaminables();
        roomNavigation.ClearExits();
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }
}