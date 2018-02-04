using UnityEngine;

[CreateAssetMenu(menuName = "TextRPG/InputActions/Examine")]
public class Examine : InputAction {

	public override void RespondToInput(GameController controller, string[] seperatedInputWords)
    {
        controller.examinableItems.ExamineKeyword(seperatedInputWords[1]);
    }
}
