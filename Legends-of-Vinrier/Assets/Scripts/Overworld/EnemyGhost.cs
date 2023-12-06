using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGhost : Enemy
{
    public EnemyGhost(int unitLevel) : base("Ghost", unitLevel, (2 + 2 * unitLevel), (10 + 2 * unitLevel), "Ethereal Slap", 100, unitLevel)
    {
        // Stats for an enemy Ghost
    }

    // Basic attack: the player takes damage equal to the enemy's damage stat.
    public override void Attack(Player player)
    {
        // This attack deals random damage between the unit's Damage and (twice the unit's Damage).
        int randomDamage = Random.Range(this.GetDamage(), this.GetDamage() * 2 + 1);
        player.TakeDamage(randomDamage, DamageType.Magical);
    }
}
