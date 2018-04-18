﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentPanel : MonoBehaviour {

    [SerializeField] Transform equipmentSlotsParent;
    [SerializeField] EquipmentSlot[] equipmentSlots;

    public event Action<Items> OnItemRightClickedEvent;

    private Text[] equippableSlotLabel;

    private void Start()
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            equipmentSlots[i].OnRightClickEvent += OnItemRightClickedEvent;
        }
    }

    private void OnValidate()
    {
        equipmentSlots = equipmentSlotsParent.GetComponentsInChildren<EquipmentSlot>();
        equippableSlotLabel = equipmentSlotsParent.GetComponentsInChildren<Text>();
    }

    public bool AddItem(EquippableItems item, out EquippableItems previousItem)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].equipmentType == item.equipmentType)
            {
                previousItem = (EquippableItems)equipmentSlots[i].Item;
                equipmentSlots[i].Item = item;
                equippableSlotLabel[i].enabled = false;
                return true;
            }            
        }
        previousItem = null;
        return false;
    }

    public bool RemoveItem(EquippableItems item)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].Item == item)
            {
                equipmentSlots[i].Item = null;
                equippableSlotLabel[i].enabled = true;
                return true;
            }
        }
        return false;
    }
}
