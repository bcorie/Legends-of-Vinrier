using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMage : Enemy
{
    public EnemyMage(int unitLevel) : base("Mage", unitLevel, 5, 20, "Fire Bolt")
    {
        // Stats for an enemy Mage
    }

    // Basic attack: the player takes damage equal to the enemy's damage stat.
    public override void Attack(Player player)
    {
        player.TakeDamage(this.GetDamage());
    }
}
