using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopController : MonoBehaviour
{
    [SerializeField] GameObject merchantPanel;
    [SerializeField] InventoryPanel inventoryPanel;
    [SerializeField] Button openInventoryButton;
    [SerializeField] Button openShopButton;
    [SerializeField] GameObject sellButton;
    [SerializeField] GameObject buyButton;
    [SerializeField] private Text money;
    public ItemDescription description;
    private ShopCell selectedCell;
    private Merchant merchant;
    private ShopCell[] shopCells;
<<<<<<< Updated upstream
<<<<<<< HEAD

    private void Awake()
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    private void Awake()
=======
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
    private void Start()
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
    private void Awake()
>>>>>>> Stashed changes
=======
    private void Awake()
>>>>>>> Stashed changes
=======

    private void Awake()
>>>>>>> Stashed changes
=======

    private void Awake()
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======

    private void Awake()
>>>>>>> Stashed changes
    {
        shopCells = GetComponentsInChildren<ShopCell>();
        inventoryPanel.onChangeSelected += SetSellButtonActive;
        gameObject.SetActive(false);
        inventoryPanel.onChangeSelected += SetSellButtonActive;
    }

    private void SetSellButtonActive()
    {
        if (inventoryPanel.selectedCell != null)
        {
            sellButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            sellButton.GetComponent<Button>().interactable = false;
        }
<<<<<<< HEAD
=======
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    }

    private void SetSellButtonActive()
    {
        if (inventoryPanel.selectedCell != null)
        {
            sellButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            sellButton.GetComponent<Button>().interactable = false;
        }
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
    }

    private void SetSellButtonActive()
    {
        if (inventoryPanel.selectedCell != null)
        {
            sellButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            sellButton.GetComponent<Button>().interactable = false;
        }
    }

    private void SetSellButtonActive()
    {
        if (inventoryPanel.selectedCell != null)
        {
            sellButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            sellButton.GetComponent<Button>().interactable = false;
        }
    }

    private void SetSellButtonActive()
    {
        if (inventoryPanel.selectedCell != null)
        {
            sellButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            sellButton.GetComponent<Button>().interactable = false;
        }
<<<<<<< Updated upstream
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
>>>>>>> Stashed changes
    }

    public void SetDescription(AItemCell cell)
    {
        if (cell.item != null)
        {
            ItemScriptableObject item = cell.item;
            string text = $"{item.itemName}\n\n{item.description}\n\nBase cost: {item.cost}\nBuy cost: {GetBuyCost(item)}";
            if (cell.item.type == "Sword")
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
<<<<<<< Updated upstream
<<<<<<< HEAD

=======
<<<<<<< Updated upstream

<<<<<<< Updated upstream



    }

=======
>>>>>>> Stashed changes
=======

>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======

>>>>>>> Stashed changes
    private int GetBuyCost(ItemScriptableObject item)
    {
        return System.Convert.ToInt32(item.cost + (item.cost * (0.5 / GameManager.player.GetComponent<Player>().speech)));
    }
    //”брать описание, когда курсор покадает €чейку инвентар€
    public void ClearDescription()
    {
        description.ClearDescription();
    }

    public void OpenShop(Merchant merchant)
    {
        this.merchant = merchant;
        ChangeActive(false);
        inventoryPanel.DrawInventory();
    }

    public void ClickSellButton()
    {
<<<<<<< Updated upstream
<<<<<<< HEAD
        GameManager.ClickPlay();
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        if (inventoryPanel.selectedCell != null)
        {
            merchant.AddItem(inventoryPanel.selectedCell.item);
            inventoryPanel.SellItem();
        }

        
    }
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

        if (inventoryPanel.selectedCell != null)
        {
            merchant.AddItem(inventoryPanel.selectedCell.item);
            inventoryPanel.SellItem();
        }
    }

    public void ClickBuyButton()
    {
        GameManager.ClickPlay();
        Player player = GameManager.player.GetComponent<Player>();
        int cost = GetBuyCost(selectedCell.item);
        if ((selectedCell != null) && (player.money >= cost && (GameManager.player.GetComponent<Inventory>().AddItem(selectedCell.item))))
        {
            player.money -= cost;
            if (merchant.RemoveItem(selectedCell.id))
            {
                ClearSelected();
            }
            OpenMerchantInventory();
        }
    }

    public void ChangeSelected(ShopCell newSelectedCell)
    {
        ClearSelected();
        if (newSelectedCell.item != null)
        {
            buyButton.GetComponent<Button>().interactable = true;
            selectedCell = newSelectedCell;
            selectedCell.selected = true;
            selectedCell.GetComponent<Image>().color = new Color(0.59f, 0.29f, 0.29f, 0.9f);
        }
<<<<<<< Updated upstream
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
>>>>>>> Stashed changes
    }

    //ќчистка клетки от выделени€
    public void ClearSelected()
    {
        if (selectedCell != null)
        {
            selectedCell.SetDefaultColor();
            selectedCell.selected = false;
            selectedCell = null;
            buyButton.GetComponent<Button>().interactable = false;
        }
<<<<<<< Updated upstream
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
>>>>>>> Stashed changes
    }

    private void ChangeActive(bool isActive)
    {
        merchantPanel.SetActive(isActive);
        inventoryPanel.gameObject.SetActive(!isActive);
        openInventoryButton.interactable = isActive;
        openShopButton.interactable = !isActive;
        buyButton.SetActive(isActive);
        sellButton.SetActive(!isActive);
    }

    public void OpenPlayerInventory()
    {
        GameManager.ClickPlay();
        ChangeActive(false);
        inventoryPanel.DrawInventory();
    }

    public void OpenMerchantInventory()
    {
        GameManager.ClickPlay();
        ChangeActive(true);
        ClearShop();
        money.text = $"{GameManager.player.GetComponent<Player>().money}";
        for (int i=0; i< Mathf.Min(merchant.onSaleItems.Count, shopCells.Length-1); i++)
        {
            shopCells[i].DrawCell(merchant.onSaleItems[i].item, merchant.onSaleItems[i].count, i);
        }
    }

    private void ClearShop()
    {
        foreach (var item in shopCells)
        {
            item.OnMouseExit();
            item.ClearCell();
        }
        ClearDescription();
    }
}



