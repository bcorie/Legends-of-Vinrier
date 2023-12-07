using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMummy : Enemy
{
    public EnemyMummy(int unitLevel) : base("Mummy", unitLevel, (3 * unitLevel), (24 + 6 * unitLevel), "Cursed Touch", (2 + unitLevel), (2 + unitLevel),0)
    {
        // Stats for an enemy Mage
    }

    // Basic attack: the player takes damage equal to the enemy's damage stat.
    public override void Attack(Player player)
    {
        // This attack deals random damage between the unit's Damage and (twice the unit's Damage) - 1.
        int randomDamage = Random.Range(this.GetDamage(), this.GetDamage() * 2);
        player.TakeDamage(randomDamage, DamageType.Physical);
    }
}
