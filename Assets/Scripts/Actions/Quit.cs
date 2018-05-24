using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextRPG/InputActions/Quit")]
public class Quit : InputAction {

    public override void RespondToInput(GameController controller, string[] seperatedInputWords)
    {
        controller.miscCommands.ExamineKeyword(seperatedInputWords);
    }
}
