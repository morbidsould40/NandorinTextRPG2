using UnityEngine;

[CreateAssetMenu(menuName = "TextRPG/InputActions/Sell")]
public class Sell : InputAction
{
    public override void RespondToInput(GameController controller, string[] seperatedInputWords)
    {
        controller.inventory.ExamineKeyword("sell", seperatedInputWords[1]);
    }
}
