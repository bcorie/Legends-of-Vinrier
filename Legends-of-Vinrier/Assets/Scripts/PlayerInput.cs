using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidbody;
    private Vector2 moveDirection;

    // A count for five frames to delete any enemies that the player contacts
    private int spawnOnEnemyCount;

    [SerializeField]
    private OverworldHUD hud;

    public GameObject inventoryPanel;
    public InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            if (gameManager.playerPosition != null)
            {
                rigidbody.position = gameManager.playerPosition;
            }
            else
            {
                gameManager.playerPosition = Vector2.zero;
            }
        }

        spawnOnEnemyCount = 5;
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();

        if (spawnOnEnemyCount > 0)
        {
            spawnOnEnemyCount--;
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void GetInputs()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(x, y).normalized;

        // I = Inventory
        if (Input.GetKeyDown(KeyCode.I))
        {
           ToggleInventory();
        }

        // ESC = Menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            hud.MenuToggle();
        }

    }

    void Move()
    {
        rigidbody.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision Detected!");

        if (collision.CompareTag("Enemy"))
        {
            if (spawnOnEnemyCount > 0)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                GameManager gameManager = FindObjectOfType<GameManager>();
                if (gameManager != null)
                {
                    gameManager.playerPosition = rigidbody.position;
                }
                SceneManager.LoadScene("BattleScene");
            }
        }
    }

    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }
}
