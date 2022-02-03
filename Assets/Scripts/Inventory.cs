using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int inventorySize;
    public List<InventorySLot> inventorySlots;

    private void Awake()
    {
        inventorySlots = new List<InventorySLot>();
    }


    public bool AddItem(ItemScriptableObject item)
    {
        foreach (InventorySLot slot in inventorySlots)
        {
            if (slot.ItemScriptableObject==item && slot.count < item.maxItems)
            {
                slot.count++;
                return true;
            }
        }
        if (inventorySlots.Count>=inventorySize)
        {
            return false;
        }
        inventorySlots.Add(new InventorySLot(item));

        return true;
    }

    public void DeliteItem(int index)
    {
        if (inventorySlots[index].count>1)
        {
            inventorySlots[index].count--;
        }
        else
        {
            inventorySlots.RemoveAt(index);
        }

    }

}

public class InventorySLot
{
    public ItemScriptableObject ItemScriptableObject;
    public int count;
    public InventorySLot(ItemScriptableObject item)
    {
        this.ItemScriptableObject = item;
        this.count = 1;
    }

}