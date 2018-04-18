using UnityEngine;

[CreateAssetMenu(menuName = "TextRPG/InputActions/Drop")]
public class Drop : InputAction
{
    public override void RespondToInput(GameController controller, string[] seperatedInputWords)
    {
        controller.inventory.ExamineKeyword("drop", seperatedInputWords);
    }
}
