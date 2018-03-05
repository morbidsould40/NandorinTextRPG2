using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManagement : MonoBehaviour {

    public float currentHealth;
    public float maxHealth;
    public float currentMana;
    public float MaxMana;
    public SimpleHealthBar healthBar;
    public SimpleHealthBar manaBar;
    public Text healthDisplay;
    public Text manaDisplay;
    public Player player;
    public Text playerName;
    public Text playerClass;
    public Text playerLevel;
    public Text playerExp;
    public Text playerGold;

    // Use this for initialization
    void Start ()
    {

        playerName.text = player.PlayerName;
        playerClass.text = player.PlayerClass;        
    }
	
	// Update is called once per frame
	void Update () {
        currentHealth = player.PlayerCurrentHealth;
        maxHealth = player.PlayerMaxHealth;
        currentMana = player.PlayerCurrentMana;
        MaxMana = player.PlayerMaxMana;
        healthDisplay.text = currentHealth + "/" + maxHealth;
        manaDisplay.text = currentMana + "/" + MaxMana;
        healthBar.UpdateBar(currentHealth, maxHealth);
        manaBar.UpdateBar(currentMana, MaxMana);
        playerLevel.text = player.PlayerLevel.ToString();
        playerExp.text = player.PlayerCurrentExperience.ToString();
        playerGold.text = player.PlayerGold.ToString();
    }
}
