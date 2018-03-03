public class BaseCharacter{

    private string characterClassName;
    private string characterClassDescription;

    //Stats
    private int strength = 5;
    private int agility = 5;    
    private int endurance = 5;
    private int magic = 5;
    private int mainStatBonus = 2;
    private int secondaryStatBonus = 1;
    private int baseStatBonus = 0;
    private int leastStatBonus = -1;    

    public enum BaseClasses
    {
        Blackguard, Cleric, Thaumaturge, Warlord
    }

    public enum MainStatBonuses
    {
        Strength, Agility, Endurance, Magic
    }

    public enum SecondaryStatBonuses
    {
        Strength, Agility, Endurance, Magic
    }

    public enum BaseStatBonuses
    {
        Strength, Agility, Endurance, Magic
    }

    public enum LeastStatBonuses
    {
        Strength, Agility, Endurance, Magic
    }

    public string CharacterClassName
    {
        get { return characterClassName; }
        set { characterClassName = value; }
    }

    public string CharacterClassDescription
    {
        get { return characterClassDescription; }
        set { characterClassDescription = value; }
    }

    public MainStatBonuses MainStat { get; set; }
    public SecondaryStatBonuses SecondMainStat { get; set; }
    public BaseStatBonuses BaseStat { get; set; }
    public LeastStatBonuses LeastStat { get; set; }

    public int Strength
    {
        get { return strength; }
        set { strength = value; }
    }

    public int Agility
    {
        get { return agility; }
        set { agility = value; }
    }

    public int Endurance
    {
        get { return endurance; }
        set { endurance = value; }
    }

    public int Magic
    {
        get { return magic; }
        set { magic = value; }
    }  
    
    public int MainStatBonus
    {
        get { return mainStatBonus; }
    }

    public int SecondaryStatBonus
    {
        get { return secondaryStatBonus; }
    }

    public int BaseStatBonus
    {
        get { return baseStatBonus; }
    }

    public int LeastStatBonus
    {
        get { return leastStatBonus; }
    }

    public void CalculateStats()
    {
        if (MainStat == MainStatBonuses.Strength)
        {
            Strength += MainStatBonus;
        }
        else if (MainStat == MainStatBonuses.Agility)
        {
            Agility += MainStatBonus;
        }
        else if (MainStat == MainStatBonuses.Endurance)
        {
            Endurance += MainStatBonus;
        }
        else if (MainStat == MainStatBonuses.Magic)
        {
            Magic += MainStatBonus;
        }

        if (SecondMainStat == SecondaryStatBonuses.Strength)
        {
            Strength += SecondaryStatBonus;
        }
        else if (SecondMainStat == SecondaryStatBonuses.Agility)
        {
            Agility += SecondaryStatBonus;
        }
        else if (SecondMainStat == SecondaryStatBonuses.Endurance)
        {
            Endurance += SecondaryStatBonus;
        }
        else if (SecondMainStat == SecondaryStatBonuses.Magic)
        {
            Magic += SecondaryStatBonus;
        }

        if (BaseStat == BaseStatBonuses.Strength)
        {
            Strength += BaseStatBonus;
        }
        else if (BaseStat == BaseStatBonuses.Agility)
        {
            Agility += BaseStatBonus;
        }
        else if (BaseStat == BaseStatBonuses.Endurance)
        {
            Endurance += BaseStatBonus;
        }
        else if (BaseStat == BaseStatBonuses.Magic)
        {
            Magic += BaseStatBonus;
        }

        if (LeastStat == LeastStatBonuses.Strength)
        {
            Strength += LeastStatBonus;
        }
        else if (LeastStat == LeastStatBonuses.Agility)
        {
            Agility += LeastStatBonus;
        }
        else if (LeastStat == LeastStatBonuses.Endurance)
        {
            Endurance += LeastStatBonus;
        }
        else if (LeastStat == LeastStatBonuses.Magic)
        {
            Magic += LeastStatBonus;
        }
    }
}
