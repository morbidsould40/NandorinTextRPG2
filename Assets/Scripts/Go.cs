using UnityEngine;


[CreateAssetMenu(menuName = "TextRPG/InputActions/Go")]
public class Go : InputAction
{

    public override void RespondToInput(GameController controller, string[] seperatedInputWords)
    {
        controller.roomNavigation.AttemptToChangeRooms(seperatedInputWords[1]);
    }
}
