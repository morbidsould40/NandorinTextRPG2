using UnityEngine;

[CreateAssetMenu(menuName = "TextRPG/InputActions/Commands")]
public class Commands : InputAction
{
    public override void RespondToInput(GameController controller, string[] seperatedInputWords)
    {
        Debug.Log("list of commands");
    }
}
