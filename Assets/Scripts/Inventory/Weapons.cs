﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextRPG/Items/Weapons")]
public class Weapons : EquippableItems {

    public float weaponMinDamage;
    public float weaponMaxDamage;

    public enum WeaponType
    {
        Axe, Club, Dagger, Flail, Mace, Shield, Staff, Sword, Wand, Warhammer
    }
    public WeaponType weaponType;

    public enum WeaponHandType
    {
        OneHanded, TwoHanded
    }
    public WeaponHandType weaponHandType;

    public enum DamageType
    {
        Blunt, Slashing, Piercing, Magic
    }
    public DamageType damageType;
}
