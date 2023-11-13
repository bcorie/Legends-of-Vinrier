using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite icon;

    public Item(string itemName, Sprite icon)
    {
        this.name = itemName;
        this.icon = icon;
    }

    public string GetItemName()
    {
        return itemName;
    }

    public void SetItemName(string newName)
    {
        itemName = newName;
    }
}
