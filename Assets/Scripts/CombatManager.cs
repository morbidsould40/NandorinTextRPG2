using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour {

    public Player player;
    public GameController controller;
    public float critDamageMultiplier = 1.5f;
    public bool playerInCombat = false;

    public enum CombatState
    {
        StartCombat, PlayersTurn, MonstersTurn, PlayerDead, EndCombat, OutOfCombat
    }

    public CombatState combatState = CombatState.OutOfCombat;

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

    // Combat State Machine    
    public void CombatStateMachine(string mobToAttack)
    {
        switch (combatState)
        {
            case CombatState.StartCombat:
                // turn off auto heal
                Debug.Log(combatState);                
                playerInCombat = true;
                combatState = CombatState.PlayersTurn;
                CombatStateMachine(mobToAttack);
                break;
            case CombatState.PlayersTurn:
                Debug.Log(combatState);
                PlayerAttack(mobToAttack);
                break;
            case CombatState.MonstersTurn:
                break;
            case CombatState.PlayerDead:
                break;
            case CombatState.EndCombat:
                break;
            case CombatState.OutOfCombat:
                break;
            default:
                break;
        }
    }

    public Monsters GetMonsterPlayerAttacked(string mobAttacked)
    {

        for (int i = 0; i < controller.mobsInTheRoom.Count; i++)
        {
            if (mobAttacked == controller.mobsInTheRoom[i].monsterName.ToLower())
            {
                return controller.mobsInTheRoom[i];                
            }
        }
        return null;
    }

    ////////
    // Attack formula for both players and monsters is atk / (atk + def) where both atk's are attackers attack and def is defenders defense
    // This should scale pretty decent and will almost never result in a 100% chance to hit
    ///////

    public void PlayerAttack(string mobAttacked)
    {
        combatState = CombatState.PlayersTurn;        
        var toHit = player.PlayerAttack / (player.PlayerAttack + GetMonsterPlayerAttacked(mobAttacked).monsterDefense);
        Debug.Log("percentage to hit: " + toHit);
        // random roll to see if hit is made
        var rollToHit = Random.Range(0, 100);
        Debug.Log("Random roll: " + rollToHit);
        if(rollToHit < toHit)
        {
            // hit successful
            bool playerCrit = CalculatePlayerCrit();
            float totalDamageDone = CalculatePlayerDamage(playerCrit);
            Debug.Log("Total damage dealt: " + totalDamageDone);
        }
        else
        {
            // missed
            Debug.Log("missed");

        }
    }

    public float CalculatePlayerDamage(bool playerCrit)
    {
        var playerDamageBonus = ((player.PlayerStrength / 5) * player.PlayerLevel);
        var weaponDamage = 0;
        if (playerCrit)
        {
            // Calculate damage and multiply it by critDamageModifier
            var damageDealt = ((weaponDamage + playerDamageBonus) * critDamageMultiplier); // TODO set up damage formula            
            return damageDealt;
        }
        else
        {
            // Calculate Damage normally
            var damageDealt = weaponDamage + playerDamageBonus; // TODO set up damage formula            
            return damageDealt;
        }
    }

    public bool CalculatePlayerCrit()
    {
        // ((agility / 25) * currentLevel)
        var playerCritChance = ((player.PlayerAgility / 10) * player.PlayerLevel);
        Debug.Log("Crit Chane: " + playerCritChance);
        var critRoll = Random.Range(1, 100);
        Debug.Log("Random crit roll: " + critRoll);
        if (critRoll <= playerCritChance)
        {
            Debug.Log("crit: true");
            return true;
        }
        else
        {
            Debug.Log("crit: false");
            return false;
        }
    }

    public void MonstersAttack()
    {
        combatState = CombatState.MonstersTurn;
        
    }

    public void CalculateMonstersDamage()
    {

    }

    public void CalculateMonstersCrit()
    {

    }

    public void GetLootDrops()
    {

    }

    public bool IsPlayerDead()
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
