using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    GameController controller;
    InventoryWindow invWindow;
    EquipmentPanel equipmentPanel;
    Character invManager;
    public DropItemConfirmation dropItemConfirmation;
    public Button yesButton;
    
    public List<Items> inventory = new List<Items>();
    public Dictionary<string, string> equippedItems = new Dictionary<string, string>();

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
	}

    private void Update()
    {
        CheckEncumberance();
    }

    private void CheckEncumberance()
    {

    }

    public void ExamineKeyword(string keywordVerb, params string[] keywordNoun)
    {
        if (keywordVerb == "equip")
        {
            string result = GetItemKeyword(keywordNoun);
            Debug.Log(result);
            var currentInventoryCount = inventory.Count;

            for (int i = 0; i < currentInventoryCount; i++)
            {
                var item = inventory[i];

                if (result == item.itemName.ToLower())
                {
                    invManager.EquipFromInventory(item);
                }
            }
        }

        if (keywordVerb == "unequip")
        {
            string result = GetItemKeyword(keywordNoun);
            Debug.Log(result);
            var currentInventoryCount = inventory.Count;

            for (int i = 0; i < currentInventoryCount; i++)
            {
                var item = inventory[i];

                if (result == item.itemName.ToLower())
                {
                    invManager.UnequipFromEquipPanel(item);
                }
            }
        }  
        
        if (keywordVerb == "buy")
        {
            string result = GetItemKeyword(keywordNoun);
            var currentInventoryCount = inventory.Count;

            foreach (var item in controller.roomNavigation.currentRoom.shopItems)
            {
                if (result == item.itemName.ToLower())
                {
                    // TODO check if player has enough gold
                    inventory.Add(item);
                    Debug.Log("Buying " + result);
                    controller.LogStringWithReturn("You have bought a " + item.itemName + " for " + item.itemCost + " gold.");
                    invWindow.AddItem(item);
                    // TODO subtract player gold for item
                }
            }

            if (currentInventoryCount == inventory.Count)
            {
                controller.LogStringWithReturn("There is no " + result + " to buy here. Type list to see what is available.");
            }
        }

        if (keywordVerb == "sell")
        {
            string result = GetItemKeyword(keywordNoun);
            Debug.Log(result);
            var currentInventoryCount = inventory.Count;

            for (int i = 0; i < currentInventoryCount; i++)
            {
                var item = inventory[i];
                
                if (result == item.itemName.ToLower())
                {
                    inventory.Remove(item);
                    Debug.Log("Selling " + result);
                    controller.LogStringWithoutReturn("You have sold " + item.itemName + " for " + (item.itemCost / 2) + " gold.");
                    invWindow.RemoveItem(item);
                    // TODO add gold to player's total
                }
            }
        }

        if (keywordVerb == "destroy")
        {
            string result = GetItemKeyword(keywordNoun);
            Debug.Log(result);
            var currentInventoryCount = inventory.Count;

            for (int i = 0; i < currentInventoryCount; i++)
            {
                var item = inventory[i];

                if (result == item.itemName.ToLower())
                {
                    // TODO Implement item deletion confirmation box
                    //dropItemConfirmation.gameObject.SetActive(true);
                    controller.LogStringWithoutReturn("You destroyed " + item.itemName + ".");
                    inventory.Remove(item);
                    invWindow.RemoveItem(item);
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
