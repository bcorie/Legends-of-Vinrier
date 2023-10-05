using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private string itemName;

    public Item(string itemName)
    {
        this.itemName = itemName;
    }

    public string GetItemName()
    {
        return this.itemName;
    }
}
