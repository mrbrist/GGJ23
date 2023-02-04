using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;

    public void AddItem(Vegetable vegetable)
    {
        for(int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if(itemInSlot == null)
            {
                SpawnNewItem(vegetable, slot);
                return;
            }
        }
    }

    void SpawnNewItem(Vegetable vegetable, InventorySlot slot)
    {
        GameObject newVegetableGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newVegetableGo.GetComponent<InventoryItem>();
        inventoryItem.InitializeVegtable(vegetable);
    }
}
