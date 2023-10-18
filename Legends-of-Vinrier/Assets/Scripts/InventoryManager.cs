using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public Transform inventoryPanel;
    public GameObject inventoryItem;
    private List<Item> collectedItems = new List<Item>();


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

    public class CollectedItem
    {
        public string name;
        public Sprite icon;
    }

    public void AddItem(Item item)
    {
        items.Add(item);

        UpdateUI();
    }
    //public void AddItem(string itemName, Sprite itemIcon)
    //{
    //    Item collectedItem = new Item { name = itemName, icon = itemIcon };
    //    collectedItems.Add(collectedItem);
    //
    //    UpdateUI();
    //}

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

        // Instantiate item slots for each collected item
        //foreach (InventoryItem item in items)
        //{
        //    // Find the InventoryItem prefab corresponding to the item
        //    InventoryItemPrefab prefab = FindInventoryItemPrefab(item);
        //
        //    if (prefab != null)
        //    {
        //        GameObject slot = Instantiate(prefab, inventoryPanel.transform);
        //
        //        // Configure the slot with the item's data
        //        Image slotImage = slot.GetComponent<Image>();
        //        Text itemNameText = slot.transform.Find("ItemNameText").GetComponent<Text>();
        //
        //        slotImage.sprite = item.icon;
        //        itemNameText.text = item.name;
        //    }
        //}
    }

    //InventoryItemPrefab FindInventoryItemPrefab(InventoryItem item)
    //{
        // You can implement a method to find the corresponding InventoryItem prefab
        // based on the item's properties, e.g., name or a unique identifier.
        // Return the prefab that matches the item.
    //}
}
