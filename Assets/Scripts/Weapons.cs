using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextRPG/Items/Weapons")]
public class Weapons : ScriptableObject {

    public string weaponName;
    public string weaponID;
    [TextArea]
    public string weaponDesc;
    public Sprite weaponIcon;
    public int weaponCost;
    public float weaponMinDamage;
    public float weaponMaxDamage;
    public float weaponAttack;

    public enum WeaponType
    {
        Axe, Club, Dagger, Flail, Mace, Shield, Staff, Sword, Wand, Warhammer
    }
    public WeaponType weaponType;

    public enum WeaponHandType
    {
        OneHanded, TwoHanded, MagicUserOnly
    }
    public WeaponHandType weaponHandType;

    public enum DamageType
    {
        Blunt, Slashing, Piercing, Magic
    }
    public DamageType damageType;

    public enum Rarity
    {
        Common, Uncommon, Rare, Epic, Relic, Artifact
    }
    public Rarity rarity;

    public bool isUnique = false;
    public bool isDroppable = true;

    public GearBonuses[] gearBonuses;
}
