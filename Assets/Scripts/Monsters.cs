using UnityEngine;

[CreateAssetMenu(menuName = "TextRPG/Monsters")]
public class Monsters : ScriptableObject
{

    public string monsterName;
    public string monsterKeyword;
    public string monsterID;
    [TextArea]
    public string monsterDescription;
    public string monsterType;
    public float spawnChance;
    public float goldDropChance;
    public int goldDroppedMin;
    public int goldDroppedMax;
    public float itemDropChance;
    public Weapons[] weaponsDropped;
    public Armor[] armorDropped;
    public float monsterCurrentHealth;
    public float monsterMaxHealth;
    public float monsterCurrentMana;
    public float monsterMaxMana;
    public float monsterAttack;
    public float monsterDefense;
    public MonsterAttacks[] monsterAttacks;
    
}