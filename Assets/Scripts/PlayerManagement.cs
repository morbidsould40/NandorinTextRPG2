using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManagement : MonoBehaviour {

    public SimpleHealthBar healthBar;
    public SimpleHealthBar manaBar;
    public SimpleHealthBar staminaBar;   
    public Text playerName;
    public Text playerClass;
    public Text playerLevel;
    public Text playerExp;
    public Text playerGold;
    public float currentHealth;
    public float currentMana;
    public float currentStamina;
    public float maxHealth;
    public float maxMana;
    public float maxStamina;

    Player player;
    Character character;    

    void Start ()
    {
        character = FindObjectOfType<Character>();
        player = FindObjectOfType<Player>();
        playerName.text = player.PlayerName;
        playerClass.text = player.PlayerClass;
        playerLevel.text = player.PlayerLevel.ToString();
        playerExp.text = player.PlayerCurrentExperience.ToString();
        playerGold.text = player.PlayerGold.ToString();
    }
	
	void Update ()
    {
        CalculateMaxHealth();
        CalculateMaxMana();
        CalculateMaxStamina();
        currentHealth = player.PlayerCurrentHealth;
        currentMana = player.PlayerCurrentMana;
        currentStamina = player.PlayerCurrentStamina;
        healthBar.UpdateBar(currentHealth, maxHealth);
        manaBar.UpdateBar(currentMana, maxMana);
        staminaBar.UpdateBar(currentStamina, maxStamina);
    }

    public void CalculateMaxStamina()
    {
        maxStamina = ((character.Endurance.Value * 4) + (player.PlayerLevel * 2));
    }

    public void CalculateMaxMana()
    {
        maxMana = ((character.Magic.Value * 3) + (player.PlayerLevel * 3) * 2);
    }

    public void CalculateMaxHealth()
    {
        maxHealth = ((character.Endurance.Value * 3) + (player.PlayerLevel * 2)) * 2;
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
