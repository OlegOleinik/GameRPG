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
    //private List<OnSaleItem> onSaleItems;
    private void Start()
    {
        shopCells = GetComponentsInChildren<ShopCell>();
        gameObject.SetActive(false);
    }


    public void SetDescription(AItemCell cell)
    {
        if (cell.item != null)
        {
            ItemScriptableObject item = cell.item;
            string text = $"{item.itemName}\n\n{item.description}\n\nCost: {item.cost + (item.cost * (0.5 / GameManager.player.GetComponent<Player>().speech))}";
            if (cell.item.type == "Sword")
            {
                text += $"\nDamage: {(item as SwordScriptableObject).damage}";
            }
            description.SetDescription(text);
        }

    }
    //”брать описание, когда курсор покадает €чейку инвентар€
    public void ClearDescription()
    {
        description.ClearDescription();
    }



    public void OpenShop(Merchant merchant)
    {
        this.merchant = merchant;
        //this.onSaleItems = onSaleItems;
        //inventoryPanel.gameObject.SetActive(true);
        //merchantPanel.SetActive(false);

        ChangeActive(false);
        inventoryPanel.DrawInventory();
        //openInventoryButton.interactable = false;
        //openShopButton.interactable = true;
        //buyButton.SetActive(false);
        //sellButton.SetActive(true);
    }


    public void ClickSellButton()
    {
        merchant.AddItem(inventoryPanel.selectedCell.item);
        inventoryPanel.SellItem();
        //Debug.Log(merchant);
        //Debug.Log(selectedCell.item);
        
    }


    public void ClickBuyButton()
    {
  
        Player player = GameManager.player.GetComponent<Player>();
        int cost = System.Convert.ToInt32(selectedCell.item.cost + (selectedCell.item.cost * (0.5 / player.speech)));
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
        if (selectedCell != null)
        {
            ClearSelected();
        }
        selectedCell = newSelectedCell;
        selectedCell.selected = true;
        selectedCell.SetColor();
    }

    //ќчистка клетки от выделени€
    public void ClearSelected()
    {
        selectedCell.ClearColor();
        selectedCell.selected = false;
        selectedCell = null;
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

        ChangeActive(false);

        inventoryPanel.DrawInventory();

    }

    public void OpenMerchantInventory()
    {

        ChangeActive(true);

        ClearShop();
        money.text = $"{GameManager.player.GetComponent<Player>().money}";
        for (int i=0; i< merchant.onSaleItems.Count && i< shopCells.Length-1; i++)
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



