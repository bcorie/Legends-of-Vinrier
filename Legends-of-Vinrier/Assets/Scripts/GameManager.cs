using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handle cross-scene and core data throughout the game.
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject player; // player prefab with Player class
    public int playerHealth;
    public Vector2 playerPosition;
    public string currentScene;
    public int playerLevel;
    public List<Item> playerInventory;
    // This variable will allow us to test the boss battle until the system
    // is reworked to have and use a list of enemies in the GameManager.
    public bool boss1 = false;

    /*
    [SerializeField]
    BattleSystem battleSystem;
    */
    void Awake()
    {
        /* objects will be destroyed when a new scene
         * is loaded, but this prevents it from happening
         * so all data can be moved across scenes
         */
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
        Debug.Log("[GameManager] Awake and setup complete.");
    }
     public void SaveState()
    {
        playerPosition = GameObject.FindWithTag("Player").transform.position;
        currentScene = SceneManager.GetActiveScene().name;
        // Save other necessary states here
         Debug.Log($"[GameManager] State saved: Scene - {currentScene}, Position - {playerPosition}");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"[GameManager] Scene loaded: {scene.name}");
        if (scene.name == currentScene)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                player.transform.position = playerPosition;
                Debug.Log($"[GameManager] Player position restored to {playerPosition}");
                // Restore other states if necessary
            }
            else
            {
                Debug.LogError("[GameManager] Player object not found!");
            }
        }
    }
}
