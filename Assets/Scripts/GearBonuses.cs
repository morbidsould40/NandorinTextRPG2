[System.Serializable]
public class GearBonuses
{
    public string buffName;

    public enum StatBonus
    {
        Strength, Agility, Endurance, Magic, Attack, Defense, Health, Mana, MinDamage, MaxDamage, CritChance, MultiAttackChance
    }
    public StatBonus statBonus;

    public float statAdjustment;
}
