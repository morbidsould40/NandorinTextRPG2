using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterCreation : MonoBehaviour {

    public Dropdown dropdown;
    public Text classDescriptions;
    public InputField playerNameInput;
    public Player player;
    public Room startingRoom;

    private BaseCharacter baseCharacter;
    private BasePlayer newPlayer;
        
    private void Start()
    {
        newPlayer = new BasePlayer();
        PopulateClassesList();
        newPlayer.PlayerClass = new BaseBlackGuardClass();
        classDescriptions.text = newPlayer.PlayerClass.CharacterClassDescription +
            CalculateStats(BaseCharacter.BaseClasses.Blackguard.ToString());
    }

    public void OnClick_StartGame()
    {
        newPlayer.PlayerName = playerNameInput.text;
        newPlayer.PlayerLevel = 1;
        newPlayer.Strength = newPlayer.PlayerClass.Strength;
        newPlayer.Agility = newPlayer.PlayerClass.Agility;
        newPlayer.Endurance = newPlayer.PlayerClass.Endurance;
        newPlayer.Magic = newPlayer.PlayerClass.Magic;
        newPlayer.CurrentGold = 20;
        newPlayer.MaxHealth = ((newPlayer.PlayerClass.Endurance * 3) + (newPlayer.PlayerLevel * 2)) * 2;
        newPlayer.MaxMana = ((newPlayer.PlayerClass.Magic * 3) + (newPlayer.PlayerLevel * 3) * 2);
        newPlayer.MaxStamina = ((player.PlayerEndurance * 4) + (player.PlayerLevel * 2));
        
        newPlayer.CurrentExp = 1;
        StorePlayerInfo();
        SceneManager.LoadScene(1); 
    }

    private void StorePlayerInfo()
    {
        player.PlayerName = newPlayer.PlayerName;
        player.PlayerLevel = newPlayer.PlayerLevel;
        player.PlayerStrength = newPlayer.Strength;
        player.PlayerAgility = newPlayer.Agility;
        player.PlayerEndurance = newPlayer.Endurance;
        player.PlayerMagic = newPlayer.Magic;
        player.PlayerGold = newPlayer.CurrentGold;
        player.PlayerMaxHealth = newPlayer.MaxHealth;
        player.PlayerCurrentHealth = newPlayer.MaxHealth;
        player.PlayerMaxMana = newPlayer.MaxMana;
        player.PlayerCurrentMana = newPlayer.MaxMana;
        player.PlayerMaxStamina = newPlayer.MaxStamina;
        player.PlayerCurrentStamina = newPlayer.MaxStamina;
        player.PlayerCurrentExperience = newPlayer.CurrentExp;
        player.PlayerClass = newPlayer.PlayerClass.CharacterClassName;
        player.CurrentRoom = startingRoom;
    }

    public void Dropdown_IndexChanged(int index)
    {
        BaseCharacter.BaseClasses className = (BaseCharacter.BaseClasses)index;
        
        switch (className)
        {
            case BaseCharacter.BaseClasses.Blackguard:
                newPlayer.PlayerClass = new BaseBlackGuardClass();
                classDescriptions.text = newPlayer.PlayerClass.CharacterClassDescription + CalculateStats(className.ToString());
                    break;
            case BaseCharacter.BaseClasses.Cleric:
                newPlayer.PlayerClass = new BaseClericClass();
                classDescriptions.text = newPlayer.PlayerClass.CharacterClassDescription + CalculateStats(className.ToString()); 
                break;
            case BaseCharacter.BaseClasses.Thaumaturge:
                newPlayer.PlayerClass = new BaseThaumaturgeClass();
                classDescriptions.text = newPlayer.PlayerClass.CharacterClassDescription + CalculateStats(className.ToString());
                break;
            case BaseCharacter.BaseClasses.Warlord:
                newPlayer.PlayerClass = new BaseWarlordClass();
                classDescriptions.text = newPlayer.PlayerClass.CharacterClassDescription + CalculateStats(className.ToString());
                break;
            default:
                newPlayer.PlayerClass = new BaseBlackGuardClass();
                classDescriptions.text = newPlayer.PlayerClass.CharacterClassDescription;
                break;
        }
    }

    private string CalculateStats(string className)
    {
        if (className == BaseCharacter.BaseClasses.Blackguard.ToString())
        {
            return "\n\n Strength: " + newPlayer.PlayerClass.Strength +
                "\n Agility: " + newPlayer.PlayerClass.Agility +
                "\n Endurance: " + newPlayer.PlayerClass.Endurance +
                "\n Magic: " + newPlayer.PlayerClass.Magic;
        }
        else if (className == BaseCharacter.BaseClasses.Cleric.ToString())
        {
            return "\n\n Strength: " + newPlayer.PlayerClass.Strength +
                "\n Agility: " + newPlayer.PlayerClass.Agility +
                "\n Endurance: " + newPlayer.PlayerClass.Endurance +
                "\n Magic: " + newPlayer.PlayerClass.Magic;
        }
        else if (className == BaseCharacter.BaseClasses.Thaumaturge.ToString())
        {
            return "\n\n Strength: " + newPlayer.PlayerClass.Strength +
                "\n Agility: " + newPlayer.PlayerClass.Agility +
                "\n Endurance: " + newPlayer.PlayerClass.Endurance +
                "\n Magic: " + newPlayer.PlayerClass.Magic;
        }
        else if (className == BaseCharacter.BaseClasses.Warlord.ToString())
        {
            return "\n\n Strength: " + newPlayer.PlayerClass.Strength +
                "\n Agility: " + newPlayer.PlayerClass.Agility +
                "\n Endurance: " + newPlayer.PlayerClass.Endurance +
                "\n Magic: " + newPlayer.PlayerClass.Magic;
        }
        else
        {
            return "Error... no stats found.";
        }
    }

    public void PopulateClassesList()
    {
        string[] classNames = Enum.GetNames(typeof(BaseCharacter.BaseClasses));
        List<string> cNames = new List<string>(classNames);
        dropdown.AddOptions(cNames);
    }
}
