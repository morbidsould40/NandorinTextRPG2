using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableMobs : MonoBehaviour {

    CombatManager combatManager;

    void Awake ()
    {
        combatManager = GetComponent<CombatManager>();
	}

    public void ExamineKeyword(string keywordNoun)
    {
        Debug.Log("Attempting to attack a " + keywordNoun);
        combatManager.combatState = CombatManager.CombatState.StartCombat;
        combatManager.CombatStateMachine(keywordNoun);
    }
}
