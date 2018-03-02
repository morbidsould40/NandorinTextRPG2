using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreation : MonoBehaviour {

    public Dropdown dropdown;
    public Text classDescriptions;

    private BaseCharacter baseCharacter;
    private BasePlayer newPlayer;
    private string playerName;
    
    private void Start()
    {
        //dropdown = GetComponent<Dropdown>();
        newPlayer = new BasePlayer();
        PopulateClassesList();
        newPlayer.PlayerClass = new BaseBlackGuardClass();
        classDescriptions.text = newPlayer.PlayerClass.CharacterClassDescription +
            CalculateStats(BaseCharacter.BaseClasses.Blackguard.ToString());
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
            case BaseCharacter.BaseClasses.Priest:
                newPlayer.PlayerClass = new BasePriestClass();
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
        else if (className == BaseCharacter.BaseClasses.Priest.ToString())
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
