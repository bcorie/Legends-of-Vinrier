using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum BattleState {START, PLAYER, ENEMY, WIN, LOSE}
public class BattleSystem : MonoBehaviour
{
    public GameObject attackButton;
    public GameObject magicButton;
    public GameObject itemsButton;
    public GameObject playerFab;
    public GameObject enemyFab;
    public Transform playerSpawn;
    public Transform enemySpawn;
    Player playerUnit;
    Enemy enemyUnit;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;
    public BattleState state;

    public Text dialogueText;
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        attackButton.SetActive(false);
        magicButton.SetActive(false);
        itemsButton.SetActive(false);
        StartCoroutine(SetUpBattle());
    }

    /// <summary>
    /// Populates the player and enemy into the battle.
    /// Sets HUDs for player and enemy.
    /// </summary>
    /// <returns>Cycle to player's turn.</returns>
    IEnumerator SetUpBattle()
    {
        GameObject playerStart = Instantiate(playerFab, new Vector3((float)-6.06, (float)-1.38), new Quaternion());
        playerUnit = new Player("Player", 1, 5, 35);
        GameObject enemyStart = Instantiate(enemyFab, new Vector3((float)6.06, (float)-1.38), new Quaternion());

        // Generates a random enemy
        int randomEnemy = Random.Range(0, 2);
        if (randomEnemy == 0)
        {
            enemyUnit = new EnemyMelee(1);
        }
        else
        {
            enemyUnit = new EnemyMage(1);
        }

        dialogueText.text = enemyUnit.GetUnitName() + " wants to fight!";
        playerHUD.setHUD(playerUnit);
        enemyHUD.setHUD(enemyUnit);
        yield return new WaitForSeconds(1f);
        dialogueText.text =  "";
        state = BattleState.PLAYER;
        PlayerTurn();
    }

    /// <summary>
    /// The player attacks the enemy.
    /// </summary>
    /// <returns>End battle if enemy is dead. Cycle to enemy's turn if not.</returns>
    IEnumerator PlayerAttack()
    {
        attackButton.SetActive(false);
        magicButton.SetActive(false);
        itemsButton.SetActive(false);
        dialogueText.text = playerUnit.GetUnitName() + " uses an attack!";
        bool isDead = enemyUnit.TakeDamage(playerUnit.GetDamage());
        enemyHUD.setHP(enemyUnit.GetCurrentHP());
        yield return new WaitForSeconds(1f);
        dialogueText.text =  "";
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

      IEnumerator PlayerMagic()
    {
        attackButton.SetActive(false);
        magicButton.SetActive(false);
        itemsButton.SetActive(false);
        dialogueText.text = playerUnit.GetUnitName() + " uses magic!";
        bool isDead = enemyUnit.TakeDamage(playerUnit.GetDamage());
        enemyHUD.setHP(enemyUnit.GetCurrentHP());
        yield return new WaitForSeconds(1f);
        dialogueText.text =  "";
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
        attackButton.SetActive(false);
        magicButton.SetActive(false);
        itemsButton.SetActive(false);
        yield return new WaitForSeconds(1f);
        dialogueText.text = enemyUnit.GetUnitName() + " uses " + enemyUnit.GetAttackName() + " attack!";
        bool isDead = playerUnit.TakeDamage(enemyUnit.GetDamage());
        playerHUD.setHP(playerUnit.GetCurrentHP());
        yield return new WaitForSeconds(1f);
        dialogueText.text = "";
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
            SceneManager.LoadScene("Test Area");
        }
        else if (state == BattleState.LOSE)
        {
            // lose screen

        }
    }
    void PlayerTurn()
    {
        dialogueText.text =  "Choose an action!";
        attackButton.SetActive(true);
        magicButton.SetActive(true);
        itemsButton.SetActive(true);
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYER)
        return;

        StartCoroutine(PlayerAttack());
    }

        public void OnMagicButton()
    {
        if (state != BattleState.PLAYER)
        return;

        StartCoroutine(PlayerMagic());
    }
}
