using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Items : ScriptableObject {

    public string itemName;
    public string itemID;
    [TextArea]
    public string itemDesc;
    public Sprite itemIcon;
    public int itemCost;
    public float itemWeight;

    public enum Rarity
    {
        Common, Uncommon, Rare, Epic, Relic, Artifact
    }
    public Rarity rarity;

    public EquipmentType equipmentType;

    public bool isUnique = false;
    public bool isDroppable = true;
    public bool isConsumable = false;
}
