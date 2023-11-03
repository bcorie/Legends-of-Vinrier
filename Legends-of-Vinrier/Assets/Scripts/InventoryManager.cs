using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public Transform inventoryPanel;
    public GameObject inventoryItemPrefab;
    public GameObject itemInfoPanel;

    public List<Item> collectedItems = new List<Item>();
    public List<GameObject> inventorySlots = new List<GameObject>();

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
        if (!collectedItems.Contains(item))
        {
            collectedItems.Add(item);
            UpdateUI();

            // Create the UI element for the new item
            GameObject itemUI = Instantiate(inventoryItemPrefab);

            // Find or create a container for the inventory items in the scene hierarchy
            GameObject itemContainer = GameObject.Find("InventoryItemsContainer");
            if (itemContainer == null)
            {
                itemContainer = new GameObject("InventoryItemsContainer");
            }
            itemUI.transform.SetParent(itemContainer.transform, false); // Set the parent here

            // Access the Image component and assign the item's icon
            Image itemImage = itemUI.GetComponentInChildren<Image>();
            itemImage.sprite = item.icon;

            Button button = itemUI.GetComponent<Button>();
            button.onClick.AddListener(() => ShowItemInfo(item));
        }
        else
        {
            Debug.Log("Item " + item.name + " is already in the inventory.");
        }
    }

    public void RemoveItem(string itemName)
    {
        Item itemToRemove = collectedItems.Find(item => item.name == itemName);
        if (itemToRemove != null)
        {
            collectedItems.Remove(itemToRemove);
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < collectedItems.Count; i++)
        {
            int index = i; // Create a local copy of 'i' for each item
            if (i < inventorySlots.Count)
            {
                Image slotImage = inventorySlots[i].GetComponent<Image>();
                slotImage.sprite = collectedItems[i].icon;

                Button slotButton = inventorySlots[i].GetComponent<Button>();
                slotButton.onClick.RemoveAllListeners(); // Clear previous listeners
                slotButton.onClick.AddListener(() => ShowItemInfo(collectedItems[index]));
            }
            else
            {
                GameObject itemUI = Instantiate(inventoryItemPrefab, inventoryPanel);
                inventorySlots.Add(itemUI);
                Image slotImage = itemUI.GetComponent<Image>();
                slotImage.sprite = collectedItems[i].icon;

                Button slotButton = itemUI.GetComponent<Button>();
                slotButton.onClick.AddListener(() => ShowItemInfo(collectedItems[index]));
            }
        }
    }

    void ShowItemInfo(Item item)
    {
        // Show the item information panel
        itemInfoPanel.SetActive(true);
    }

    // Add a method to close the item information panel
    public void CloseItemInfoPanel()
    {
        itemInfoPanel.SetActive(false);
    }
}

