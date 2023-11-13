using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyElgrim : Enemy
{
    private int souls;

    public int GetSouls()
    {
        return souls;
    }
    public EnemyElgrim(int unitLevel) : base("The Demon Lord Elgrim", unitLevel, (10 + 3 * unitLevel), (50 + 10 * unitLevel), "Soulfire", 0, 0)
    {
        // Stats for the first boss, Elgrim (name TBD)

        this.souls = 0;
    }

    // Basic attack: the player takes damage equal to the enemy's damage stat.
    public override void Attack(Player player)
    {
        if (this.souls <= 0)
        {
            this.souls = Random.Range(1, GetUnitLevel() + 1);
            FindObjectOfType<BattleSystem>().UpdateSoulUI(this.souls);
        }
        else
        {
            for (; souls > 0; souls--)
            {
                // This attack deals random damage between the unit's Damage and (twice the unit's Damage).
                int randomDamage = Random.Range(this.GetDamage(), this.GetDamage() * 2 + 1);
                player.TakeDamage(randomDamage, DamageType.Magical);
            }
            FindObjectOfType<BattleSystem>().UpdateSoulUI(this.souls);
        }
    }

    public override void TakeDamage(int dmg, DamageType type)
    {
        if (this.souls > 0)
        {
            souls--;
            FindObjectOfType<BattleSystem>().UpdateSoulUI(this.souls);

            if (type == DamageType.Physical)
            {
                dmg -= this.GetPhysicalArmor() + this.GetUnitLevel();
            }
            else if (type == DamageType.Magical)
            {
                dmg -= this.GetMagicalArmor() + this.GetUnitLevel();
            }

            if (dmg > 0)
            {
                this.SetCurrentHP(this.GetCurrentHP() - dmg);
            }
        }
        else
        {
            base.TakeDamage(dmg, type);
        }
    }
}
