using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OpenInventoryButton : AButton
{


    public InventoryPanel inventory;


    //�������� ������� �� ���������� ������� ���������

    //��������/�������� ���������
    public override void OpenClosePanel()
    {
        if (GetComponentInParent<UIScript>().CheckNotOpen(inventory.gameObject))
        {
            inventory.gameObject.SetActive(true);
            inventory.DrawInventory();
        }
    }
}
