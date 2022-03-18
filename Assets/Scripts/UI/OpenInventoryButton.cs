using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OpenInventoryButton : AButton
{


    public InventoryPanel inventory;


    //Проверка нажатия на клавиатуре клавиши инвентаря

    //Открытие/закрытие инвентаря
    public override void OpenClosePanel()
    {
        if (GetComponentInParent<UIScript>().CheckNotOpen(inventory.gameObject))
        {
            inventory.gameObject.SetActive(true);
            inventory.DrawInventory();
        }
    }
}
