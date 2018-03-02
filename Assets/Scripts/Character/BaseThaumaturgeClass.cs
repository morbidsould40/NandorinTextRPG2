using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseThaumaturgeClass : BaseCharacter {

    public BaseThaumaturgeClass()
    {
        CharacterClassName = "Thaumaturge";
        CharacterClassDescription = "A master of the arcane arts, the Thaumaturge is unmatch in their magical abilities.";
        MainStat = MainStatBonuses.Magic;
        SecondMainStat = SecondaryStatBonuses.Agility;
        LeastStat = LeastStatBonuses.Strength;

        Strength = 4;
        Agility = 6;
        Endurance = 5;
        Magic = 7;
    }
}
