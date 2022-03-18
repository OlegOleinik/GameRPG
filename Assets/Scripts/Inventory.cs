using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int inventorySize;
    public List<InventorySlot> inventorySlots;

    private void Awake()
    {
        inventorySlots = new List<InventorySlot>();
    }


    public bool AddItem(ItemScriptableObject item)
    {
        foreach (InventorySlot slot in inventorySlots)
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
        inventorySlots.Add(new InventorySlot(item));

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

    public void ReplaceItem(int index, ItemScriptableObject newItem)
    {
        inventorySlots[index].ItemScriptableObject = newItem;
    }

}

public class InventorySlot
{
    public ItemScriptableObject ItemScriptableObject;
    public int count;
    public InventorySlot(ItemScriptableObject item)
    {
        this.ItemScriptableObject = item;
        this.count = 1;
    }

}