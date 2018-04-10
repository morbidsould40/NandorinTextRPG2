using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextRPG/InputActions/List")]
public class List : InputAction
{

    public override void RespondToInput(GameController controller, string[] seperatedInputWords)
    {
        if (controller.roomNavigation.currentRoom.isShop)
        {
            Dictionary<string, int> storeInventory = new Dictionary<string, int>();
            var shopWeapons = controller.roomNavigation.currentRoom.shopWeapons;
            var shopArmor = controller.roomNavigation.currentRoom.shopArmor;
            if (shopWeapons.Length > 0)
            {
                for (int i = 0; i < shopWeapons.Length; i++)
                {
                    storeInventory.Add(shopWeapons[i].weaponName, shopWeapons[i].weaponCost);
                }
            }
            if (shopArmor.Length > 0)
            {
                for (int i = 0; i < shopArmor.Length; i++)
                {
                    storeInventory.Add(shopArmor[i].armorName, shopArmor[i].armorCost);
                }
            }
            controller.LogStringWithReturn("For Sale\n_______________________________________________");
            var itemNumber = 1;
            foreach (var item in storeInventory)
            {
                controller.LogStringWithoutReturn(itemNumber + ": " + item.Key + " - " + item.Value + " gold");
                itemNumber++;
            }
            controller.DisplayLoggedText();
            storeInventory.Clear();
        }
        else
        {
            controller.LogStringWithReturn("You must be in a shop to see a LIST of wares.");
            controller.DisplayLoggedText();
        }
    }
}
