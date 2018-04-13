using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextRPG/Items/Weapons")]
public class Weapons : Items {

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

    public GearBonuses[] gearBonuses;
}
