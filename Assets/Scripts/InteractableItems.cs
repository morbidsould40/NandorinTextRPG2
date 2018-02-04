using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour
{
    [HideInInspector] public List<string> nounsInRoom = new List<string>();

    public string GetObjectsInRoom(Room currentRoom, int i)
    {
        InteractableObject interactableInRoom = currentRoom.interactableObjectsInRoom[i];
        nounsInRoom.Add(interactableInRoom.noun);
        return interactableInRoom.description;        
    }
}

