using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class InputAction : ScriptableObject
{

    public string keyWord;
    public Room valueRoom;

    public abstract void RespondToInput(GameController controller, string[] seperatedInputWords);
}
