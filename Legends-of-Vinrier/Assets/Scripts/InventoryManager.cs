using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public GameObject inventoryPanel;
    public GameObject inventoryItem;
    public GameObject itemSlot;

    public List<Item> items = new List<Item>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void AddItem(Item item)
    {
        items.Add(item);

        UpdateUI();
    }

    public void RemoveItem(string itemName)
    {
        Item itemToRemove = items.Find(item => item.name == itemName);
        if (itemToRemove != null)
        {
            items.Remove(itemToRemove);

            UpdateUI();
        }
    }

    void UpdateUI()
    {
        // Clear existing UI elements from the inventoryPanel
        foreach (Transform child in inventoryPanel.transform)
        {
            Destroy(child.gameObject);
        }
        
        // Instantiate item slots for each item in the inventory
        //foreach (inventoryItem item in items)
        //{
        //    GameObject slot = Instantiate(itemSlot, inventoryPanel.transform);
        //    Image slotImage = slot.GetComponent<Image>();
        //    slotImage.sprite = item.icon;
        //    slot.transform.Find("ItemNameText").GetComponent<Text>().text = item.name;
        //}
    }
}
