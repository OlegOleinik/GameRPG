using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    InventoryCellScript[] inventoryCellScripts;
    private Inventory playerInventory;
    public DropedItem dropedItem;
    public ItemDescription description;
    private InventoryCellScript selectedCell;
    [SerializeField] private Slider dropItemCountSlider;
    public void ChangeSelected(InventoryCellScript newSelectedCell)
    {
        if (selectedCell!=null)
        {
            selectedCell.GetComponent<Image>().color = new Color(1f, 0.7f, 0.44f, 1);
            selectedCell.selected = false;

        }
        selectedCell = newSelectedCell;
        selectedCell.selected = true;
        selectedCell.GetComponent<Image>().color = new Color(0.59f, 0.29f, 0.29f, 1);
        dropItemCountSlider.maxValue = System.Convert.ToInt32(newSelectedCell.text.text);
    }

    public void ClearSelected()
    {
        selectedCell.GetComponent<Image>().color = new Color(1f, 0.7f, 0.44f, 1);
        selectedCell.selected = false;
        selectedCell = null;
    }
    private void Awake()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        inventoryCellScripts = gameObject.GetComponentsInChildren<InventoryCellScript>();
        gameObject.SetActive(false);
    }

    public void DeliteItem()
    {
        if(selectedCell!=null)
        {
            for (int i = 0; i < dropItemCountSlider.value; i++)
            {
                dropedItem.DropItem(selectedCell.item, playerInventory.gameObject.GetComponent<Rigidbody2D>().position + new Vector2(1f, 1f));
                playerInventory.DeliteItem(selectedCell.id);


            }
            DrawInventoty();
            ClearSelected();
        }
    }

    public void DrawInventoty()
    {
        ClearInventory();
        for (int i = 0; i < inventoryCellScripts.Length && i < playerInventory.inventorySlots.Count; i++)
        {
            inventoryCellScripts[i].DrawCell(playerInventory.inventorySlots[i].ItemScriptableObject, playerInventory.inventorySlots[i].count, i);
        }
    }

    public void ClearInventory()
    {
        foreach (InventoryCellScript cell in inventoryCellScripts)
        {
            cell.ClearCell();
            
        }
    }

    public void SetDescription(InventoryCellScript cell)
    {
        if(cell.item!=null)
        {
            description.SetDescription(cell.item.description);
        }

    }

    public void ClearDescription()
    {
        description.ClearDescription();
    }


}
