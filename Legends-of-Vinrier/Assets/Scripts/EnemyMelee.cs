using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : Enemy
{
    public EnemyMelee(int unitLevel) : base("Melee", unitLevel, (4 + 4 * unitLevel), (20 + 10 * unitLevel), "Swing", (2 + unitLevel), 0)
    {
        // Stats for a melee enemy
    }

    // Basic attack: the player takes damage equal to the enemy's damage stat.
    public override void Attack(Player player)
    {
        int randomDamage = Random.Range(this.GetDamage() / 2, this.GetDamage() + 1);
        player.TakeDamage(randomDamage, DamageType.Physical);
    }
}
