using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OpenPanelButton : AButton
{


    public InventoryPanel inventory;


    //�������� ������� �� ���������� ������� ���������
    public override void CheckKeyboardPress()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            OpenCloseInventory();
        }

    }
    //��������/�������� ���������
    public void OpenCloseInventory()
    {
        if(!inventory.isActiveAndEnabled)
        {
            PauseGame();
            inventory.gameObject.SetActive(true);
            inventory.DrawInventoty();
        }
        else
        {
            ResumeGame();
            inventory.gameObject.SetActive(false);
        }
    }
}
