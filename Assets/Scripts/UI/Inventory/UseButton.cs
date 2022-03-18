using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseButton : MonoBehaviour
{
    [SerializeField] private InventoryPanel InventoryPanel;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().interactable = false;
    }

    public void ChangeActive(InventoryCellScript newSelectedCell)
    {
        if (newSelectedCell == null)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else if (newSelectedCell.item.type=="Sword" || newSelectedCell.item.type == "Potion")
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public void OnClick()
    {
        string type = InventoryPanel.GetSelectedCellType();
        if (type == "Sword")
        {
            InventoryPanel.SetSword();
        }
        else if(type == "Potion")
        {
            InventoryPanel.UsePotion();
        }
    }
}
