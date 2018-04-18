using UnityEngine;
using RPG.CharacterStats;

public class Character : MonoBehaviour {

    public CharacterStats Strength;
    public CharacterStats Agility;
    public CharacterStats Endurance;
    public CharacterStats Magic;
    public CharacterStats Attack;
    public CharacterStats Defense;

    [SerializeField] InventoryWindow inventory;
    [SerializeField] EquipmentPanel equipmentPanel;
    [SerializeField] StatPanel statPanel;

    Player player;

    private void Awake()
    {
        inventory.OnItemRightClickedEvent += EquipFromInventory;
        equipmentPanel.OnItemRightClickedEvent += UnequipFromEquipPanel;
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();

        Strength.BaseValue = player.PlayerStrength;
        Agility.BaseValue = player.PlayerAgility;
        Endurance.BaseValue = player.PlayerEndurance;
        Magic.BaseValue = player.PlayerMagic;
        Attack.BaseValue = player.PlayerAttack;
        Defense.BaseValue = player.PlayerDefense;

        statPanel.SetStats(Strength, Agility, Endurance, Magic, Attack, Defense);
        statPanel.UpdateStatValues();
    }

    public void EquipFromInventory(Items item)
    {
        if (item is EquippableItems)
        {
            Equip((EquippableItems)item);
        }
    }

    public void UnequipFromEquipPanel(Items item)
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
                    previousItem.Unequip(this);
                    statPanel.UpdateStatValues();
                }
                item.Equip(this);
                statPanel.UpdateStatValues();
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
            item.Unequip(this);
            statPanel.UpdateStatValues();
            inventory.AddItem(item);
        }
    }

}
