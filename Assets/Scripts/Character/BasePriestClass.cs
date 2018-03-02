using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePriestClass : BaseCharacter {

    public BasePriestClass()
    {
        CharacterClassName = "Priest";
        CharacterClassDescription = "The priest is the healer and buffer, casting spells to boost their abilities.";
        MainStat = MainStatBonuses.Magic;
        SecondMainStat = SecondaryStatBonuses.Endurance;
        LeastStat = LeastStatBonuses.Agility;

        CalculateStats();
    }
}
