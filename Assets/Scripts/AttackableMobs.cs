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
        Debug.Log("Attempting to attack a " + keywordNoun);
        combatManager.combatState = CombatManager.CombatState.StartCombat;
        combatManager.CombatStateMachine(keywordNoun);
    }
}
