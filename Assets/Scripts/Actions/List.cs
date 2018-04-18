using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextRPG/InputActions/List")]
public class List : InputAction
{

    public override void RespondToInput(GameController controller, string[] seperatedInputWords)
    {
        if (controller.roomNavigation.currentRoom.isShop)
        {
            List<Items> currentShopItems = new List<Items>();
            var shopItems = controller.roomNavigation.currentRoom.shopItems;

            if (shopItems.Length > 0)
            {
                for (int i = 0; i < shopItems.Length; i++)
                {
                    currentShopItems.Add(shopItems[i]);
                }

                controller.LogStringWithReturn("For Sale\n_______________________________________________");
                var itemNumber = 1;
                foreach (var item in currentShopItems)
                {
                    controller.LogStringWithoutReturn(item.itemName + " - " + item.itemCost + " gold");
                    itemNumber++;
                }
                controller.DisplayLoggedText();
                currentShopItems.Clear();
            }
            else
            {
                controller.LogStringWithReturn("There are no items in this shop for sale.");
                controller.DisplayLoggedText();
            }
        }
        else
        {
            controller.LogStringWithReturn("You must be in a shop to see a LIST of wares.");
            controller.DisplayLoggedText();
        }
    }
}
