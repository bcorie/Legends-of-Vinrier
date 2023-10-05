using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Communicates with the Battle System to show the result screen.
/// </summary>
public class BattleEnd : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI resultText, xpText;

    [SerializeField]
    private UnityEngine.UI.Button button;

    private BattleSystem battleSystem;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        battleSystem = GameManager.Instance.battleSystem;

        if (battleSystem.state == BattleState.WIN)
        {
            resultText.text = "You won!";
            int xpWon = battleSystem.enemyUnit.GetUnitLevel();

            xpText.text = "XP: " + xpWon + " + " + GameManager.Instance.player.GetXP() + " = " + GameManager.Instance.player.AddXP(xpWon);

            button.GetComponent<TextMeshProUGUI>().text = "Continue";
        }

        else if (battleSystem.state == BattleState.LOSE)
        {
            resultText.text = "You lost...";
            
            button.GetComponent<TextMeshProUGUI>().text = "Restart";
        }
    }

    public void ButtonPress()
    {
        GameManager.Instance.ButtonPress();
    }
}