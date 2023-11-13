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
    public GameObject bossFab;
    [SerializeField] private GameObject soulPrefab; // The soul prefab to instantiate
    [SerializeField] private GameObject soulContainer; // The parent container for the souls in the UI
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
        playerUnit = new Player("Player", 1, 5, 40, 3, 1);
        playerUnit.playerGameObject = playerStart;
        // Generates a random enemy or starts the boss fight
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            if (gameManager.boss1)
            {
                GameObject enemyStart = Instantiate(bossFab, new Vector3((float)6.06, (float)-1.38), new Quaternion());
                EnemyElgrim enemyElgrim = enemyStart.AddComponent<EnemyElgrim>();
                enemyUnit = new EnemyElgrim(5);
                enemyUnit.enemyGameObject = enemyStart;
                UpdateSoulUI(enemyElgrim.GetSouls());
            }
            else
            {
                int randomEnemy = Random.Range(0, 2);
                if (randomEnemy == 0)
                {
                    GameObject enemyStart = Instantiate(enemyFab, new Vector3((float)6.06, (float)-1.38), new Quaternion());
                    enemyUnit = new EnemyMelee(1);
                    enemyUnit.enemyGameObject = enemyStart;
                }
                else
                {
                    GameObject enemyStart = Instantiate(enemyFab, new Vector3((float)6.06, (float)-1.38), new Quaternion());
                    enemyUnit = new EnemyMage(1);
                    enemyUnit.enemyGameObject = enemyStart;
                }
            }
        }
        else
        {
            int randomEnemy = Random.Range(0, 2);
            if (randomEnemy == 0)
            {
                GameObject enemyStart = Instantiate(enemyFab, new Vector3((float)6.06, (float)-1.38), new Quaternion());
                enemyUnit = new EnemyMelee(1);
                enemyUnit.enemyGameObject = enemyStart;
            }
            else
            {
                GameObject enemyStart = Instantiate(enemyFab, new Vector3((float)6.06, (float)-1.38), new Quaternion());
                enemyUnit = new EnemyMage(1);
                enemyUnit.enemyGameObject = enemyStart;
            }
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
        // Get the player's starting position
        Vector3 startPos = playerUnit.playerGameObject.transform.position;

        // Calculate the end position (this example moves the player 2 units forward)
        Vector3 endPos = new Vector3(startPos.x + 2, startPos.y, startPos.z);

        // Set the duration of the movement (in seconds)
        float duration = 0.5f;

        // Use a for loop to move the player over time
    for (float t = 0; t < duration; t += Time.deltaTime)
    {
        // Calculate the current position based on the elapsed time
        playerUnit.playerGameObject.transform.position = Vector3.Lerp(startPos, endPos, t / duration);
        yield return null; // Wait for the next frame
    }

        // Ensure the player has moved to the exact end position
        playerUnit.playerGameObject.transform.position = endPos;

        playerUnit.PhysicalAttack(enemyUnit);
        enemyHUD.setHP(enemyUnit.GetCurrentHP());
        enemyHUD.setHUD(enemyUnit);
        bool isDead = enemyUnit.GetCurrentHP() <= 0;
        yield return new WaitForSeconds(1f);
        // Move the player back to the starting position
    for (float t = 0; t < duration; t += Time.deltaTime)
    {
        playerUnit.playerGameObject.transform.position = Vector3.Lerp(endPos, startPos, t / duration);
        yield return null; // Wait for the next frame
    }

        // Ensure player is exactly at the starting position
        playerUnit.playerGameObject.transform.position = startPos;
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
        dialogueText.text = playerUnit.GetUnitName() + " shoots a beam of ice at the " + enemyUnit.GetUnitName() + "!";
        // Get the player's starting position
        Vector3 startPos = playerUnit.playerGameObject.transform.position;

        // Calculate the end position (this example moves the player 2 units forward)
        Vector3 endPos = new Vector3(startPos.x + 2, startPos.y, startPos.z);

        // Set the duration of the movement (in seconds)
        float duration = 0.5f;

        // Use a for loop to move the player over time
    for (float t = 0; t < duration; t += Time.deltaTime)
    {
        // Calculate the current position based on the elapsed time
        playerUnit.playerGameObject.transform.position = Vector3.Lerp(startPos, endPos, t / duration);
        yield return null; // Wait for the next frame
    }

        // Ensure the player has moved to the exact end position
        playerUnit.playerGameObject.transform.position = endPos;
        playerUnit.MagicalAttack(enemyUnit);
        enemyHUD.setHP(enemyUnit.GetCurrentHP());
        enemyHUD.setHUD(enemyUnit);
        bool isDead = enemyUnit.GetCurrentHP() <= 0;

        yield return new WaitForSeconds(1f);
           // Move the player back to the starting position
    for (float t = 0; t < duration; t += Time.deltaTime)
    {
        playerUnit.playerGameObject.transform.position = Vector3.Lerp(endPos, startPos, t / duration);
        yield return null; // Wait for the next frame
    }

        // Ensure player is exactly at the starting position
        playerUnit.playerGameObject.transform.position = startPos;
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
         // Get the enemy's starting position
    Vector3 startPos = enemyUnit.enemyGameObject.transform.position;

    // Define the end position (this might be the player's position)
     Vector3 endPos = new Vector3(startPos.x - 2, startPos.y, startPos.z);

    // Duration of the movement
    float duration = 1f;

    // Move the enemy to the end position
    for (float t = 0; t < duration; t += Time.deltaTime)
    {
        enemyUnit.enemyGameObject.transform.position = Vector3.Lerp(startPos, endPos, t / duration);
        yield return null; // Wait for the next frame
    }

    // Ensure enemy is exactly at the end position
    enemyUnit.enemyGameObject.transform.position = endPos;
        enemyUnit.Attack(playerUnit);
        playerHUD.setHP(playerUnit.GetCurrentHP());
        playerHUD.setHUD(playerUnit);
        bool isDead = playerUnit.GetCurrentHP() <= 0;

        yield return new WaitForSeconds(1f);
        // Move the enemy back to the starting position
    for (float t = 0; t < duration; t += Time.deltaTime)
    {
        enemyUnit.enemyGameObject.transform.position = Vector3.Lerp(endPos, startPos, t / duration);
        yield return null; // Wait for the next frame
    }

    // Ensure enemy is exactly at the starting position
    enemyUnit.enemyGameObject.transform.position = startPos;
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

            // get xp
            playerUnit.AddXP(enemyUnit.GetUnitLevel() * 2);

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

        if (playerUnit.GetMaxHP() / 2 > playerUnit.GetCurrentHP())
        {
            playerUnit.SetCurrentHP(playerUnit.GetCurrentHP() + (playerUnit.GetMaxHP() / 2));
            playerHUD.setHP(playerUnit.GetCurrentHP());
            playerHUD.setHUD(playerUnit);
        }
        else
        {
            playerUnit.SetCurrentHP(playerUnit.GetMaxHP());
            playerHUD.setHP(playerUnit.GetCurrentHP());
            playerHUD.setHUD(playerUnit);
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
   public void UpdateSoulUI(int soulCount)
{
  // First, clear out any existing soul prefabs
    foreach (Transform child in soulContainer.transform)
    {
        GameObject.Destroy(child.gameObject);
    }

    // Define the starting position and offset for each soul
    Vector3 startPosition = new Vector3(0, 3, 0); // Adjust as needed
    float xOffset = 1f; // Horizontal offset between souls

    // Now, instantiate new soul prefabs based on the soulCount
    for (int i = 0; i < soulCount; i++)
    {
        Debug.Log("Instantiating soul prefab number: " + (i + 1));

        // Instantiate the soul prefab
        GameObject newSoul = Instantiate(soulPrefab, soulContainer.transform, false);

        // Set the position with an offset for each soul
        newSoul.transform.position = new Vector3(startPosition.x + (xOffset * i), startPosition.y, startPosition.z);
    }

}
}
