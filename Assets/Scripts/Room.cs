using UnityEngine;

[CreateAssetMenu(menuName = "TextRPG/Room")]
public class Room : ScriptableObject
{

    [TextArea]
    public string description;
    public string roomName;
    public string roomCode;
    public Exit[] exits;
    public InteractableObject[] interactableObjectsInRoom;
    public ExaminableObject[] examinableObjectsInRoom;
    public bool canMobsSpawnHere;
    public Monsters[] mobsThatCanSpawnHere;
    public bool mobsAlreadySpawned;
    public float timeMobsDied;
    public float respawnTimer;
    public bool isShop;
    public Items[] shopItems;
    public bool isDark; // players will need a lightsource to move through these sections
}
