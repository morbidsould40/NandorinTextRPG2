using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour {

    public Player player;
    public GameController controller;


    public enum CombatState
    {
        OutOfCombat, PlayersTurn, MonstersTurn, PlayerDead
    }

    CombatState combatState = CombatState.OutOfCombat;

    // Use this for initialization
    void Start ()
    {
        player = FindObjectOfType<Player>();
        controller = GetComponent<GameController>();        
	}
	
	// Update is called once per frame
	void Update ()
    {
        IsPlayerDead();
    }

    private Monsters GetMonsterPlayerAttacked(string mobAttacked)
    {
        for (int i = 0; i < controller.mobsInTheRoom.Count; i++)
        {
            if (mobAttacked == controller.mobsInTheRoom[i].monsterKeyword)
            {
                return controller.mobsInTheRoom[i];
            }
            else
            {
                return null;
            }
        }
        return null;
    }

    private void PlayerAttack()
    {
        combatState = CombatState.PlayersTurn;
    }

    private void CalculatePlayerDamage()
    {

    }

    private void CalculatePlayerCrit()
    {

    }

    private void MonstersAttack()
    {
        combatState = CombatState.MonstersTurn;
    }

    private void CalculateMonstersDamage()
    {

    }

    private void CalculateMonstersCrit()
    {

    }

    private void GetLootDrops()
    {

    }

    private bool IsPlayerDead()
    {
        if (player.PlayerCurrentHealth <= 0)
        {
            combatState = CombatState.PlayerDead;
            return true;
        }
        else
        {
            return false;
        }
    }
}
