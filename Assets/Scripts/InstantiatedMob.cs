using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatedMob : MonoBehaviour {

    public string mobName;
    public string mobKeyword;
    public string mobID;
    public float mobCurrentHealth;
    public float mobMaxHealth;
    public float mobCurrentMana;
    public float mobMaxMana;
    public float mobAttack;
    public float mobDefense;

    public Monsters go;

    private void Start()
    {
        go = GetComponent<Monsters>();
        mobName = go.monsterName;
        mobKeyword = go.monsterKeyword;
        mobCurrentHealth = go.monsterMaxHealth;
        mobMaxHealth = go.monsterMaxHealth;
        mobCurrentMana = go.monsterMaxMana;
        mobCurrentMana = go.monsterMaxMana;
        mobAttack = go.monsterAttack;
        mobDefense = go.monsterDefense;
    }

    
}
