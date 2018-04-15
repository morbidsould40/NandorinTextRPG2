using UnityEngine;

public class InventoryManager : MonoBehaviour {

    [SerializeField] InventoryWindow inventory;
    [SerializeField] EquipmentPanel equipmentPanel;

    private void Awake()
    {
        inventory.OnItemRightClickedEvent += EquipFromInventory;
        equipmentPanel.OnItemRightClickedEvent += UnequipFromEquipPanel;
    }

    private void EquipFromInventory(Items item)
    {
        if (item is EquippableItems)
        {
            Equip((EquippableItems)item);
        }
    }

    private void UnequipFromEquipPanel(Items item)
    {
        if (item is EquippableItems)
        {
            Unequip((EquippableItems)item);
        }
    }

    public void Equip(EquippableItems item)
    {
        if (inventory.RemoveItem(item))
        {
            EquippableItems previousItem;
            if (equipmentPanel.AddItem(item, out previousItem))
            {
                if (previousItem != null)
                {
                    inventory.AddItem(previousItem);
                }
            }
            else
            {
                inventory.AddItem(item);
            }
        }
    }

    public void Unequip(EquippableItems item)
    {
        if (!inventory.IsFull() && equipmentPanel.RemoveItem(item))
        {
            inventory.AddItem(item);
        }
    }

}
