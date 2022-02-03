using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class InventoryButton : AButton
{


    public InventoryPanel inventory;
    private bool isInventoryOpen = false;

    private void Update()
    {
        CheckKeyboardPress();
    }
    public override void CheckKeyboardPress()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            OpenCloseInventory();
        }

    }
    public void OpenCloseInventory()
    {
        if(!isInventoryOpen)
        {
            PauseGame();
            inventory.gameObject.SetActive(true);
            inventory.DrawInventoty();
            isInventoryOpen = true;
        }
        else
        {
            ResumeGame();
            inventory.gameObject.SetActive(false);
            isInventoryOpen = false;
        }
    }
}
