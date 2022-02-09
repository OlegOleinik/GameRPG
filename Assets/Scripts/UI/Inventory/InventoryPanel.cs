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
    //Смена выбранной клетки инвентаря, ее цвета и отмена выделения предыдущей, если она имеется
    public void ChangeSelected(InventoryCellScript newSelectedCell)
    {
        if (selectedCell!=null)
        {
            ClearSelected();
        }
        selectedCell = newSelectedCell;
        selectedCell.selected = true;
        selectedCell.GetComponent<Image>().color = new Color(0.59f, 0.29f, 0.29f, 1);
        dropItemCountSlider.maxValue = System.Convert.ToInt32(newSelectedCell.text.text);
    }

    //Очистка клетки от выделения
    public void ClearSelected()
    {
        selectedCell.GetComponent<Image>().color = new Color(1f, 0.7f, 0.44f, 1);
        selectedCell.selected = false;
        selectedCell = null;
    }
    //Получение инвентаря игрока, массива клеток инвентаря, дезактивация инвентаря на начало игры
    private void Start()
    {
        playerInventory = GetComponentInParent<UIScript>().player.GetComponent<Inventory>();
        inventoryCellScripts = gameObject.GetComponentsInChildren<InventoryCellScript>();
        gameObject.SetActive(false);
    }
    //Удалить вещь из инвентаря. Если выбранная клетка есть, то по количеству спавнить на карте вещь, затем удалять из инвентаря, перерисовать инвентарь, очистить выделенную клетку
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
    //Отрисовка инвентаря. Сначала очистка
    public void DrawInventoty()
    {
        ClearInventory();
        for (int i = 0; i < inventoryCellScripts.Length && i < playerInventory.inventorySlots.Count; i++)
        {
            inventoryCellScripts[i].DrawCell(playerInventory.inventorySlots[i].ItemScriptableObject, playerInventory.inventorySlots[i].count, i);
        }
    }
    //Очистка инвентаря (визуальная)
    public void ClearInventory()
    {
        foreach (InventoryCellScript cell in inventoryCellScripts)
        {
            cell.ClearCell();
            
        }
    }
    //Описание предмета при наведении курсора
    public void SetDescription(InventoryCellScript cell)
    {
        if(cell.item!=null)
        {
            description.SetDescription(cell.item.description);
        }

    }
    //Убрать описание, когда курсор покадает ячейку инвентаря
    public void ClearDescription()
    {
        description.ClearDescription();
    }


}
