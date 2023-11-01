using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Unit
{
    private string attackName;
    public GameObject enemyGameObject;
    public Enemy(string unitName, int unitLevel, int damage, int maxHP, string attackName, int physicalArmor, int magicalArmor) : base(unitName, unitLevel, damage, maxHP, physicalArmor, magicalArmor)
    {
        this.attackName = attackName;
    }

    public string GetAttackName()
    {
        return this.attackName;
    }

    public abstract void Attack(Player player);
}
