using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    GameController controller;
    CombatManager combatManager;
    Player player;

    // need a couple lists/dictionaries to handle weapons/armor/general items.
    // Can you initialize a dictionary with a set of keys with blank values (empty equipment slots)
    public Dictionary<int, string> inventory = new Dictionary<int, string>();
    public Dictionary<string, string> equippedItems = new Dictionary<string, string>();
    
	void Awake () {
        controller = GetComponent<GameController>();
        combatManager = GetComponent<CombatManager>();
        player = FindObjectOfType<Player>();
	}

    public void ExamineKeyword(string keywordVerb, string keywordNoun)
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
            Debug.Log("buy");
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
