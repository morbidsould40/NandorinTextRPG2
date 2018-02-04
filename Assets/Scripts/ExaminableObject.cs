using UnityEngine;

[CreateAssetMenu(menuName = "TextRPG/Examinable Object")]
public class ExaminableObject : ScriptableObject {

    public string noun = "name";
    [TextArea]
    public string description = "description in room";
}
