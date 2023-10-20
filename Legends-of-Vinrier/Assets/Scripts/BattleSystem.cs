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
    public GameObject itemsPanel;
    public GameObject healPotionButton;
    public GameObject manaPotionButton;
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
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.playerHealth = playerUnit.GetCurrentHP();
            }

            // win screen

            // return to overworld
            SceneManager.LoadScene("Map 1");
        }
        else if (state == BattleState.LOSE)
        {
            // lose screen
            SceneManager.LoadScene("BattleEnd");
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

    public void OnItemsButton()
    {
        if (state != BattleState.PLAYER)
        return;

        itemsPanel.SetActive(!itemsPanel.activeSelf);
    }
       public void OnHealButton()
    {
        if (state != BattleState.PLAYER)
        return;

        if (playerUnit.GetMaxHP() - 10 > playerUnit.GetCurrentHP())
        {
            playerUnit.SetCurrentHP(playerUnit.GetCurrentHP() + 10);
            playerHUD.setHP(playerUnit.GetCurrentHP());
        }
        else
        {
            playerUnit.SetCurrentHP(playerUnit.GetMaxHP());
            playerHUD.setHP(playerUnit.GetMaxHP());
        }
        dialogueText.text = playerUnit.GetUnitName() + " Restores some health";
        Destroy(healPotionButton);
        itemsPanel.SetActive(false);
        StartCoroutine(EnemyTurn());
    }

        public void OnManaButton()
    {
        if (state != BattleState.PLAYER)
        return;

        dialogueText.text = playerUnit.GetUnitName() + " Restores some Mana";
        Destroy(manaPotionButton);
         itemsPanel.SetActive(false);
        StartCoroutine(EnemyTurn());
    }
}
