using UnityEngine;

[CreateAssetMenu(menuName = "TextRPG/Monsters")]
public class Monsters : ScriptableObject
{

    public string monsterName;
    [TextArea]
    public string monsterDescription;
    public string monsterType;
    public float spawnChance;
    public float goldDropChance;
    public float itemDropChance;
    public Items[] itemsDropped;
    public float monsterCurrentHealth;
    public float monsterMaxHealth;
    public float monsterCurrentMana;
    public float monsterMaxMana;
    public float monsterAttack;
    public float monsterDefense;
    public MonsterAttacks[] monsterAttacks;
}