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

    public GearBonuses[] gearBonuses;
}
