using UnityEngine;

public class CombatManager : MonoBehaviour {

    public Player player;
    public GameController controller;
    public float critDamageMultiplier = 1.5f;
    public Room currentRespawnRoom;

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
                Debug.Log(combatState);                
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
                OnPlayerDeath();
                break;
            case CombatState.EndCombat:
                break;
            case CombatState.OutOfCombat:
                break;
            default:
                break;
        }
    }

    private void OnPlayerDeath()
    {
        controller.LogStringWithReturn("\n <color=#ff0000ff>YOU HAVE DIED! You will lose 10% of your experience and " +
                            "respawn in the nearest temple.</color>");
        controller.DisplayLoggedText();
        roomNav.currentRoom = currentRespawnRoom;
        roomNav.RemoveInstantiatedMobs();
        playerManagement.currentHealth = playerManagement.maxHealth;
        var experienceLoss = player.PlayerCurrentExperience * .9;
        playerManagement.UpdatePlayerExperience((int)experienceLoss);
        playerManagement.playerExp.text = experienceLoss.ToString();
        controller.DisplayRoomText();
        controller.DisplayLoggedText();
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

    ///////
    // Attack formula for both players and monsters is atk / (atk + def) where both atk's are attackers attack and def is defenders defense
    // This should scale pretty decent and will almost never result in a 100% chance to hit
    //
    // TODO: Add in if statement if attack was with a skill or magic based. All will need to be calculated differently
    ///////

    public void PlayerAttack(string mobAttacked)
    {        
        Monsters mob = GetMonsterPlayerAttacked(mobAttacked);
        if (mob != null)
        {
            weaponUsed = WeaponUsed();
            var toHit = character.Attack.Value / (character.Attack.Value + mob.monsterDefense);

            // random roll to see if hit is made
            var rollToHit = Random.Range(0f, 1f);

            if (rollToHit < toHit)
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
                    }
                    else
                    {
                        controller.LogStringWithoutReturn("<color=#ff0000ff>You hit " + mobAttacked + " with your " +
                            weaponUsed.itemName + " for " + totalDamageDone + " damage.</color>");
                        DamageMob(mob, totalDamageDone);
                    }
                }
                else
                {
                    if (playerCrit)
                    {
                        controller.LogStringWithoutReturn("<color=#ff0000ff>You CRITICALLY punch " + mobAttacked + " for " +
                            totalDamageDone + " damage.</color>");
                        DamageMob(mob, totalDamageDone);
                    }
                    else
                    {
                        controller.LogStringWithoutReturn("<color=#ff0000ff>You punch " + mobAttacked + " for " + totalDamageDone +
                            " damage.</color>");
                        DamageMob(mob, totalDamageDone);
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
        else
        {
            controller.LogStringWithoutReturn("There isn't a <b>" + mobAttacked + "</b> here to attack.");
        }
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
        }
    }

    private Weapons WeaponUsed()
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].equipmentType == EquipmentType.Weapon)
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
        float playerDamageBonus = character.DamageBonus.Value;
        Debug.Log("Player damage bonus before weapon: " + playerDamageBonus);
        
        weaponUsed = WeaponUsed();        

        // Get the weapon the player is using to calculate weapon damage
        if (WeaponUsed())
        {
            Debug.Log("Weapon player is using to attack: " + weaponUsed.itemName);
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
            var damageDealt = ((weaponDamage + playerDamageBonus) * critDamageMultiplier); 
            controller.LogStringWithoutReturn("CRITICAL STRIKE!");
            return (int)damageDealt;
        }
        else
        {
            // Calculate Damage normally
            var damageDealt = weaponDamage + playerDamageBonus;             
            return (int)damageDealt;
        }
    }

    public bool CalculatePlayerCrit()
    {
        var playerCritChance = character.CritChance.Value;
        var critRoll = Random.Range(1, 100);
        Debug.Log("Crit Chane: " + playerCritChance + " | Random crit roll: " + critRoll);

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

    private void DamageMob(Monsters mobAttacked, float totalDamageDone)
    {
        mobAttacked.monsterCurrentHealth -= totalDamageDone;

        CheckMobDamageStatus(mobAttacked);

        if (mobAttacked.monsterCurrentHealth <= 0)
        {
            Debug.Log("this script is firing");
            GetExperience(mobAttacked);
            GetLootDrops(mobAttacked);
            RemoveMobFromRoom(mobAttacked);
            controller.LogStringWithReturn("");
            controller.DisplayRoomText();
            controller.DisplayLoggedText();
        }
    }

    public void MonstersAttack()
    {
        foreach (var mob in controller.mobsInTheRoom)
        {
            var toHit = mob.monsterAttack / (mob.monsterAttack + character.Defense.Value);

            var rollToHit = Random.Range(0f, 1f);
            Debug.Log("Monster Hit Chance: " + toHit + " | Random Hit Roll: " + rollToHit);
            if (rollToHit < toHit)
            {
                // hit successful
                bool monsterCrit = CalculateMonstersCrit(mob);
                float totalDamageDone = CalculateMonstersDamage(mob, monsterCrit);

                if (monsterCrit)
                {
                    controller.LogStringWithoutReturn("<color=#ff0000ff>The " + mob.monsterName +
                        "<b> CRITICALLY HITS</b> you for " + totalDamageDone + " damage.</color>");
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
        playerManagement.currentHealth -= totalDamageDone;
    }

    public float CalculateMonstersDamage(Monsters mob, bool monsterCrit)
    {
        var chooseRandomAttack = Random.Range(0, mob.monsterAttacks.Length);
        int monsterMinDamage = (int)mob.monsterAttacks[chooseRandomAttack].monsterMinDamage;
        int monsterMaxDamage = (int)mob.monsterAttacks[chooseRandomAttack].monsterMaxDamage;
        var monsterDamageDone = Random.Range(monsterMinDamage, monsterMaxDamage);

        if (monsterCrit)
        {
            // Calculate damage and multiply it by critDamageModifier
            var damageDealt = (monsterDamageDone * critDamageMultiplier);            
            return (int)damageDealt;
        }
        else
        {
            // Calculate Damage normally
            var damageDealt = monsterDamageDone;            
            return (int)damageDealt;
        }
    }

    public bool CalculateMonstersCrit(Monsters mob)
    {       
        var chooseRandomAttack = Random.Range(0, mob.monsterAttacks.Length);
        var monsterCritChance = mob.monsterAttacks[chooseRandomAttack].monsterCritChance;
        var critRoll = Random.Range(1, 100);

        if (critRoll <= monsterCritChance)
        {
            Debug.Log("Monster Crit = True");
            return true;
        }
        else
        {
            Debug.Log("Monster Crit = False");
            return false;
        }
    }

    public void GetLootDrops(Monsters mob)
    {

    }

    private void RemoveMobFromRoom(Monsters mob)
    {
        Debug.Log("RemoveMobFromRoom: Mob Name: " + mob.monsterName + " Mob health: " + mob.monsterCurrentHealth);
        controller.mobsInTheRoom.Remove(mob);
        
        //for (int i = 0; i <= controller.mobsInTheRoom.Count; i++)
        //{
        //    if (mob.monsterCurrentHealth <= 0) // TODO fix this as it is referencing the base creature not the
        //                                       // instantiated creature and therefore not removing from the list
        //    {
        //        controller.mobsInTheRoom.Remove(mob);


        //    }
        //}

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

        var mobCount = controller.mobsSpawnedInRoom.Count;
        if (mobCount <= 0)
        {
            roomNav.currentRoom.mobsAlreadySpawned = false;
        }

        Destroy(mob.transform.gameObject);

        DebugLists(mob);
    }

    private void DebugLists(Monsters mobs)
    {
        foreach (var mob in controller.mobsInTheRoom)
        {
            Debug.Log("name: " + mobs.monsterName + " health: " + mobs.monsterCurrentHealth);
        }
        foreach (var mob in controller.mobsSpawnedInRoom)
        {
            Debug.Log("room: " + mob.Key.ToString() + " mob: " + mob.Value.ToString());
        }
    }

    private void GetExperience(Monsters mob)
    {
        playerManagement.UpdatePlayerExperience(mob.monsterExperience);
    }

    public void IsPlayerDead()
    {
        if (playerManagement.currentHealth <= 0)
        {
            combatState = CombatState.PlayerDead;
            CombatStateMachine("");
        }

    }
}
