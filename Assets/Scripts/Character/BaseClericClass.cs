using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClericClass : BaseCharacter {

    public BaseClericClass()
    {
        CharacterClassName = "Cleric";
        CharacterClassDescription = "The Cleric is the healer and buffer and can cast spells to boost their abilities.";
        MainStat = MainStatBonuses.Endurance;
        SecondMainStat = SecondaryStatBonuses.Magic;
        BaseStat = BaseStatBonuses.Strength;
        LeastStat = LeastStatBonuses.Agility;

        CalculateStats();
    }
}
