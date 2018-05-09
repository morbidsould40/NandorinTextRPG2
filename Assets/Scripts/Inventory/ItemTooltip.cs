using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour {

    [SerializeField] Text ItemNameText;
    [SerializeField] Text ItemSlotText;
    [SerializeField] Text ItemSlotSpecialText;
    [SerializeField] Text ItemStatsText;

    private StringBuilder sb = new StringBuilder();

    public void ShowToolTip(EquippableItems item)
    {
        var rarity = item.rarity;

        if (rarity == Items.Rarity.Common)
            ItemNameText.text = "<color=#ffffffff>" + item.itemName + "</Color>";
        if (rarity == Items.Rarity.Uncommon)
            ItemNameText.text = "<color=#00ff00ff>" + item.itemName + "</Color>";
        if (rarity == Items.Rarity.Rare)
            ItemNameText.text = "<color=#0088ffff>" + item.itemName + "</Color>";
        if (rarity == Items.Rarity.Epic)
            ItemNameText.text = "<color=#ff00aaff>" + item.itemName + "</Color>";
        if (rarity == Items.Rarity.Relic)
            ItemNameText.text = "<color=#ff0000ff>" + item.itemName + "</Color>";
        if (rarity == Items.Rarity.Artifact)
            ItemNameText.text = "<color=#ffa500ff>" + item.itemName + "</Color>";

        ItemSlotText.text = item.equipmentType.ToString();

        ItemSlotSpecialText.text = "";
        
        if (item.itemType == Items.ItemType.Armor)
        {
            var newItem = item as Armor;
            ItemSlotSpecialText.text = newItem.armorType.ToString();           
        }

        if (item.itemType == Items.ItemType.Weapon)
        {
            var newItem = item as Weapons;
            var weaponHand = newItem.weaponHandType.ToString();

            if (weaponHand == Weapons.WeaponHandType.OneHanded.ToString())            
                weaponHand = "One-Handed";
            
            if (weaponHand == Weapons.WeaponHandType.TwoHanded.ToString())
                weaponHand = "Two-Handed";

            if (weaponHand == Weapons.WeaponHandType.MagicUserOnly.ToString())
                weaponHand = "Magic User Only";

            ItemSlotSpecialText.text = weaponHand + " " + newItem.damageType.ToString();
        }

        sb.Length = 0;

        AddStat(item.strengthBonus, "Strength");
        AddStat(item.agilityBonus, "Agility");
        AddStat(item.enduranceBonus, "Endurance");
        AddStat(item.magicBonus, "Magic");
        AddStat(item.attackBonus, "Attack");
        AddStat(item.defenseBonus, "Defense");

        AddStat(item.strengthPercentBonus, "Strength", isPercent: true);
        AddStat(item.agilityPercentBonus, "Agility", isPercent: true);
        AddStat(item.endurancePercentBonus, "Endurance", isPercent: true);
        AddStat(item.magicPercentBonus, "Magic", isPercent: true);
        AddStat(item.attackPercentBonus, "Attack", isPercent: true);
        AddStat(item.defensePercentBonus, "Defense", isPercent: true);

        ItemStatsText.text = sb.ToString();

        gameObject.SetActive(true);
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false);
    }

    private void AddStat(float value, string statName, bool isPercent = false)
    {
        if (value != 0)
        {
            if (sb.Length > 0)
            {
                sb.AppendLine();
            }

            if (value > 0)
            {
                sb.Append("+");
            }

            if (isPercent)
            {
                sb.Append(value * 100);
                sb.Append("% ");
            }
            else
            {
                sb.Append(value);
                sb.Append(" ");
            }

            sb.Append(statName);
        }
    }
}
