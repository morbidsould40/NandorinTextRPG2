public class BaseBlackGuardClass : BaseCharacter
{

    public BaseBlackGuardClass()
    {
        CharacterClassName = "Blackguard";
        CharacterClassDescription = "A thief type character who can deal extra damage while hidden.";
        MainStat = MainStatBonuses.Agility;
        SecondMainStat = SecondaryStatBonuses.Endurance;
        LeastStat = LeastStatBonuses.Magic;

        Strength = 5;
        Agility = 7;
        Endurance = 6;
        Magic = 4;        
    }
}
