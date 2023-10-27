using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;
public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Text levelText;
    public Slider hpSlider;

    public Text hpCurrent;

    public Text hpMax;
    public void setHUD(Unit unit)
    {
        nameText.text = unit.GetUnitName();
        levelText.text = "Lvl " + unit.GetUnitLevel();
        hpSlider.maxValue = unit.GetMaxHP();
        hpSlider.value = unit.GetCurrentHP();
        hpCurrent.text = unit.GetCurrentHP().ToString();
        hpMax.text = unit.GetMaxHP().ToString();
    }

    public void setHP(int hp)
    {
        // keep the HP value at a minimum of 0
        int val = (hp < 0) ? 0 : hp;
        hpSlider.value = val;
        hpCurrent.text = val.ToString();

        Debug.Log("Set hp to " + val);
    }
}
