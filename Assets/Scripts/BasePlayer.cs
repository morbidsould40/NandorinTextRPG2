public class BasePlayer{

    private BaseCharacter playerClass;
    private string playerName;
    private int strength;
    private int agility;
    private int endurance;
    private int magic;
    private int maxHealth;
    private int maxMana;
    private int playerLevel;
    private int currentExp;
    private int requiredExp;
    private int currentGold;

    public BaseCharacter PlayerClass
    {
        get { return playerClass; }
        set { playerClass = value; }
    }

    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }

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

    public int MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    public int MaxMana
    {
        get { return maxMana; }
        set { maxMana = value; }
    }

    public int PlayerLevel
    {
        get { return playerLevel; }
        set { playerLevel = value; }
    }

    public int CurrentExp
    {
        get { return currentExp; }
        set { currentExp = value; }
    }

    public int RequiredExp
    {
        get { return requiredExp; }
        set { requiredExp = value; }
    }

    public int CurrentGold
    {
        get { return currentGold; }
        set { currentGold = value; }
    }
}
