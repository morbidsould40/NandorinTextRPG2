using UnityEngine;

[CreateAssetMenu(menuName = "TextRPG/MonsterAttacks")]
public class MonsterAttacks : ScriptableObject {

    public string monsterAttackName;
    [TextArea]
    public string monsterAttackDescription;
    public float monsterMinDamage;
    public float monsterMaxDamage;
    public float monsterCritChance;
    public float monsterMultiAttackChance;
}
