using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePriestClass : BaseCharacter {

    public BasePriestClass()
    {
        CharacterClassName = "Priest";
        CharacterClassDescription = "The priest is the healer and buffer, casting spells to boost their abilities.";
        MainStat = MainStatBonuses.Endurance;
        SecondMainStat = SecondaryStatBonuses.Magic;
        LeastStat = LeastStatBonuses.Agility;

        Strength = 5;
        Agility = 6;
        Endurance = 4;
        Magic = 7;
    }
}
