using UnityEngine;

[CreateAssetMenu(menuName = "TextRPG/InputActions/Unequip")]
public class Unequip : InputAction
{
    public override void RespondToInput(GameController controller, string[] seperatedInputWords)
    {
        controller.inventory.ExamineKeyword("unequip", seperatedInputWords);
    }
}