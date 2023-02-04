using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
    public InventoryManager InventoryManager;
    public Vegetable[] boughtVegetables;

    public void BoughtVegetables(int id)
    {
        InventoryManager.AddItem(boughtVegetables[id]);
    }
}
