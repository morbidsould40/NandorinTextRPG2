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

    public void UpdatePlayerGold(int value)
    {
        if (player.PlayerGold >= 0)
        {
            player.PlayerGold += value;
        }
        else
        {
            player.PlayerGold = 0;
        }
    }

    public void UpdatePlayerExperience(int value)
    {
        if (player.PlayerCurrentExperience >= 1)
        {
            player.PlayerCurrentExperience += value;
            CheckIfPlayerLeveled(player.PlayerCurrentExperience);
        }
        else
        {
            player.PlayerCurrentExperience = 1;
        }
    }

    public void CheckIfPlayerLeveled(int currentExp)
    {
        // check if the amount of exp the player has exceeds the amount needed for next level
    }


}
