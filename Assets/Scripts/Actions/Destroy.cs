using UnityEngine;

[CreateAssetMenu(menuName = "TextRPG/InputActions/Destroy")]
public class Destroy : InputAction
{
    public override void RespondToInput(GameController controller, string[] seperatedInputWords)
    {
        controller.inventory.ExamineKeyword("destroy", seperatedInputWords);
    }
}
