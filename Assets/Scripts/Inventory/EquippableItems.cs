using UnityEngine;
using RPG.CharacterStats;

public enum EquipmentType
{
    Head, Shoulders, Arms, Hands, Chest, Waist, Legs, Feet, Neck, Finger1, Finger2, Ear1, Ear2, Weapon1, Weapon2
}

public class EquippableItems : Items {

    [Header("Main Stat Bonus")]
    public float strengthBonus;
    public float agilityBonus;
    public float enduranceBonus;
    public float magicBonus;
    public float attackBonus;
    public float defenseBonus;
    [Space]
    public float strengthPercentBonus;
    public float agilityPercentBonus;
    public float endurancePercentBonus;
    public float magicPercentBonus;
    public float attackPercentBonus;
    public float defensePercentBonus;
    [Space]
    [Header("Other Bonuses")]    
    public float healthBonus;
    public float manaBonus;
    public float minDamageBonus;
    public float maxDamageBonus;
    public float critChanceBonus;
    public float multiAttackChanceBonus;
    [Space]
    public EquipmentType equipmentType;
    
    public void Equip(Character c)
    {
        if (strengthBonus != 0)
            c.Strength.AddModifier(new StatModifier(strengthBonus, StatModType.Flat, this));
        if (agilityBonus != 0)        
            c.Agility.AddModifier(new StatModifier(agilityBonus, StatModType.Flat, this));
        if (enduranceBonus != 0)        
            c.Endurance.AddModifier(new StatModifier(enduranceBonus, StatModType.Flat, this));
        if (magicBonus != 0)
            c.Magic.AddModifier(new StatModifier(magicBonus, StatModType.Flat, this));
        if (attackBonus != 0)
            c.Attack.AddModifier(new StatModifier(attackBonus, StatModType.Flat, this));
        if (defenseBonus != 0)
            c.Defense.AddModifier(new StatModifier(defenseBonus, StatModType.Flat, this));

        if (strengthPercentBonus != 0)
            c.Strength.AddModifier(new StatModifier(strengthPercentBonus, StatModType.PercentMult, this));
        if (agilityPercentBonus != 0)
            c.Agility.AddModifier(new StatModifier(agilityPercentBonus, StatModType.PercentMult, this));
        if (endurancePercentBonus != 0)
            c.Endurance.AddModifier(new StatModifier(endurancePercentBonus, StatModType.PercentMult, this));
        if (magicPercentBonus != 0)
            c.Magic.AddModifier(new StatModifier(magicPercentBonus, StatModType.PercentMult, this));
        if (attackPercentBonus != 0)
            c.Attack.AddModifier(new StatModifier(attackPercentBonus, StatModType.PercentMult, this));
        if (defensePercentBonus != 0)
            c.Defense.AddModifier(new StatModifier(defensePercentBonus, StatModType.PercentMult, this));
    }

    public void Unequip(Character c)
    {
        c.Strength.RemoveAllModifiersFromSource(this);
        c.Agility.RemoveAllModifiersFromSource(this);
        c.Endurance.RemoveAllModifiersFromSource(this);
        c.Magic.RemoveAllModifiersFromSource(this);
        c.Attack.RemoveAllModifiersFromSource(this);
        c.Defense.RemoveAllModifiersFromSource(this);
    }

}


