﻿using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoomNavigation : MonoBehaviour
{

    public Room currentRoom;
    public Player player;
    [HideInInspector] public Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>();
    [HideInInspector] public Dictionary<string, string> examineDictionary = new Dictionary<string, string>();
    [HideInInspector] public Dictionary<string, string> mobsDictionary = new Dictionary<string, string>();
    
    GameController controller;
    Character character;
    PlayerManagement playerManagement;
    
    private void Awake()
    {
        controller = GetComponent<GameController>();
        character = FindObjectOfType<Character>();
        playerManagement = GetComponent<PlayerManagement>();
    }

    private void Start()
    {        
        currentRoom = player.CurrentRoom;
    }

    public void UnpackExitsInRoom()
    {
        for (int i = 0; i < currentRoom.exits.Length; i++)
        {
            // find all exits for this room and put them into a dictionary (direction, room)
            exitDictionary.Add(currentRoom.exits[i].keyString, currentRoom.exits[i].valueRoom);
            // find all descriptions for exits and put them into a list in GameController
            controller.interactiveDescriptionsInRoom.Add(currentRoom.exits[i].exitDescription);
        }
    }

    public void UnpackExaminablesInRoom()
    {
        for (int i = 0; i < currentRoom.examinableObjectsInRoom.Length; i++)
        {
            // finds all examinable objects in this room and puts them into a dictionary (object, description)
            examineDictionary.Add(currentRoom.examinableObjectsInRoom[i].noun, currentRoom.examinableObjectsInRoom[i].description);
            // finds all descriptions for examinable objects and puts them into a list in GameController
            controller.examinableDescriptionsInRoom.Add(currentRoom.examinableObjectsInRoom[i].noun);
        }
    }

    public void AttemptToChangeRooms(string[] directionNoun)
    {
        // if there is an exit in the direction the player typed
        if (directionNoun.Length > 1)
        {
            if (exitDictionary.ContainsKey(directionNoun[1]))
            {
                if (controller.mustFleeToMove)
                {
                    if (AttemptToFleeRoom(directionNoun[1]))
                    {
                        ChangeRooms(directionNoun[1]);
                    }
                    else
                    {
                        // mobs attack first then player flees to choosen room
                        ChangeRooms(directionNoun[1]);
                    }
                }
                else
                {
                    ChangeRooms(directionNoun[1]);
                }
            }
            else
            {
                controller.LogStringWithReturn("There is no exit labelled " + directionNoun);
            }
        }
        else
        {
            controller.LogStringWithReturn("You must include a direction to go in your command.");
        }
    }

    private void ChangeRooms(string directionNoun)
    {
        RemoveInstantiatedMobs();

        playerManagement.isPlayerInCombat = false;
        currentRoom = exitDictionary[directionNoun];
        controller.LogStringWithReturn("You head to the " + directionNoun);
        player.CurrentRoom = currentRoom;
        player.PlayerCurrentRoom = currentRoom.roomCode;
        controller.SpawnMobPrefabs();
        controller.DisplayRoomText();
    }

    public void RemoveInstantiatedMobs()
    {
        GameObject[] enemyMobObjects = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var mob in enemyMobObjects)
        {
            Destroy(mob);
        }
    }

    private bool AttemptToFleeRoom(string directionNoun)
    {
        // Fleeing a room has a base 35% chance. Each point of Endurance increases the chance
        // by .5% (Ex: a player with 20 Endurance has a 45% chance to flee a room with mobs.
        // If a player fails their flee check, the mobs get a free attack before he moves to
        // the next room.

        controller.LogStringWithReturn("Attempting to flee  " + directionNoun);
        var playerFleeChance = (character.Endurance.Value / 2) + 35;
        var fleeRandomRoll = Random.Range(1, 100);
        if (fleeRandomRoll <= playerFleeChance)
        {
            controller.LogStringWithReturn("You managed to flee from your enemies without harm.");
            return true;
        }
        else
        {
            controller.LogStringWithReturn("You managed to flee, but not before your enemies attack!");
            return false;
        }
    }

    // clear all dictionaries to prepare for next room population
    public void ClearExits()
    {
        exitDictionary.Clear();
    }

    public void ClearExaminables()
    {
        examineDictionary.Clear();
    }

    public void ClearMobs()
    {
        mobsDictionary.Clear();
    }
}
