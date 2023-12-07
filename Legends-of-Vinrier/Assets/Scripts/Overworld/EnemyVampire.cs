using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVampire : Enemy
{
    public EnemyVampire(int unitLevel) : base("Damon, the Undying", unitLevel, (8 + 2 * unitLevel), (45 + 15 * unitLevel), "Drain Life", (unitLevel), (2 * unitLevel),0)
    {
        // Stats for an enemy Vampire boss
    }

    // Basic attack: the player takes damage equal to the enemy's damage stat.
    public override void Attack(Player player)
    {
        // This attack deals random damage between the this unit's Damage and thrice that amount.
        int randomDamage = Random.Range(player.GetDamage() + this.GetDamage(), (player.GetDamage() + this.GetDamage()) * 2 + 1);
        player.TakeDamage(randomDamage, DamageType.Physical);

        // Self heal equal to half the damage dealt
        if (randomDamage - player.GetPhysicalArmor() > 0)
        {
            this.SetCurrentHP(this.GetCurrentHP() + (randomDamage - player.GetPhysicalArmor()) / 2);
        }

        // Increase this unit's armor after the attack
        int randomArmorType = Random.Range(0, 2);
        if (randomArmorType == 0)
        {
            this.SetPhysicalArmor(this.GetPhysicalArmor() + 1);
        }
        else
        {
            this.SetMagicalArmor(this.GetMagicalArmor() + 1);
        }
    }
}
