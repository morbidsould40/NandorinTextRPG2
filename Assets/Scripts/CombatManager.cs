using UnityEngine;

public class CombatManager : MonoBehaviour {

    public Player player;
    public GameController controller;
    [SerializeField] float critDamageMultiplier = 1.5f;
    public bool playerInCombat = false;

    Character character;
    EquipmentPanel equipmentPanel;
    EquipmentSlot[] equipmentSlots;
    Weapons weaponUsed;
    PlayerManagement playerManagement;
    RoomNavigation roomNav;
    int weaponDamage;

    public enum CombatState
    {
        StartCombat, PlayersTurn, MonstersTurn, PlayerDead, EndCombat, OutOfCombat
    }

    public CombatState combatState = CombatState.OutOfCombat;

    void Start ()
    {
        player = FindObjectOfType<Player>();
        controller = GetComponent<GameController>();
        character = FindObjectOfType<Character>();
        equipmentPanel = FindObjectOfType<EquipmentPanel>();
        equipmentSlots = equipmentPanel.equipmentSlotsParent.GetComponentsInChildren<EquipmentSlot>();
        playerManagement = FindObjectOfType<PlayerManagement>();
        roomNav = GetComponent<RoomNavigation>();
    }
	
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
                // TODO turn off auto heal once that function is implemented
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
                Debug.Log("Monsters turn to attack");
                MonstersAttack();
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

    // checks to see what the player typed in to attack and grabs the first mob in the room that matches
    public Monsters GetMonsterPlayerAttacked(string mobAttacked)
    {
        GameObject[] enemyMobObjects = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < enemyMobObjects.Length; i++)
        {
            var enemyMob = enemyMobObjects[i].GetComponent<Monsters>();

            if (enemyMob.monsterKeyword == mobAttacked)
            {
                return enemyMob;
            }
        }

        return null;
    }

    ////////
    // Attack formula for both players and monsters is atk / (atk + def) where both atk's are attackers attack and def is defenders defense
    // This should scale pretty decent and will almost never result in a 100% chance to hit
    //
    // TODO: Add in if statement if attack was with a skill or magic based. All will need to be calculated differently
    ///////

    public void PlayerAttack(string mobAttacked)
    {
        combatState = CombatState.PlayersTurn;
        Monsters mob = GetMonsterPlayerAttacked(mobAttacked);
        weaponUsed = WeaponUsed();
        var toHit = character.Attack.Value / (character.Attack.Value + mob.monsterDefense);

        // random roll to see if hit is made
        var rollToHit = Random.Range(0f, 1f);

        if(rollToHit < toHit)
        {
            // hit successful
            bool playerCrit = CalculatePlayerCrit();
            float totalDamageDone = CalculatePlayerDamage(playerCrit);

            if (WeaponUsed())
            {
                if (playerCrit)
                {
                    controller.LogStringWithoutReturn("<color=#ff0000ff>You <b>CRITICALLY HIT</b> " + mobAttacked +
                        " with your " + weaponUsed.itemName + " for " + totalDamageDone + " damage.</color>");
                    DamageMob(mob, totalDamageDone);
                    CheckMobDamageStatus(mob);
                }
                else
                {
                    controller.LogStringWithoutReturn("<color=#ff0000ff>You hit " + mobAttacked + " with your " +
                        weaponUsed.itemName + " for " + totalDamageDone + " damage.</color>");
                    DamageMob(mob, totalDamageDone);
                    CheckMobDamageStatus(mob);
                }
            }
            else
            {
                if (playerCrit)
                {
                    controller.LogStringWithoutReturn("<color=#ff0000ff>You CRITICALLY punch " + mobAttacked + " for " +
                        totalDamageDone + " damage.</color>");
                    DamageMob(mob, totalDamageDone);
                    CheckMobDamageStatus(mob);
                }
                else
                {
                    controller.LogStringWithoutReturn("<color=#ff0000ff>You punch " + mobAttacked + " for " + totalDamageDone +
                        " damage.</color>");
                    DamageMob(mob, totalDamageDone);
                    CheckMobDamageStatus(mob);
                }
            }
        }
        else
        {
            // missed
            controller.LogStringWithoutReturn("You missed the " + mobAttacked + ".");
        }
        combatState = CombatState.MonstersTurn;
        CombatStateMachine("");
    }

    private void CheckMobDamageStatus(Monsters mob)
    {
        var mobCurrentHeath = mob.monsterCurrentHealth;        
        var mobMaxHealth = mob.monsterMaxHealth;

        if (mobCurrentHeath < mobMaxHealth && mobCurrentHeath >= mobMaxHealth * .75f)
        {
            // mob is slightly wounded
            controller.LogStringWithoutReturn(mob.monsterName + " is <color=#00ff00ff>slightly</color> wounded.");
        }
        else if (mobCurrentHeath < mobMaxHealth * .75f && mobCurrentHeath >= mobMaxHealth * .5f)
        {
            // mob is moderately wounded
            controller.LogStringWithoutReturn(mob.monsterName + " is <color=#ffff00ff>moderately</color> wounded.");
        }
        else if (mobCurrentHeath < mobMaxHealth * .5f && mobCurrentHeath >= mobMaxHealth * .25f)
        {
            // mob is seriously wounded
            controller.LogStringWithoutReturn(mob.monsterName + " is <color=#ffa500ff>seriously</color> wounded.");
        }
        else if (mobCurrentHeath < mobMaxHealth * .25f && mobCurrentHeath >= 1f)
        {
            // mob is severly wounded
            controller.LogStringWithoutReturn(mob.monsterName + " is <color=#ff0000ff>severly</color> wounded.");
        }
        else
        {
            // mob is dead
            controller.LogStringWithoutReturn(mob.monsterName + " has been killed.");

            GetExperience(mob);
            GetLootDrops(mob);            
            RemoveMobFromRoom(mob);            
        }
    }

    private void RemoveMobFromRoom(Monsters mob)
    {
        for (int i = 0; i <= controller.mobsInTheRoom.Count; i++)
        {
            if (mob.monsterCurrentHealth <= 0)
            {
                controller.mobsInTheRoom.Remove(mob);                              
                    
                Destroy(mob.transform.gameObject);                
            }
        }

        for (int x = 0; x <= controller.mobsSpawnedInRoom.Count; x++)
        {
            var key = controller.mobsSpawnedInRoom[x].Key.ToString();
            var value = controller.mobsSpawnedInRoom[x].Value.ToString();

            if (roomNav.currentRoom.roomCode == key && mob.ToString() == value)
            {
                controller.mobsSpawnedInRoom.RemoveAt(x);
                break;
            }
        }        
    }

    private void GetExperience(Monsters mob)
    {
        playerManagement.UpdatePlayerExperience(mob.monsterExperience);
    }

    private void DamageMob(Monsters mobAttacked, float totalDamageDone)
    {
        mobAttacked.monsterCurrentHealth -= totalDamageDone;
        
        Debug.Log(mobAttacked.monsterCurrentHealth);
    }

    private Weapons WeaponUsed()
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].equipmentType == EquipmentType.Weapon1)
            {
                var weapon = (Weapons)equipmentSlots[i].Item;
                return weapon;
            }            
        }
        return null;        
    }

    public float CalculatePlayerDamage(bool playerCrit)
    {
        // calculate player bonus damage ((str / 5) * level)
        float playerDamageBonus = ((player.PlayerStrength / 5) * player.PlayerLevel);
        Debug.Log("Player Damage Bonus: " + playerDamageBonus);
        
        weaponUsed = WeaponUsed();        

        // Get the weapon the player is using to calculate weapon damage
        if (WeaponUsed())
        {
            Debug.Log(weaponUsed.itemName);
            int minWeaponDamage = (int)weaponUsed.weaponMinDamage;
            int maxWeaponDamage = (int)weaponUsed.weaponMaxDamage;
            Debug.Log("MinDamage: " + minWeaponDamage + " | MaxDamage: " + maxWeaponDamage);
            weaponDamage = Random.Range(minWeaponDamage, maxWeaponDamage);
            Debug.Log("Random damage from weapon: " + weaponDamage);
        }
        else
        {
            weaponDamage = 0;
        }
        
        if (playerCrit)
        {
            // Calculate damage and multiply it by critDamageModifier
            var damageDealt = ((weaponDamage + playerDamageBonus) * critDamageMultiplier); // TODO set up damage formula
            controller.LogStringWithoutReturn("CRITICAL STRIKE!");
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
        foreach (var mob in controller.mobsInTheRoom)
        {
            var toHit = mob.monsterAttack / (mob.monsterAttack + character.Defense.Value);

            var rollToHit = Random.Range(0f, 1f);

            if (rollToHit < toHit)
            {
                // hit successful
                bool monsterCrit = CalculateMonstersCrit();
                float totalDamageDone = CalculateMonstersDamage();

                if (monsterCrit)
                {
                    controller.LogStringWithoutReturn("<color=#ff0000ff>The " + mob.monsterName +
                        "<b>CRITICALLY HITS</b> you for " + totalDamageDone + " damage.</color>");
                    DamagePlayer(totalDamageDone);
                }
                else
                {
                    controller.LogStringWithoutReturn("<color=#ff0000ff>The " + mob.monsterName +
                        " hits you for " + totalDamageDone + " damage.</color>");
                    DamagePlayer(totalDamageDone);
                }
            }
            else
            {
                controller.LogStringWithoutReturn("The " + mob.monsterName +
                        " misses you.");
            }
        }        
    }

    private void DamagePlayer(float totalDamageDone)
    {

    }

    public float CalculateMonstersDamage()
    {
        return 0;
    }

    public bool CalculateMonstersCrit()
    {
        // For now, all enemies have a 5% chance to crit. May redo this feature at some point

        var monsterCritChance = 5f;
        var critRoll = Random.Range(1, 100);

        if (critRoll <= monsterCritChance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void GetLootDrops(Monsters mob)
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
