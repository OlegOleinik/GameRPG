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
<<<<<<< Updated upstream:Assets/Scripts/UI/OpenButtons/OpenInventoryButton.cs

=======
        base.OpenClosePanel();
>>>>>>> Stashed changes:Assets/Scripts/UI/OpenInventoryButton.cs
        UIScript uIScript = GetComponentInParent<UIScript>();
        if (uIScript.CheckNotOpen(inventory.gameObject))
        {
            inventory.gameObject.SetActive(true);
            inventory.DrawInventory();
            uIScript.ExpandPanel(inventory.gameObject, transform.localPosition);
<<<<<<< Updated upstream:Assets/Scripts/UI/OpenButtons/OpenInventoryButton.cs
        }
    }

    public override void OnAction(InputAction.CallbackContext inputValue)
    {
        if (inputValue.started)
        {
            OpenClosePanel();
=======
>>>>>>> Stashed changes:Assets/Scripts/UI/OpenInventoryButton.cs
        }
    }
}
