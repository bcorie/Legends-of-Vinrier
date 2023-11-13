using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDescriptionPanel : MonoBehaviour
{
    public GameObject itemDescriptionPanel;

    void Start()
    {
        itemDescriptionPanel.SetActive(false);
    }

    void ShowItemDescription(Item item)
    {
        // Populate the item description panel with the item's details
        // For instance, update Text UI components to display item.name and item.description
        itemDescriptionPanel.SetActive(true);
    }

    public void CloseItemDescriptionPanel()
    {
        itemDescriptionPanel.SetActive(false);
    }
}
