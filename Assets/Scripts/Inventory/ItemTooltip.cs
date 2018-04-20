using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour {

    [SerializeField] Text ItemNameText;
    [SerializeField] Text ItemSlotText;
    [SerializeField] Text ItemStatsText;

    private StringBuilder sb = new StringBuilder();

    public void ShowToolTip(EquippableItems item)
    {
        ItemNameText.text = item.itemName;
        ItemSlotText.text = item.equipmentType.ToString();

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
