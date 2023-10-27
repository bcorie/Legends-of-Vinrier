using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public void SkillClick()
    {
        // open skill tree menu
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
    }
}
