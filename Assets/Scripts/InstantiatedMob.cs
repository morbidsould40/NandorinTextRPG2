using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatedMob : MonoBehaviour {

    public string mobName;
    public string mobID;
    public float mobCurrentHealth;
    public float mobCurrentMana;
    public float mobAttack;
    public float mobDefense;

    private void Start()
    {
        var so = GetComponent<Monsters>();
        mobName = so.monsterName;
        mobCurrentHealth = so.monsterMaxHealth;
        mobCurrentMana = so.monsterMaxMana;
        mobAttack = so.monsterAttack;
        mobDefense = so.monsterDefense;
    }
}
