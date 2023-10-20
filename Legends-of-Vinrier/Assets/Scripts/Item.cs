using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string Name;

    public Item(string itemName)
    {
        this.Name = itemName;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryManager.instance.AddItem(this);

            gameObject.SetActive(false);

            GetComponent<Collider2D>().enabled = false;

            Debug.Log("Player collected: " + this.name);
        }
    }

    public string GetItemName()
    {
        return this.Name;
    }

    public void SetItemName(string newName)
    {
        this.Name = newName;
        return;
    }
}
