using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Dictionary<string, string> inventory = new Dictionary<string, string>();
    public Dictionary<string, string> keyRing = new Dictionary<string, string>();
    public Dictionary<string, string> potions = new Dictionary<string, string>();

    [SerializeField] string playerName;
    [SerializeField] string playerRace;
    [SerializeField] string playerClass;
    [SerializeField] string playerCurrentRoom;
    [SerializeField] int playerLevel;
    [SerializeField] int playerStrength;
    [SerializeField] int playerAgility;
    [SerializeField] int playerEndurance;
    [SerializeField] int playerMagic;
    [SerializeField] float playerCurrentHealth;
    [SerializeField] float playerMaxHealth;
    [SerializeField] float playerCurrentMagicka;
    [SerializeField] float playerMaxMagicka;
    [SerializeField] float playerCurrentExperience;
    [SerializeField] float playerGold;

    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }

    public string PlayerRace
    {
        get { return playerRace; }
        set { playerRace = value; }
    }

    public string PlayerClass
    {
        get { return playerClass; }
        set { playerClass = value; }
    }

    public int PlayerLevel
    {
        get { return playerLevel; }
        set { playerLevel = value; }
    }

    public int PlayerStrength
    {
        get { return playerStrength; }
        set { playerStrength = value; }
    }

    public int PlayerAgility
    {
        get { return playerAgility; }
        set { playerAgility = value; }
    }

    public int PlayerEndurance
    {
        get { return playerEndurance; }
        set { playerEndurance = value; }
    }

    public int PlayerMagic
    {
        get { return playerMagic; }
        set { playerMagic = value; }
    }

    public float PlayerCurrentHealth
    {
        get { return playerCurrentHealth; }
        set { playerCurrentHealth = value; }
    }

    public float PlayerMaxHealth
    {
        get { return playerMaxHealth; }
        set { playerMaxHealth = value; }
    }

    public float PlayerCurrentMagicka
    {
        get { return playerCurrentMagicka; }
        set { playerCurrentMagicka = value; }
    }

    public float PlayerMaxMagicka
    {
        get { return playerMaxMagicka; }
        set { playerMaxMagicka = value; }
    }

    public float PlayerCurrentExperience
    {
        get { return playerCurrentExperience; }
        set { playerCurrentExperience = value; }
    }

    public float PlayerGold
    {
        get { return playerGold; }
        set { playerGold = value; }
    }

    public string PlayerCurrentRoom
    {
        get { return playerCurrentRoom; }
        set { playerCurrentRoom = value; }
    }

    void Awake()
    {

    }

    void Start () {
        DontDestroyOnLoad(this);        
	}
	
	void Update () {
		
	}
}
