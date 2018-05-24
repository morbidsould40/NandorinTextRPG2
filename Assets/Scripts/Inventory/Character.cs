using System;
using UnityEngine;
using RPG.CharacterStats;

public class Character : MonoBehaviour {

    public CharacterStats Strength;
    public CharacterStats Agility;
    public CharacterStats Endurance;
    public CharacterStats Magic;
    public CharacterStats Attack;
    public CharacterStats Defense;
    public CharacterStats Resistance;
    public CharacterStats DamageBonus;
    public CharacterStats CritChance;
    public CharacterStats MultiAttackChance;
    [HideInInspector] public PlayerManagement playerManagement;
    [HideInInspector] public Player player;    
    [SerializeField] InventoryWindow inventory;
    [SerializeField] EquipmentPanel equipmentPanel;
    [SerializeField] StatPanel statPanel;

    private void Awake()
    {
        inventory.OnItemRightClickedEvent += EquipFromInventory;
        equipmentPanel.OnItemRightClickedEvent += UnequipFromEquipPanel;
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        playerManagement = FindObjectOfType<PlayerManagement>();

        Strength.BaseValue = player.PlayerStrength;
        Agility.BaseValue = player.PlayerAgility;
        Endurance.BaseValue = player.PlayerEndurance;
        Magic.BaseValue = player.PlayerMagic;        
        Attack.BaseValue = CalculateAttack();
        Defense.BaseValue = CalculateDefense();
        Resistance.BaseValue = 0; // TODO Need to come up with formula for resistance
        DamageBonus.BaseValue = ((player.PlayerStrength / 5) * player.PlayerLevel);
        CritChance.BaseValue = ((player.PlayerAgility / 10) * player.PlayerLevel);

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

                    Attack.BaseValue = CalculateAttack();
                    Defense.BaseValue = CalculateDefense();
                    statPanel.UpdateStatValues();
                }
                item.Equip(this);
                Attack.BaseValue = CalculateAttack();
                Defense.BaseValue = CalculateDefense();
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
            Attack.BaseValue = CalculateAttack();
            Defense.BaseValue = CalculateDefense();
            statPanel.UpdateStatValues();
            inventory.AddItem(item);
        }
    }

    private float CalculateAttack()
    {
        float totalAttack = Attack.Value;
        totalAttack = Agility.Value / 2; 
        return (float)Math.Round(totalAttack, 2);
    }

    private float CalculateDefense()
    {
        float totalDefense = Defense.Value;
        totalDefense = Strength.Value / 5;
        return (float)Math.Round(totalDefense, 2);
    }
}
