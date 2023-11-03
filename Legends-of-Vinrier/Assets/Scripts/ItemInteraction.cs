using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public Item itemData;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (itemData != null && InventoryManager.instance != null)
            {
                gameObject.SetActive(false);
                InventoryManager.instance.AddItem(itemData);
            }
            else
            {
                Debug.Log("Item or InventoryManager instance is null.");
            }
        }
    }
}
