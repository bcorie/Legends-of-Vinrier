using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private string itemName;
    private int damage;

    public Item(string itemName, int damage)
    {
        this.itemName = itemName;
        this.damage = damage;
    }

    public string GetItemName()
    {
        return this.itemName;
    }

    public int GetDamage()
    {
        return this.damage;
    }
}
