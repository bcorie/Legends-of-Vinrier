using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : Enemy
{
    public EnemyMelee(int unitLevel) : base("Melee", unitLevel, 3, 30, "Swing")
    {
        // Stats for a melee enemy
    }

    // Basic attack: the player takes damage equal to the enemy's damage stat.
    public override void Attack(Player player)
    {
        player.TakeDamage(this.GetDamage());
    }
}
