using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : Enemy
{
    public EnemyMelee(int unitLevel) : base("Melee", unitLevel, (2 + 2 * unitLevel), (20 + 10 * unitLevel), "Swing", (2 + unitLevel), 0,0)
    {
        // Stats for a melee enemy
    }

    // Basic attack: the player takes damage equal to the enemy's damage stat.
    public override void Attack(Player player)
    {
        // This attack deals random damage between the unit's Damage and twice the unit's Damage.
        int randomDamage = Random.Range(this.GetDamage(), this.GetDamage() * 2 + 1);
        player.TakeDamage(randomDamage, DamageType.Physical);
    }
}
