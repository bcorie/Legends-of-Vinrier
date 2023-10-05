using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : Unit
{
    private Vector3 position;
    private List<Item> inventory;

    public Player(string unitName, int unitLevel, int damage, int maxHP) : base(unitName, unitLevel, damage, maxHP)
    {
        this.position = Vector3.zero;
        this.inventory = new List<Item>();
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
}
