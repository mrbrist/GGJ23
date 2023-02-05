using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
    public InventoryManager InventoryManager;
    public Vegetable[] boughtVegetables;

    PlayerMoney money;

    public void BoughtVegetables(int id)
    {
        bool result = InventoryManager.AddItem(boughtVegetables[id]);
        if(result == true)
        {
            Debug.Log("Item added");
        }
        else
        {
            Debug.Log("ITEM NOT ADDED");
        }
    }

    public void GetSelectedVegetable()
    {
        Vegetable receivedVegetable = InventoryManager.GetSelectedVegetable(false);
        if(receivedVegetable != null)
        {
            Debug.Log("Received item: " + receivedVegetable);
            
        }
        else
        {
            Debug.Log("Item NOT received");
        }
    }

    public void UseSelectedVegetable()
    {
        Vegetable receivedVegetable = InventoryManager.GetSelectedVegetable(true);
        if (receivedVegetable != null)
        {
            Debug.Log("Used item: " + receivedVegetable);
        }
        else
        {
            Debug.Log("Item NOT USED");
        }
    }
}
