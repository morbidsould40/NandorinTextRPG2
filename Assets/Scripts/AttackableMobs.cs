﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableMobs : MonoBehaviour {

    CombatManager combatManager;
    GameController controller;

    void Awake ()
    {
        combatManager = GetComponent<CombatManager>();
        controller = GetComponent<GameController>();
	}

    public void ExamineKeyword(string[] keywordNoun)
    {
        if (keywordNoun.Length > 1)
        {
            combatManager.combatState = CombatManager.CombatState.StartCombat;
            var result = GetItemKeyword(keywordNoun);
            combatManager.CombatStateMachine(result);
        }
        else
        {
            controller.LogStringWithReturn("You must include what to attack in your command.");
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
