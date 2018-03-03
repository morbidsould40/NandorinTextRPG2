public class BaseBlackGuardClass : BaseCharacter
{

    public BaseBlackGuardClass()
    {
        CharacterClassName = "Blackguard";
        CharacterClassDescription = "A thief type character who can deal extra damage while hidden.";
        MainStat = MainStatBonuses.Agility;
        SecondMainStat = SecondaryStatBonuses.Strength;
        BaseStat = BaseStatBonuses.Endurance;
        LeastStat = LeastStatBonuses.Magic;

        CalculateStats();
        





                
    }
}
