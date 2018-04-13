using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextRPG/Items/Armor")]
public class Armor : Items {

    public float armorDefense;

    public enum ArmorType
    {
        Light, Heavy
    }
    public ArmorType armorType;

    public enum ArmorSlot
    {
        Head, Shoulders, Arms, Hands, Chest, Waist, Legs, Feet, Neck, Finger, Ear
    }
    public ArmorSlot armorSlot;

    public enum Rarity
    {
        Common, Uncommon, Rare, Epic, Relic, Artifact
    }
    public Rarity rarity;

    public bool isUnique = false;
    public bool isDroppable = true;

    public GearBonuses[] gearBonuses;
}
