public class BaseBlackGuardClass : BaseCharacter
{

    public BaseBlackGuardClass()
    {
        CharacterClassName = "Blackguard";
        CharacterClassDescription = "A thief type character who can deal extra damage while hidden.";
        MainStat = MainStatBonuses.Agility;
        SecondMainStat = SecondaryStatBonuses.Endurance;
        BaseStat = BaseStatBonuses.Strength;
        LeastStat = LeastStatBonuses.Magic;

        CalculateStats();
        





                
    }
}
