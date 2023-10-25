using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMage : Enemy
{
    public EnemyMage(int unitLevel) : base("Mage", unitLevel, (4 + 5 * unitLevel), (20 + 5 * unitLevel), "Fire Bolt", 0, (2 + unitLevel))
    {
        // Stats for an enemy Mage
    }

    // Basic attack: the player takes damage equal to the enemy's damage stat.
    public override void Attack(Player player)
    {
        int randomDamage = Random.Range(this.GetDamage() / 2, this.GetDamage() + 1);
        player.TakeDamage(randomDamage, DamageType.Magical);
    }
}
