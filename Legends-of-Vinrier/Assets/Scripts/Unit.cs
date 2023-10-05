using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private string unitName;
    private int unitLevel;
    private int unitXP;
    private int damage;
    private int maxHP;
    private int currentHP;

    public Unit(string unitName, int unitLevel, int unitXP, int damage, int maxHP)
    {
        this.unitName = unitName;
        this.unitLevel = unitLevel;
        this.unitXP = unitXP;
        this.damage = damage;
        this.maxHP = maxHP;
        this.currentHP = maxHP;
    }

    public virtual bool TakeDamage(int dmg)
    {
        currentHP -= dmg;
        if(currentHP <= 0 )
        {
            return true;
        }
        else{
            return false;
        }
    }

    public string GetUnitName()
    {
        return this.unitName;
    }

    public int GetUnitLevel()
    {
        return this.unitLevel;
    }

    public int GetXP()
    {
        return this.unitXP;
    }

    public int GetDamage()
    {
        return this.damage;
    }

    public int GetMaxHP()
    {
        return this.maxHP;
    }

    public int GetCurrentHP()
    {
        return this.currentHP;
    }

    public void SetCurrentHP(int newValue)
    {
        this.currentHP = newValue;
    }
}
