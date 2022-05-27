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
<<<<<<< Updated upstream
<<<<<<< HEAD
    [SerializeField] private Text statText;
    public delegate void NewSelect();
    public event NewSelect onChangeSelected;
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    [SerializeField] private Text statText;
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
    public delegate void NewSelect();
    public event NewSelect onChangeSelected;
=======
=======
>>>>>>> Stashed changes
    [SerializeField] private Text statText;
    public delegate void NewSelect();
    public event NewSelect onChangeSelected;

<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
    [SerializeField] private Text statText;
    public delegate void NewSelect();
    public event NewSelect onChangeSelected;
>>>>>>> Stashed changes
=======
    [SerializeField] private Text statText;
    public delegate void NewSelect();
    public event NewSelect onChangeSelected;
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
    [SerializeField] private Text statText;
    public delegate void NewSelect();
    public event NewSelect onChangeSelected;
>>>>>>> Stashed changes

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
        ResetSlider();
<<<<<<< Updated upstream
<<<<<<< HEAD
=======
>>>>>>> Stashed changes
    }

    private void OnDisable()
    {
        ClearSelected();
    }
<<<<<<< Updated upstream

=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }
    private void OnDisable()
    {
        ClearSelected();
    }

    private void SetSlider(int max)
    {
        dropItemCountSlider.minValue = 1;
        dropItemCountSlider.interactable = true;
        dropItemCountSlider.maxValue = max;
    }
    private void ResetSlider()
    {
        dropItemCountSlider.minValue = 0;
        dropItemCountSlider.value = 0;
        dropItemCountSlider.interactable = false;
    }
    private void ChangeSelectedActive(bool isItemInCell)
    {
        if (isItemInCell)
        {
            SetSlider(System.Convert.ToInt32(_selectedCell.text.text));
        }
        else
        {
            ClearSelected();
        }
=======
>>>>>>> Stashed changes
    }

    private void OnDisable()
    {
        ClearSelected();
    }

=======
    }

    private void OnDisable()
    {
        ClearSelected();
    }

>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======

>>>>>>> Stashed changes
    private void SetSlider(int max)
    {
        dropItemCountSlider.minValue = 1;
        dropItemCountSlider.interactable = true;
        dropItemCountSlider.maxValue = max;
    }

    private void ResetSlider()
    {
        dropItemCountSlider.minValue = 0;
        dropItemCountSlider.value = 0;
        dropItemCountSlider.interactable = false;
    }

    private void ChangeSelectedActive(bool isItemInCell)
    {
        if (isItemInCell)
        {
            SetSlider(System.Convert.ToInt32(_selectedCell.text.text));
        }
        else
        {
            ClearSelected();
        }
    }

    //Смена выбранной клетки инвентаря, ее цвета и отмена выделения предыдущей, если она имеется
    public void ChangeSelected(InventoryCellScript newSelectedCell)
    {
<<<<<<< Updated upstream
<<<<<<< HEAD
=======
>>>>>>> Stashed changes
        ClearSelected();
        if (newSelectedCell.item != null)
        {
            GameManager.ClickPlay();
<<<<<<< Updated upstream
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

        ClearSelected();
        if (newSelectedCell.item != null)
        {
=======
        ClearSelected();
        if (newSelectedCell.item != null)
        {
            GameManager.ClickPlay();
>>>>>>> Stashed changes
=======
        ClearSelected();
        if (newSelectedCell.item != null)
        {
            GameManager.ClickPlay();
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
>>>>>>> Stashed changes
            _selectedCell = newSelectedCell;
            _selectedCell.selected = true;
            _selectedCell.GetComponent<Image>().color = new Color(0.59f, 0.29f, 0.29f, 0.9f);
            SetSlider(System.Convert.ToInt32(newSelectedCell.text.text));
            useButton.ChangeActive(_selectedCell);
            onChangeSelected();
        }

    }

    //Очистка клетки от выделения
    public void ClearSelected()
    {
        if (_selectedCell != null)
        {
<<<<<<< Updated upstream
<<<<<<< HEAD
            GameManager.ClickPlay();
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
            GameManager.ClickPlay();
>>>>>>> Stashed changes
=======
            GameManager.ClickPlay();
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
            GameManager.ClickPlay();
>>>>>>> Stashed changes
            _selectedCell.GetComponent<Image>().color = GameManager.cellColorDefault;
            _selectedCell.selected = false;
            _selectedCell = null;
            useButton.ChangeActive(_selectedCell);
            ResetSlider();
            onChangeSelected();
        }

    }

    //Удалить вещь из инвентаря. Если выбранная клетка есть, то по количеству спавнить на карте вещь, затем удалять из инвентаря, перерисовать инвентарь, очистить выделенную клетку
    public void DropItem()
    {
        if(_selectedCell != null)
        {
<<<<<<< Updated upstream
<<<<<<< HEAD
            GameManager.ClickPlay();
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
            GameManager.ClickPlay();
>>>>>>> Stashed changes
=======
            GameManager.ClickPlay();
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
            GameManager.ClickPlay();
>>>>>>> Stashed changes
            bool isItemInCell = true;
            Vector2 side;
            if (GameManager.player.GetComponent<PlayerAnimator>().isFlip)
            {
                side = new Vector2(-1f, 0);
            }
            else
            {
                side = new Vector2(1f, 0);
            }
<<<<<<< Updated upstream
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD


<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======

>>>>>>> Stashed changes
=======

>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
>>>>>>> Stashed changes
            if (dropItemCountSlider.value >= System.Convert.ToInt32(_selectedCell.text.text))
            {
                isItemInCell = false;
            }
            for (int i = 0; i < dropItemCountSlider.value; i++)
            {
                dropedItem.DropItem(_selectedCell.item, GameManager.player.GetComponent<Rigidbody2D>().position + side);
                playerInventory.DeliteItem(_selectedCell.id);
            }
            DrawInventory();
            ChangeSelectedActive(isItemInCell);
        }
    }




    public void SetSword()
    {
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
<<<<<<< Updated upstream
<<<<<<< HEAD
        ChangeSelectedActive(false);
        GameManager.player.GetComponent<AttackController>().sword.SetSword(swordCell.item as SwordScriptableObject);
        DrawInventory();
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        DrawInventory();
=======
        
>>>>>>> Stashed changes
=======
        
>>>>>>> Stashed changes
        ChangeSelectedActive(false);
        GameManager.player.GetComponent<AttackController>().sword.SetSword(swordCell.item as SwordScriptableObject);
        DrawInventory();

=======
        ChangeSelectedActive(false);
        GameManager.player.GetComponent<AttackController>().sword.SetSword(swordCell.item as SwordScriptableObject);
        DrawInventory();
>>>>>>> Stashed changes
=======
        ChangeSelectedActive(false);
        GameManager.player.GetComponent<AttackController>().sword.SetSword(swordCell.item as SwordScriptableObject);
        DrawInventory();
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
        ChangeSelectedActive(false);
        GameManager.player.GetComponent<AttackController>().sword.SetSword(swordCell.item as SwordScriptableObject);
        DrawInventory();
>>>>>>> Stashed changes
    }

    public void UsePotion()
    {
        GameManager.ClickPlay();
        GameManager.player.GetComponent<Player>().RecoverHP((_selectedCell.item as PotionScriprableObject).recoveryHP);
        string count = _selectedCell.text.text;
        playerInventory.DeliteItem(_selectedCell.id);
        DrawInventory();
        if (count == "1")
        {
            ChangeSelectedActive(false);
        }
        else
        {
            ChangeSelectedActive(true);
        }
    }

    //Отрисовка инвентаря. Сначала очистка
    public void DrawInventory()
    {
        Player player = GameManager.player.GetComponent<Player>();

        money.text = $"{player.money}";
        ClearInventory();
        for (int i = 0; i < inventoryCellScripts.Length && i < playerInventory.inventorySlots.Count; i++)
        {
            inventoryCellScripts[i].DrawCell(playerInventory.inventorySlots[i].ItemScriptableObject, playerInventory.inventorySlots[i].count, i);
        }
<<<<<<< Updated upstream
<<<<<<< HEAD
        statText.text = $"Atc: {(swordCell.item as SwordScriptableObject).damage * player.attack}\n";
        swordCell.DrawCell(GameManager.player.GetComponent<AttackController>().sword.GetSword());
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        Player player = GameManager.player.GetComponent<Player>();
        statText.text = $"Atc: {(swordCell.item as SwordScriptableObject).damage * player.attack}\n";
=======
=======
>>>>>>> Stashed changes
        statText.text = $"Atc: {(swordCell.item as SwordScriptableObject).damage * player.attack}\n";


        swordCell.DrawCell(GameManager.player.GetComponent<AttackController>().sword.GetSword());

<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
        statText.text = $"Atc: {(swordCell.item as SwordScriptableObject).damage * player.attack}\n";
        swordCell.DrawCell(GameManager.player.GetComponent<AttackController>().sword.GetSword());
>>>>>>> Stashed changes
=======
        statText.text = $"Atc: {(swordCell.item as SwordScriptableObject).damage * player.attack}\n";
        swordCell.DrawCell(GameManager.player.GetComponent<AttackController>().sword.GetSword());
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
        statText.text = $"Atc: {(swordCell.item as SwordScriptableObject).damage * player.attack}\n";
        swordCell.DrawCell(GameManager.player.GetComponent<AttackController>().sword.GetSword());
>>>>>>> Stashed changes
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
            string text = $"{item.itemName}\n\n{item.description}\n\nBase cost: {item.cost}\nSell cost: {GetSellCost(item)}";
            if (cell.item.type=="Sword")
            {
                text += $"\nDamage: {(item as SwordScriptableObject).damage}";
            }
            else if (cell.item.type == "Potion")
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

    private int GetSellCost(ItemScriptableObject item)
    {
        return System.Convert.ToInt32(item.cost - (item.cost * (0.5 / GameManager.player.GetComponent<Player>().speech)));
    }
    public void SellItem()
    {
        if (_selectedCell != null)
        {
            bool isItemInCell = true;
            Player player = GameManager.player.GetComponent<Player>();
            if (dropItemCountSlider.value >= System.Convert.ToInt32(_selectedCell.text.text))
            {
                isItemInCell = false;
            }
            for (int i = 0; i < dropItemCountSlider.value; i++)
            {
                player.money += GetSellCost(_selectedCell.item);
                playerInventory.DeliteItem(_selectedCell.id);
            }
            DrawInventory();
            ChangeSelectedActive(isItemInCell);
        }
    }
}
