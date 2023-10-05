using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handle cross-scene and core data throughout the game.
/// 
/// ( Window > Package Manager > plus in the top left, git URl, https://github.com/Baker-IGM/IGM-Unity-Singleton.git )
/// Now we can call GameManager anywhere!
/// </summary>
///
public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    GameObject player; // player prefab with Player class

    [SerializeField]
    BattleSystem battleSystem;

    // Start is called before the first frame update
    void Start()
    {
        /* objects will be destroyed when a new scene
         * is loaded, but this prevents it from happening
         * so all data can be moved across scenes
         */
        DontDestroyOnLoad(this);




    }

    // Update is called once per frame
    void Update()
    {
        #region Scene Management

        // battle scene to result screen based on outcome
        if (SceneManager.GetActiveScene().name == "BattleScene")
        {
            if (battleSystem.state == BattleState.LOSE)
            {

            }

            if (battleSystem.state == BattleState.WIN)
            {

            }
        }

        #endregion Scene Management
    }
}
