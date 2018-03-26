using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableMobs : MonoBehaviour {

    GameController controller;
    CombatManager combatManager;

    void Awake ()
    {
        controller = GetComponent<GameController>();
        combatManager = GetComponent<CombatManager>();
	}

    public void ExamineKeyword(string keywordNoun)
    {
        combatManager.StartCombat(keywordNoun);
    }
}
