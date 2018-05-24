using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class InputAction : ScriptableObject
{

    public string keyWord;
    [TextArea]
    public string description;

    public abstract void RespondToInput(GameController controller, string[] seperatedInputWords);
}
