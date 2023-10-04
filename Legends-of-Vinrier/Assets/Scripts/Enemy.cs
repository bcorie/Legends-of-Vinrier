using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Unit
{
    private string attackName;

    public Enemy(string unitName, int unitLevel, int damage, int maxHP, string attackName) : base(unitName, unitLevel, damage, maxHP)
    {
        this.attackName = attackName;
    }

    public string GetAttackName()
    {
        return this.attackName;
    }

    public abstract void Attack(Player player);
}
