using UnityEngine;

[CreateAssetMenu(menuName = "TextRPG/Interactable Object")]
public class InteractableObject : ScriptableObject
{
    public string noun = "name";
    [TextArea]
    public string description = "description in room";
}

