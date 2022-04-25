using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class OpenInventoryButton : AButton
{


    public InventoryPanel inventory;


    //�������� ������� �� ���������� ������� ���������

    //��������/�������� ���������
    public override void OpenClosePanel()
    {

        UIScript uIScript = GetComponentInParent<UIScript>();
        if (uIScript.CheckNotOpen(inventory.gameObject))
        {
            inventory.gameObject.SetActive(true);
            inventory.DrawInventory();
            uIScript.ExpandPanel(inventory.gameObject, transform.localPosition);
        }
    }

    public override void OnAction(InputAction.CallbackContext inputValue)
    {
        if (inputValue.started)
        {
            OpenClosePanel();
        }
    }
}
