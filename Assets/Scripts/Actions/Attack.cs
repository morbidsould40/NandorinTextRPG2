using UnityEngine;

[CreateAssetMenu(menuName = "TextRPG/InputActions/Attack")]
public class Attack : InputAction
{
    public override void RespondToInput(GameController controller, string[] seperatedInputWords)
    {
        controller.attackableMobs.ExamineKeyword(seperatedInputWords);
    }
}
