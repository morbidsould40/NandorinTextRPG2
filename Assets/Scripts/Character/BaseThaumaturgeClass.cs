using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseThaumaturgeClass : BaseCharacter {

    public BaseThaumaturgeClass()
    {
        CharacterClassName = "Thaumaturge";
        CharacterClassDescription = "A master of the arcane arts, the Thaumaturge is unmatched in their magical abilities.";
        MainStat = MainStatBonuses.Magic;
        SecondMainStat = SecondaryStatBonuses.Agility;
        BaseStat = BaseStatBonuses.Endurance;
        LeastStat = LeastStatBonuses.Strength;

        CalculateStats();
    }
}
