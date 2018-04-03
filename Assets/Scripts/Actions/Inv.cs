using UnityEngine;

[CreateAssetMenu(menuName = "TextRPG/InputActions/Inv")]
public class Inv : InputAction
{
    Inventory inv;
    Player player;
    string goldTense;


    public override void RespondToInput(GameController controller, string[] seperatedInputWords)
    {
        inv = FindObjectOfType<Inventory>();
        player = FindObjectOfType<Player>();

        if (player.PlayerGold == 1)
        {
            goldTense = "coin";
        }
        else
        {
            goldTense = "coins";
        }

        if (inv.inventory.Count <= 0)
        {            
            controller.LogStringWithReturn("Your inventory is currently empty. \nYou have " + player.PlayerGold + " gold " + goldTense + ".");
            controller.DisplayLoggedText();
        }
        else
        {
            controller.LogStringWithReturn("<Display items here>. \nYou have " + player.PlayerGold + " gold " + goldTense + ".");
            controller.DisplayLoggedText();
        }
    }
}