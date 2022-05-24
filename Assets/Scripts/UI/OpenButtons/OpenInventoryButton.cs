using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class OpenInventoryButton : AButton
{
    public InventoryPanel inventory;

    //Открытие/закрытие инвентаря
    public override void OpenClosePanel()
    {
        base.OpenClosePanel();
        UIScript uIScript = GetComponentInParent<UIScript>();
        if (uIScript.CheckNotOpen(inventory.gameObject))
        {
            inventory.gameObject.SetActive(true);
            inventory.DrawInventory();
            uIScript.ExpandPanel(inventory.gameObject, transform.localPosition);
        }
    }
}
