using UnityEngine;

[CreateAssetMenu(menuName = "TextRPG/InputActions/Buy")]
public class Buy : InputAction
{
    public override void RespondToInput(GameController controller, string[] seperatedInputWords)
    {
        controller.inventory.ExamineKeyword("buy", seperatedInputWords[1]);
    }
}