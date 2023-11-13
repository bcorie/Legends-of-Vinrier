using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private string unitName;
    private int unitLevel;
    private int damage;
    private int maxHP;
    private int currentHP;
    private int physicalArmor;
    private int magicalArmor;
    private int xp;

    // Damage types
    public enum DamageType
    {
        Physical,
        Magical
    }

    public Unit(string unitName, int unitLevel, int damage, int maxHP, int physicalArmor, int magicalArmor)
    {
        this.unitName = unitName;
        this.unitLevel = unitLevel;
        this.damage = damage;
        this.maxHP = maxHP;
        this.currentHP = maxHP;
        this.physicalArmor = physicalArmor;
        this.magicalArmor = magicalArmor;
    }

    public virtual void TakeDamage(int dmg, DamageType type)
    {
        if (type == DamageType.Physical)
        {
            dmg -= this.physicalArmor;
        }
        else if (type == DamageType.Magical)
        {
            dmg -= this.magicalArmor;
        }

        if (dmg > 0)
        {
            currentHP -= dmg;
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

    public void AddXP(int amount)
    {
        xp += amount;

        if (xp / 10 > 1)
        {
            unitLevel = (int)(xp / 10);
        }

        Debug.Log("xp: " + xp + ", level: " + unitLevel);
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

    public int GetPhysicalArmor()
    {
        return this.physicalArmor;
    }

    public int GetMagicalArmor()
    {
        return this.magicalArmor;
    }

    public void SetCurrentHP(int newValue)
    {
        this.currentHP = newValue;
    }
}
