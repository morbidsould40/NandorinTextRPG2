﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.CharacterStats;



public class Items : ScriptableObject {

    public string itemName;
    public string itemID;
    [TextArea]
    public string itemDesc;
    public Sprite itemIcon;
    public int itemCost;
    public float itemWeight;

    public enum ItemType
    {
        Accessory, Armor, Crafting, Item, Potion, Weapon
    }
    public ItemType itemType;

    public enum Rarity
    {
        Common, Uncommon, Rare, Epic, Relic, Artifact
    }
    public Rarity rarity;

    public bool isUnique = false;
    public bool isDroppable = true;
    public bool isConsumable = false;
}
