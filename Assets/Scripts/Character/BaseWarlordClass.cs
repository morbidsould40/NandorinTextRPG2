using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWarlordClass : BaseCharacter {

    public BaseWarlordClass()
    {
        CharacterClassName = "Warlord";
        CharacterClassDescription = "The warlord is the master of all things martial. His pure strength will challenge any foe.";
        MainStat = MainStatBonuses.Strength;
        SecondMainStat = SecondaryStatBonuses.Endurance;
        LeastStat = LeastStatBonuses.Magic;

        CalculateStats();
    }
}
