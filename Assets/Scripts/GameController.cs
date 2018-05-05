using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text displayText;
    public Player player;
    public InputAction[] inputActions;
    public List<KeyValuePair<string, Monsters>> mobsSpawnedInRoom = new List<KeyValuePair<string, Monsters>>();
    public bool enemyPrefabsSpawned = false;

    [HideInInspector] public List<string> interactiveDescriptionsInRoom = new List<string>();
    [HideInInspector] public List<string> examinableDescriptionsInRoom = new List<string>();
    [HideInInspector] public InteractableItems interactableItems;
    [HideInInspector] public ExamaniableItems examinableItems;
    [HideInInspector] public LookableDirections lookableDirections;
    [HideInInspector] public AttackableMobs attackableMobs;
    [HideInInspector] public Inventory inventory;
    [HideInInspector] public CombatManager combatManager;
    [HideInInspector] public List<Monsters> mobsInTheRoom = new List<Monsters>();
    [HideInInspector] public RoomNavigation roomNav;

    // this will be used to determine if the player can leave a room or has to flee
    [HideInInspector] public bool mustFleeToMove = false;

    List<string> actionLog = new List<string>();    
    Monsters monsters;
    GameObject spawnedMob;

    private void Awake()
    { 
        interactableItems = GetComponent<InteractableItems>();
        examinableItems = GetComponent<ExamaniableItems>();
        lookableDirections = GetComponent<LookableDirections>();
        roomNav = GetComponent<RoomNavigation>();
        combatManager = GetComponent<CombatManager>();
        attackableMobs = GetComponent<AttackableMobs>();
        inventory = GetComponent<Inventory>();
    }

    private void Start()
    {
        SpawnAllMobs();
        DisplayRoomText();
        DisplayLoggedText();
    }

    private void SpawnAllMobs()
    {        
        Room[] rooms = Resources.LoadAll<Room>("ScriptableObjects/Rooms");
        foreach (Room room in rooms)
        {
            // Resets all rooms that can spawn mobs to be able to spawn them again on player entering
            room.mobsAlreadySpawned = false;
            if (room.canMobsSpawnHere)
            {
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
                        for (int x = 0; x < numMobs; x++)
                        {
                            var mob = room.mobsThatCanSpawnHere[x];
                            float roll = Random.Range(0, 100);
                            if (roll <= mob.spawnChance)
                            {
                                mobsSpawnedInRoom.Add(new KeyValuePair<string, Monsters>(room.roomCode, room.mobsThatCanSpawnHere[x]));
                                Debug.Log("Room: " + room.roomCode + " is spawning a " + room.mobsThatCanSpawnHere[x]);                                
                                break;
                            }
                        }
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
        string combinedText = "<color=#ffff00ff>" + roomNav.currentRoom.roomName + "</color> \n" +
            roomNav.currentRoom.description + "\n" + "<color=#c0c0c0ff>" + joinedInteractionDescriptions + "</color>";
        LogStringWithReturn(combinedText);
        CheckRoomForMobs();
        if (!enemyPrefabsSpawned)
        {
            SpawnMobPrefabs();
        }
    }

    private void SpawnMobPrefabs()
    {
        var lookup = mobsSpawnedInRoom.ToLookup(kvp => kvp.Key, kvp => kvp.Value);

        foreach (Monsters mob in lookup[roomNav.currentRoom.roomCode])
        {
            Monsters go = Instantiate(mob);
            go.name = mob.monsterName;
            mob.monsterID = mob.monsterName + Random.Range(1, 999999);
            enemyPrefabsSpawned = true;
        }    }

    private void CheckRoomForMobs()
    {
        if (mobsSpawnedInRoom.Count > 0)
        {
            // using System.Linq to do a keyvaluepair lookup
            var lookup = mobsSpawnedInRoom.ToLookup(kvp => kvp.Key, kvp => kvp.Value);

            foreach (Monsters x in lookup[roomNav.currentRoom.roomCode])
            {
                mobsInTheRoom.Add(x);                
            }
            if (mobsInTheRoom.Count > 0)
            {
                List<string> mobNames = new List<string>();
                for (int i = 0; i < mobsInTheRoom.Count; i++)
                {
                    mobNames.Add(mobsInTheRoom[i].monsterName);
                }                
                string mobsInRoom = string.Join(", and a ", mobNames.ToArray());
                string monsterText = "<color=#ff0000ff> You see a " + mobsInRoom + " in the room.</color>";
                LogStringWithReturn(monsterText);
                LogStringWithReturn("It is your turn to attack!");
                mustFleeToMove = true;
            }
        }
    }

    private void UnpackRoom()
    {
        roomNav.UnpackExitsInRoom();
        roomNav.UnpackExaminablesInRoom();
    }

    private void ClearCollectionsForNewRoom()
    {
        interactiveDescriptionsInRoom.Clear();
        mobsInTheRoom.Clear();
        roomNav.ClearExaminables();
        roomNav.ClearExits();
        roomNav.ClearMobs();
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }

    public void LogStringWithoutReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd);
    }
}