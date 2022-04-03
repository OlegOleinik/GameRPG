using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    InventoryCellScript[] inventoryCellScripts;
    private Inventory playerInventory;
    public DropedItem dropedItem;
    public ItemDescription description;
    private InventoryCellScript _selectedCell;
    [SerializeField] private UseButton useButton;
    [SerializeField] private Slider dropItemCountSlider;
    [SerializeField] private SwordCell swordCell;
    [SerializeField] private Text money;

    public InventoryCellScript selectedCell
    {
        get
        {
            return _selectedCell;
        }
    }

    //Получение инвентаря игрока, массива клеток инвентаря, дезактивация инвентаря на начало игры
    private void Start()
    {
        playerInventory = GameManager.player.GetComponent<Inventory>();
        inventoryCellScripts = gameObject.GetComponentsInChildren<InventoryCellScript>();
        gameObject.SetActive(false);
    }



    //Смена выбранной клетки инвентаря, ее цвета и отмена выделения предыдущей, если она имеется
    public void ChangeSelected(InventoryCellScript newSelectedCell)
    {
        if (_selectedCell != null)
        {
            ClearSelected();
        }
        _selectedCell = newSelectedCell;
        _selectedCell.selected = true;
        _selectedCell.GetComponent<Image>().color = new Color(0.59f, 0.29f, 0.29f, 1);
        dropItemCountSlider.maxValue = System.Convert.ToInt32(newSelectedCell.text.text);
        useButton.ChangeActive(_selectedCell);
    }

    //Очистка клетки от выделения
    public void ClearSelected()
    {
        _selectedCell.GetComponent<Image>().color = GameManager.cellColorDefault;
        _selectedCell.selected = false;
        _selectedCell = null;
        useButton.ChangeActive(_selectedCell);
    }

    //Удалить вещь из инвентаря. Если выбранная клетка есть, то по количеству спавнить на карте вещь, затем удалять из инвентаря, перерисовать инвентарь, очистить выделенную клетку
    public void DropItem()
    {
        if(_selectedCell != null)
        {
            Vector2 side;
            if (GameManager.player.GetComponent<SpriteRenderer>().flipX)
            {
                side = new Vector2(-1f, 0);
            }
            else
            {
                side = new Vector2(1f, 0);
            }


            for (int i = 0; i < dropItemCountSlider.value; i++)
            {
                dropedItem.DropItem(_selectedCell.item, GameManager.player.GetComponent<Rigidbody2D>().position + side);
                playerInventory.DeliteItem(_selectedCell.id);


            }
            DrawInventory();
            ClearSelected();
        }
    }

    public void SetSword()
    {
        //GameObject.Find("Sword").GetComponent<Sword>().SetSword();
        if (swordCell.item!=null)
        {
            ItemScriptableObject saveSword = swordCell.item;
            swordCell.DrawCell(_selectedCell.item);
            playerInventory.ReplaceItem(_selectedCell.id, saveSword);
            
        }
        else
        {
            swordCell.DrawCell(_selectedCell.item);
            playerInventory.DeliteItem(_selectedCell.id);
            
        }
        DrawInventory();
        ClearSelected();
        GameManager.player.GetComponent<AttackController>().sword.SetSword(swordCell.item as SwordScriptableObject);


    }


    public void UsePotion()
    {
        GameManager.player.GetComponent<Player>().RecoverHP((_selectedCell.item as PotionScriprableObject).recoveryHP);
        string count = _selectedCell.text.text;
        playerInventory.DeliteItem(_selectedCell.id);
        DrawInventory();
        if (count == "1")
        {
            ClearSelected();
        }
    }

    //Отрисовка инвентаря. Сначала очистка
    public void DrawInventory()
    {
        money.text = $"{GameManager.player.GetComponent<Player>().money}";
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
            cell.OnMouseExit();
            cell.ClearCell();
            
        }
        ClearDescription();
    }
    //Описание предмета при наведении курсора
    public void SetDescription(AItemCell cell)
    {
        if(cell.item!=null)
        {
            ItemScriptableObject item = cell.item;
            string text = $"{item.itemName}\n\n{item.description}\n\nCost: {item.cost}";
            if (cell.item.type=="Sword")
            {
                text += $"\nDamage: {(item as SwordScriptableObject).damage}";
            }
            if (cell.item.type == "Potion")
            {
                text += $"\nRecover: {(item as PotionScriprableObject).recoveryHP} HP";
            }
            description.SetDescription(text);
        }

    }
    //Убрать описание, когда курсор покадает ячейку инвентаря
    public void ClearDescription()
    {
        description.ClearDescription();
    }

    public string GetSelectedCellType()
    {
        if (_selectedCell.item!=null)
        {
            return _selectedCell.item.type;
        }
        return "";
    }


    public void SellItem()
    {
        if (_selectedCell != null)
        {
            Player player = GameManager.player.GetComponent<Player>();
            for (int i = 0; i < dropItemCountSlider.value; i++)
            {
                player.money += System.Convert.ToInt32(_selectedCell.item.cost - (selectedCell.item.cost * (0.5 / player.speech)));
                playerInventory.DeliteItem(_selectedCell.id);
            }
            DrawInventory();
            ClearSelected();
        }
    }

}
