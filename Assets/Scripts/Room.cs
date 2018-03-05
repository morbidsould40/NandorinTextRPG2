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
    public Monsters[] monstersInRoom;
}
