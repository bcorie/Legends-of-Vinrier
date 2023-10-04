using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Text levelText;
    public Slider hpSlider;

    public void setHUD(Unit unit)
    {
        nameText.text = unit.GetUnitName();
        levelText.text = "Lvl " + unit.GetUnitLevel();
        hpSlider.maxValue = unit.GetMaxHP();
        hpSlider.value = unit.GetCurrentHP();
    }

    public void setHP(int hp)
    {
        hpSlider.value = hp;
    }
}
