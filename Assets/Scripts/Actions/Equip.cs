using UnityEngine;

[CreateAssetMenu(menuName = "TextRPG/InputActions/Equip")]
public class Equip : InputAction
{
    public override void RespondToInput(GameController controller, string[] seperatedInputWords)
    {
        controller.inventory.ExamineKeyword("equip", seperatedInputWords);
    }
}
