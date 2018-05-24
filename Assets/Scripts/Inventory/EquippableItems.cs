using UnityEngine;
using RPG.CharacterStats;

public enum EquipmentType
{
    Head, Shoulders, Arms, Hands, Chest, Waist, Legs, Feet, Neck, Finger, Ear, Weapon
}

public class EquippableItems : Items {

    [Header("Main Stat Bonus")]
    public float strengthBonus;
    public float agilityBonus;
    public float enduranceBonus;
    public float magicBonus;
    public float attackBonus;
    public float defenseBonus;
    public float healthBonus;
    public float manaBonus;
    public float staminaBonus;
    public float resistanceBonus;
    public float damageBonus;
    public float critChanceBonus;
    public float multiAttackChanceBonus;
    [Space]
    public float strengthPercentBonus;
    public float agilityPercentBonus;
    public float endurancePercentBonus;
    public float magicPercentBonus;
    public float attackPercentBonus;
    public float defensePercentBonus;
    public float healthPercentBonus;
    public float manaPercentBonus;
    public float staminaPercentBonus;
    public float resistancePercentBonus;
    public float damagePercentBonus;
    public float critChancePercentBonus;
    public float multiAttackChancePercentBonus;
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
        if (resistanceBonus != 0)
            c.Resistance.AddModifier(new StatModifier(resistanceBonus, StatModType.Flat, this));        
        if (damageBonus != 0)
            c.DamageBonus.AddModifier(new StatModifier(damageBonus, StatModType.Flat, this));
        if (critChanceBonus != 0)
            c.CritChance.AddModifier(new StatModifier(critChanceBonus, StatModType.Flat, this));
        if (multiAttackChanceBonus != 0)
            c.MultiAttackChance.AddModifier(new StatModifier(multiAttackChanceBonus, StatModType.Flat, this));

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
        if (resistanceBonus != 0)
            c.Resistance.AddModifier(new StatModifier(resistanceBonus, StatModType.PercentMult, this));
        if (damageBonus != 0)
            c.DamageBonus.AddModifier(new StatModifier(damageBonus, StatModType.PercentMult, this));
        if (critChanceBonus != 0)
            c.CritChance.AddModifier(new StatModifier(critChanceBonus, StatModType.PercentMult, this));
        if (multiAttackChanceBonus != 0)
            c.MultiAttackChance.AddModifier(new StatModifier(multiAttackChanceBonus, StatModType.PercentMult, this));


        if (healthBonus != 0)
        {
            c.playerManagement.maxHealth += healthBonus;
            c.playerManagement.currentHealth += healthBonus;
        }

        if (manaBonus != 0)
        {
            c.playerManagement.maxMana += manaBonus;
            c.playerManagement.currentMana += manaBonus;
        }

        if (staminaBonus != 0)
        {
            c.playerManagement.maxStamina += staminaBonus;
            c.playerManagement.currentStamina += staminaBonus;
        }

        if (healthPercentBonus != 0)
        {
            c.playerManagement.maxHealth += healthPercentBonus;
            c.playerManagement.currentHealth += healthPercentBonus;
        }

        if (manaPercentBonus != 0)
        {
            c.playerManagement.maxMana += manaPercentBonus;
            c.playerManagement.currentMana += manaPercentBonus;
        }

        if (staminaPercentBonus != 0)
        {
            c.playerManagement.maxStamina += staminaPercentBonus;
            c.playerManagement.currentStamina += staminaPercentBonus;
        }
    }

    public void Unequip(Character c)
    {
        c.Strength.RemoveAllModifiersFromSource(this);
        c.Agility.RemoveAllModifiersFromSource(this);
        c.Endurance.RemoveAllModifiersFromSource(this);
        c.Magic.RemoveAllModifiersFromSource(this);
        c.Attack.RemoveAllModifiersFromSource(this);
        c.Defense.RemoveAllModifiersFromSource(this);
        c.Resistance.RemoveAllModifiersFromSource(this);
        c.DamageBonus.RemoveAllModifiersFromSource(this);
        c.CritChance.RemoveAllModifiersFromSource(this);
        c.MultiAttackChance.RemoveAllModifiersFromSource(this);
        c.playerManagement.maxHealth -= healthBonus;
        c.playerManagement.currentHealth -= healthBonus;
        c.playerManagement.maxMana -= manaBonus;
        c.playerManagement.currentMana -= manaBonus;
        c.playerManagement.maxStamina -= staminaBonus;
        c.playerManagement.currentStamina -= staminaBonus;        
    }
}


