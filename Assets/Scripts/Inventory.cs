using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    GameController controller;
    CombatManager combatManager;
    Player player;
    InventoryWindow inventoryWindow;

    // need a couple lists/dictionaries to handle weapons/armor/general items.
    // Can you initialize a dictionary with a set of keys with blank values (empty equipment slots)
    public List<Items> inventory = new List<Items>();
    public Dictionary<string, string> equippedItems = new Dictionary<string, string>();

    public enum Encumberance
    {
        None, Light, Medium, Heavy, Overloaded
    }

    public Encumberance encumberance = Encumberance.None;
    
	void Awake () {
        controller = GetComponent<GameController>();
        combatManager = GetComponent<CombatManager>();
        player = FindObjectOfType<Player>();
        inventoryWindow = FindObjectOfType<InventoryWindow>();
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
            Debug.Log("equip");
        }

        if (keywordVerb == "unequip")
        {
            Debug.Log("unequip");
        }  
        
        if (keywordVerb == "buy")
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
            var currentInventoryCount = inventory.Count;

            foreach (var item in controller.roomNavigation.currentRoom.shopItems)
            {
                if (result == item.itemName.ToLower())
                {
                    inventory.Add(item);
                    Debug.Log("Buying " + result);
                    controller.LogStringWithReturn("You have bought a " + item.itemName + " for " + item.itemCost + " gold.");
                    inventoryWindow.AddItemsFromInventory();
                }
            }

            if (currentInventoryCount == inventory.Count)
            {
                controller.LogStringWithReturn("There is no " + result + " to buy here. Type list to see what is available.");
            }
        }

        if (keywordVerb == "sell")
        {
            Debug.Log("sell");
        }

        if (keywordVerb == "drop")
        {
            Debug.LogError("THIS WILL DESTROY THE ITEM");
        }
    }
}
