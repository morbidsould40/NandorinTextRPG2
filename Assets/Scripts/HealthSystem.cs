using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour {

    public float currentHealth;
    public float maxHealth;
    public float currentMana;
    public float MaxMana;
    public SimpleHealthBar healthBar;
    public SimpleHealthBar manaBar;
    public Text healthDisplay;
    public Text manaDisplay;
    public Player player;
    

    // Use this for initialization
	void Start ()
    {        
        currentHealth = player.PlayerCurrentHealth;
        maxHealth = player.PlayerMaxHealth;
        currentMana = player.PlayerCurrentMana;
        MaxMana = player.PlayerMaxMana;
        
	}
	
	// Update is called once per frame
	void Update () {
        healthDisplay.text = currentHealth + "/" + maxHealth;
        manaDisplay.text = currentMana + "/" + MaxMana;
        healthBar.UpdateBar(currentHealth, maxHealth);
        manaBar.UpdateBar(currentMana, MaxMana);
    }
}
