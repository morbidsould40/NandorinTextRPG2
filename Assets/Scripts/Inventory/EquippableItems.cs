using UnityEngine;

public enum EquipmentType
{
    Head, Shoulders, Arms, Hands, Chest, Waist, Legs, Feet, Neck, Finger1, Finger2, Ear1, Ear2, Weapon1, Weapon2
}

public class EquippableItems : Items {

    [Header("Main Stat Bonus")]
    public int strengthBonus;
    public int agilityBonus;
    public int enduranceBonus;
    public int magicBonus;
    [Space]
    [Header("Other Bonuses")]
    public int attackBonus;
    public int defenseBonus;
    public int healthBonus;
    public int manaBonus;
    public int minDamageBonus;
    public int maxDamageBonus;
    public int critChanceBonus;
    public int multiAttackChanceBonus;
    [Space]
    public EquipmentType equipmentType;
}
