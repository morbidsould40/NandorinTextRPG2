using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    GameController controller;
    CombatManager combatManager;
    Player player;
    
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
        if (keywordVerb == "inv" || keywordVerb == "inventory")
        {
            Debug.Log("inventory");
        }
    }
}
