using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    GameController controller;
    InventoryWindow invWindow;
    public EquipmentPanel equipmentPanel;
    Character invManager;
    PlayerManagement playerManagement;
    public EquipmentSlot[] equipmentSlot;
    public DropItemConfirmation dropItemConfirmation;
    public Button yesButton;

    public enum Encumberance
    {
        None, Light, Medium, Heavy, Overloaded
    }

    public Encumberance encumberance = Encumberance.None;

    void Awake () {
        controller = GetComponent<GameController>();
        invWindow = FindObjectOfType<InventoryWindow>();
        equipmentPanel = FindObjectOfType<EquipmentPanel>();
        invManager = FindObjectOfType<Character>();
        playerManagement = FindObjectOfType<PlayerManagement>();
        equipmentSlot = equipmentPanel.equipmentSlotsParent.GetComponentsInChildren<EquipmentSlot>();
	}

    private void Update()
    {
        CheckEncumberance();
    }

    private void CheckEncumberance()
    {

    }

    public void ExamineKeyword(string keywordVerb, string[] keywordNoun)
    {
        if (keywordVerb == "unequip")
        {
            string result = GetItemKeyword(keywordNoun);
            Debug.Log("unequiping: " + result);            

            for (int i = 0; i < equipmentSlot.Length; i++)
            {
                var item = equipmentSlot[i].Item;
                Debug.Log(item);
                if (item != null)
                {
                    if (result == item.itemName.ToLower())
                    {
                        invManager.UnequipFromEquipPanel(item);
                    }
                }
            }
        }

        if (keywordVerb == "equip")
        {
            string result = GetItemKeyword(keywordNoun);
            Debug.Log("equipping: " + result);
            var currentInventoryCount = invWindow.items.Count;

            for (int i = 0; i < currentInventoryCount; i++)
            {
                var item = invWindow.items[i];

                if (result == item.itemName.ToLower())
                {
                    invManager.EquipFromInventory(item);
                }
            }
        }

        if (keywordVerb == "buy")
        {
            string result = GetItemKeyword(keywordNoun);
            var currentInventoryCount = invWindow.items.Count;

            foreach (var item in controller.roomNav.currentRoom.shopItems)
            {
                if (result == item.itemName.ToLower())
                {                    
                    // make sure player has enough gold to buy item requested
                    if (playerManagement.CheckIfPlayerHasEnoughGold(item.itemCost))
                    {
                        Debug.Log("Buying " + result);
                        controller.LogStringWithReturn("You have bought a " + item.itemName + " for " + item.itemCost + " gold.");
                        invWindow.AddItem(item);
                        // subtract gold from players total
                        playerManagement.UpdatePlayerGold(-item.itemCost);
                    }
                    else
                    {
                        controller.LogStringWithReturn("You do not have enough gold to buy " + item.itemName + ".");
                    }                   
                }
            }

            if (currentInventoryCount == invWindow.items.Count)
            {
                controller.LogStringWithReturn("There is no " + result + " to buy here. Type list to see what is available.");
            }
        }

        if (keywordVerb == "sell")
        {
            string result = GetItemKeyword(keywordNoun);
            Debug.Log(result);
            var currentInventoryCount = invWindow.items.Count; ;

            for (int i = 0; i < currentInventoryCount; i++)
            {
                var item = invWindow.items[i];

                if (result == item.itemName.ToLower())
                {
                    Debug.Log("Selling " + result);
                    controller.LogStringWithoutReturn("You have sold " + item.itemName + " for " + (item.itemCost / 2) + " gold.");
                    invWindow.RemoveItem(item);
                    // add gold to players total
                    playerManagement.UpdatePlayerGold(item.itemCost / 2);
                    break;
                }
            }
        }

        if (keywordVerb == "destroy")
        {
            string result = GetItemKeyword(keywordNoun);
            Debug.Log(result);
            var currentInventoryCount = invWindow.items.Count;

            for (int i = 0; i < currentInventoryCount; i++)
            {
                var item = invWindow.items[i];

                if (result == item.itemName.ToLower())
                {
                    // TODO Implement item deletion confirmation box
                    //dropItemConfirmation.gameObject.SetActive(true);
                    controller.LogStringWithoutReturn("You destroyed " + item.itemName + ".");
                    invWindow.RemoveItem(item);
                    break;
                }
                else
                {
                    controller.LogStringWithReturn("You do not have any " + result + " to destroy.");
                }
            }
        }
    }

    private static string GetItemKeyword(string[] keywordNoun)
    {
        string result = "";

        for (int i = 0; i < keywordNoun.Length; i++)
        {
            if (i > 0)
            {
                result += " ";
            }
            result += keywordNoun[i];
        }

        if (result.Length > 0)
        {
            int i = result.IndexOf(" ") + 1;
            string str = result.Substring(i);
            result = str;
        }

        return result;
    }
}
