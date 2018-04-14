using UnityEngine;

public class InventoryManager : MonoBehaviour {

    [SerializeField] InventoryWindow inventory;
    [SerializeField] EquipmentPanel equipmentPanel;

    private void Awake()
    {
        inventory.OnItemRightClickEvent += Equip;
        equipmentPanel.OnItemRightClickEvent += UnequipFromEquipPanel;
    }

    private void UnequipFromEquipPanel(Items item)
    {
        Unequip(item);
    }

    public void Equip(Items item)
    {
        if (inventory.RemoveItem(item))
        {
            Items previousItems;
            if (equipmentPanel.AddItem(item, out previousItems))
            {
                if (previousItems != null)
                {
                    inventory.AddItem(previousItems);
                }
            }
            else
            {
                inventory.AddItem(item);
            }
        }
    }

    public void Unequip(Items item)
    {
        if (!inventory.IsFull() && equipmentPanel.RemoveItem(item))
        {
            inventory.AddItem(item);
        }
    }

}
