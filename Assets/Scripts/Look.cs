using UnityEngine;

[CreateAssetMenu(menuName = "TextRPG/InputActions/Look")]
public class Look : InputAction {

    public override void RespondToInput(GameController controller, string[] seperatedInputWords)
    {
        var wordLength = seperatedInputWords.Length;        
        if (wordLength > 1)
        {
            controller.lookableDirections.LookKeyword(seperatedInputWords[1]);
        }
        else
        {
            controller.DisplayRoomText();
        }        
    }
}
