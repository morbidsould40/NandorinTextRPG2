public class BaseCharacter{

    private string characterClassName;
    private string characterClassDescription;

    //Stats
    private int strength = 5;
    private int agility = 5;    
    private int endurance = 5;
    private int magic = 5;

    public enum BaseClasses
    {
        Blackguard, Priest, Thaumaturge, Warlord
    }

    public enum MainStatBonuses
    {
        Strength, Agility, Endurance, Magic
    }

    public enum SecondaryStatBonuses
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

}
