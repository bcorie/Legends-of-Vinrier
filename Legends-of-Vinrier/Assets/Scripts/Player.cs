using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : Unit
{
    private Vector3 position;
    private List<Item> inventory = new List<Item>();

    public Player(string unitName, int unitLevel, int damage, int maxHP) : base(unitName, unitLevel, damage, maxHP)
    {
        this.position = Vector3.zero;
    }

    public Vector3 GetPosition()
    {
        return this.position;
    }

    public void SetPosition(Vector3 position)
    {
        this.position = position;
    }
}
