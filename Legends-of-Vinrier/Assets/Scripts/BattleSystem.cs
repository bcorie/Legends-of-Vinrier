using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum BattleState {START, PLAYER, ENEMY, WIN, LOSE}
public class BattleSystem : MonoBehaviour
{
    public GameObject playerFab;
    public GameObject enemyFab;
    public Transform playerSpawn;
    public Transform enemySpawn;
    Unit playerUnit;
    Unit enemyUnit;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;
    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetUpBattle());
    }

    /// <summary>
    /// Populates the player and enemy into the battle.
    /// Sets HUDs for player and enemy.
    /// </summary>
    /// <returns>Cycle to player's turn.</returns>
    IEnumerator SetUpBattle()
    {
        GameObject playerStart = Instantiate(playerFab, playerSpawn);
        playerUnit = playerStart.GetComponent<Unit>();
        GameObject enemyStart = Instantiate(enemyFab, enemySpawn);
        enemyUnit = enemyStart.GetComponent<Unit>();

        playerHUD.setHUD(playerUnit);
        enemyHUD.setHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYER;
        PlayerTurn();
    }

    /// <summary>
    /// The player attacks the enemy.
    /// </summary>
    /// <returns>End battle if enemy is dead. Cycle to enemy's turn if not.</returns>
    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        enemyHUD.setHP(enemyUnit.currentHP);
        yield return new WaitForSeconds(2f);
        if(isDead)
        {
            state = BattleState.WIN;
            EndBattle();
        }
        else
        {
           state = BattleState.ENEMY;
           StartCoroutine(EnemyTurn());
        }

    }

    /// <summary>
    /// Enemy turn cycle.
    /// </summary>
    /// <returns>Ends the battle if player is defeated. Cycles to player's turn if not.</returns>
    IEnumerator EnemyTurn()
    {
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
        playerHUD.setHP(playerUnit.currentHP);
        yield return new WaitForSeconds(2f);
        if(isDead)
        {
            state = BattleState.LOSE;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYER;
            PlayerTurn();
        }
    }
    void EndBattle()
    {
        if(state == BattleState.WIN)
        {
            // win screen

            // return to overworld
        }
        else if (state == BattleState.LOSE)
        {
            // lose screen

        }
    }
    void PlayerTurn()
    {
        // attack

        // magic

        // items
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYER)
        return;

        StartCoroutine(PlayerAttack());
    }
}
