using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OverworldHUD : MonoBehaviour
{
    Player playerUnit;
    public BattleHUD playerHUD;

    [SerializeField]
    private MenuManager menu;
    [SerializeField]
    private GameObject menuControlHUD;
    private TextMeshProUGUI menuText;
    [SerializeField]
    private GameObject inventoryHUD;

    // Start is called before the first frame update
    void Start()
    {
        playerUnit = new Player("Player", 1, 5, 40, 3, 1, 40);
        playerHUD.setHUD(playerUnit);

        menu.gameObject.SetActive(false);
        menuText = menuControlHUD.GetComponentInChildren<TextMeshProUGUI>();
        menuText.text = "Open menu";
    }

    // Update is called once per frame
    void Update()
    {
        playerHUD.setHUD(playerUnit);
    }

    /// <summary>
    /// Toggle menu view.
    /// </summary>
    public void MenuToggle()
    {
        if (menu.gameObject.activeSelf) // menu active
        {
            menuText.text = "Open menu";
            menu.gameObject.SetActive(false);
            //inventoryHUD.SetActive(false);
        }
        else // menu inactive
        {
            menuText.text = "Close menu";
            menu.gameObject.SetActive(true);
        }
    }
}
