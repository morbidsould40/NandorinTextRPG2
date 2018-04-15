using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextRPG/Items/Armor")]
public class Armor : EquippableItems {

    public float armorDefense;

    public enum ArmorType
    {
        Light, Heavy
    }
    public ArmorType armorType;
}
