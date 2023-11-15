using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handle cross-scene and core data throughout the game.
/// </summary>
[CreateAssetMenu(fileName = "GameManager", menuName = "ScriptableObject/GameManagerSO")]
public class GameManager : ScriptableObject
{
    [SerializeField]
    GameObject player; // player prefab with Player class
    public int playerHealth;
    public Vector2 playerPosition;

    // This variable will allow us to test the boss battle until the system
    // is reworked to have and use a list of enemies in the GameManager.
    public bool boss1 = false;

    /*
    [SerializeField]
    BattleSystem battleSystem;
    */

    // store scene names in an array
    Scene[] scenes =
    {
        SceneManager.GetSceneByPath("Assets/Scenes/Map 1.unity"),
        SceneManager.GetSceneByPath("Assets/Scenes/SkillTree.unity")

        // add rest
    };

    /// <summary>
    /// "Switches" scenes by activating or deactivating their objects.
    /// </summary>
    /// <param name="oldScene">The initial scene to be inactive.</param>
    /// <param name="newScene">The target scene to become active.</param>
    public void SwitchSceneByObjects(Scene oldScene, Scene newScene)
    {
        GameObject[] oldObject = oldScene.GetRootGameObjects();
        GameObject[] newObjects = newScene.GetRootGameObjects();

        foreach (GameObject o in oldObject)
        {
            o.SetActive(false);
        }

        foreach (GameObject o in newObjects)
        {
            o.SetActive(true);
        }
    }
}
