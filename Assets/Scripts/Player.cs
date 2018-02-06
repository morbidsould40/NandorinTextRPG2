using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Room currentRoom;
    public GameController controller;

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
    [SerializeField] int playerIntellect;
    [SerializeField] int playerEndurance;
    [SerializeField] int playerVitality;
    [SerializeField] int playerCharm;
    [SerializeField] float playerCurrentHealth;
    [SerializeField] float playerMaxHealth;
    [SerializeField] float playerCurrentMana;
    [SerializeField] float playerMaxMana;
    [SerializeField] float playerGold;

    public enum Races
    {
        Dweller, Fallen, Human, KelDral, Touched, Steamforged
    }

    public enum Classes
    {
        Blackguard, Bowman, Priest, Thaumaturge, Warden, Warlord
    }

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

    public int PlayerIntellect
    {
        get { return playerIntellect; }
        set { playerIntellect = value; }
    }

    public int PlayerEndurance
    {
        get { return playerEndurance; }
        set { playerEndurance = value; }
    }

    public int PlayerVitality
    {
        get { return playerVitality; }
        set { playerVitality = value; }
    }

    public int PlayerCharm
    {
        get { return playerCharm; }
        set { playerCharm = value; }
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

    public float PlayerCurrentMana
    {
        get { return playerCurrentMana; }
        set { playerCurrentMana = value; }
    }

    public float PlayerMaxMana
    {
        get { return playerMaxMana; }
        set { playerMaxMana = value; }
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
        controller = GetComponent<GameController>();
    }

    void Start () {
		
	}
	
	void Update () {
		
	}
}
