using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManagement : MonoBehaviour {

    public float currentHealth;
    public float maxHealth;
    public float currentMana;
    public float maxMana;
    public float currentStamina;
    public float maxStamina;
    public SimpleHealthBar healthBar;
    public SimpleHealthBar manaBar;
    public SimpleHealthBar staminaBar;
    public Text healthDisplay;
    public Text manaDisplay;
    public Text staminaDisplay;
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
        playerLevel.text = player.PlayerLevel.ToString();
        playerExp.text = player.PlayerCurrentExperience.ToString();
        playerGold.text = player.PlayerGold.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        currentHealth = player.PlayerCurrentHealth;
        maxHealth = player.PlayerMaxHealth;
        currentMana = player.PlayerCurrentMana;
        maxMana = player.PlayerMaxMana;
        currentStamina = player.PlayerCurrentStamina;
        maxStamina = player.PlayerMaxStamina;
        healthDisplay.text = currentHealth + "/" + maxHealth;
        manaDisplay.text = currentMana + "/" + maxMana;
        staminaDisplay.text = currentStamina + "/" + maxStamina;
        healthBar.UpdateBar(currentHealth, maxHealth);
        manaBar.UpdateBar(currentMana, maxMana);
        staminaBar.UpdateBar(currentStamina, maxStamina);
    }

    public bool CheckIfPlayerHasEnoughGold(int value)
    {
        if (player.PlayerGold >= value)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void UpdatePlayerGold(int value)
    {
        if (player.PlayerGold >= 0)
        {
            player.PlayerGold += value;
            playerGold.text = player.PlayerGold.ToString();

        }
        else
        {
            player.PlayerGold = 0;
            playerGold.text = player.PlayerGold.ToString();
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
