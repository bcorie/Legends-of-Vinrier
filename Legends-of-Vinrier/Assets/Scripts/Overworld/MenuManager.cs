using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handle button presses for the menu.
/// </summary>
public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InventoryClick()
    {
        inventory.SetActive(!inventory.activeSelf);
        Debug.Log("Inv click");
    }

    public void SkillClick()
    {
        SceneManager.LoadSceneAsync("SkillTree");
    }

    public void OptionClick()
    {
        // open options
    }

    public void SaveClick()
    {
        // save player data
    }

    public void QuitClick()
    {
        // return to title screen
        // or restart playtest

        SceneManager.UnloadSceneAsync("Map 1");
        SceneManager.LoadSceneAsync("Map 1");

    }
}
