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
    public bool isPlayerInCombat = false;

    Player player;
    Character character;
    CombatManager combatManager;

    void Start ()
    {
        character = FindObjectOfType<Character>();
        player = FindObjectOfType<Player>();
        combatManager = GetComponent<CombatManager>();
        playerName.text = player.PlayerName;
        playerClass.text = player.PlayerClass;
        playerLevel.text = player.PlayerLevel.ToString();
        playerExp.text = player.PlayerCurrentExperience.ToString();
        playerGold.text = player.PlayerGold.ToString();        
        CalculateStartingStats();
        StartCoroutine(RegenerateHealth());
    }

    void Update ()
    {
        healthBar.UpdateBar(currentHealth, maxHealth);
        manaBar.UpdateBar(currentMana, maxMana);
        staminaBar.UpdateBar(currentStamina, maxStamina);
    }

    private void CalculateStartingStats()
    {
        CalculateMaxHealth();
        CalculateMaxMana();
        CalculateMaxStamina();
        currentHealth = maxHealth;
        currentMana = maxMana;
        currentStamina = maxStamina;
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
            playerExp.text = player.PlayerCurrentExperience.ToString();
        }
        else 
        {
            player.PlayerCurrentExperience = 1;
            playerExp.text = player.PlayerCurrentExperience.ToString();
        }
    }

    public void CheckIfPlayerLeveled(int currentExp)
    {
        // check if the amount of exp the player has exceeds the amount needed for next level
    }

    IEnumerator RegenerateHealth()
    {
        while (true)
        {
            if (!isPlayerInCombat)
            {
                if (currentHealth < maxHealth)
                {
                    currentHealth += 2;
                    yield return new WaitForSecondsRealtime(6);
                }
                else
                {
                    yield return null;
                }
            }
            else
            {
                yield return null;
            }
        }
    }
}