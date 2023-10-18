using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldHUD : MonoBehaviour
{
    Player playerUnit;
    public BattleHUD playerHUD;
    // Start is called before the first frame update
    void Start()
    {
        playerUnit = new Player("Player", 1, 5, 35);
        playerHUD.setHUD(playerUnit);
    }

    // Update is called once per frame
    void Update()
    {
        playerHUD.setHUD(playerUnit);
    }
}
