using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySphinx : Enemy
{
    public EnemySphinx(int unitLevel) : base("The Second Sun", unitLevel, unitLevel, (54 + 6 * unitLevel), "Calculated Strike", (2 * unitLevel), (3 * unitLevel),0)
    {
        // Stats for an enemy Sphinx boss
    }

    // Basic attack: the player takes damage equal to the enemy's damage stat.
    public override void Attack(Player player)
    {
        // This attack deals random damage between the player's Damage plus this unit's Damage and (twice that amount).
        int randomDamage = Random.Range(player.GetDamage() + this.GetDamage(), (player.GetDamage() + this.GetDamage()) * 2 + 1);
        player.TakeDamage(randomDamage, DamageType.Physical);

        // Small self heal
        this.SetCurrentHP(this.GetCurrentHP() + (unitLevel * 2));

        // Decrease player's armor after the attack
        player.SetPhysicalArmor(player.GetPhysicalArmor() - 1);
        player.SetMagicalArmor(player.GetMagicalArmor() - 1);
    }
}
