using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : Unit
{
    private Vector3 position;
    private List<Item> inventory;
    public GameObject playerGameObject;
    private int xp;
    public Player(string unitName, int unitLevel, int damage, int maxHP, int physicalArmor, int magicalArmor, int mana) : base(unitName, unitLevel, damage, maxHP, physicalArmor, magicalArmor, mana)
    {
        this.position = Vector3.zero;
        this.inventory = new List<Item>();
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            if (gameManager.playerHealth > 0)
            {
                this.SetCurrentHP(gameManager.playerHealth);
            }
            else
            {
                gameManager.playerHealth = this.GetMaxHP();
            }
        }
    }

    // Rename to the specific attack once different weapons are included
    public void PhysicalAttack(Enemy enemy)
    {
        // This attack deals random damage between the unit's Damage and twice the unit's Damage.
        int randomDamage = Random.Range(this.GetDamage(), this.GetDamage() * 2 + 1);
        enemy.TakeDamage(randomDamage, DamageType.Physical);
    }

    // Rename to the specific attack once different weapons are included
    public void MagicalAttack(Enemy enemy)
    {
        // This attack deals random damage between the unit's Damage - 1 and twice (the unit's Damage - 1).
        int randomDamage = Random.Range(this.GetDamage() - 1, (this.GetDamage() - 1) * 2 + 1);
        enemy.TakeDamage(randomDamage, DamageType.Magical);
    }

    public Vector3 GetPosition()
    {
        return this.position;
    }

    public List<Item> GetInventory()
    {
        return this.inventory;
    }

    public void SetPosition(Vector3 position)
    {
        this.position = position;
    }

    public void InventoryAdd(Item item)
    {
        inventory.Add(item);
    }

    public int GetLevel()
    {
        return unitLevel;
    }

    public void SetLevel(int newLevel)
    {
        unitLevel = newLevel;
    }
    public void EarnXP(int amount)
    {
        xp += amount;
        CheckForLevelUp();
    }

    public void CheckForLevelUp()
    {
        int requiredXP = CalculateRequiredXP();
        while (xp >= requiredXP)
        {
            xp -= requiredXP;
            LevelUp();
            requiredXP = CalculateRequiredXP();
        }
    }

    public int CalculateRequiredXP()
    {
        return GetLevel() * 100;
    }

    public void LevelUp()
    {
        int newLevel = GetLevel() + 1;
        SetLevel(newLevel);
    }
}
