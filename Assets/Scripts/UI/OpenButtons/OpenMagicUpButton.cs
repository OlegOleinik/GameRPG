using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenMagicUpButton : AButton
{
    public MagicUpPanel magicUpPanel;

<<<<<<< Updated upstream:Assets/Scripts/UI/OpenButtons/OpenMagicUpButton.cs
    public override void OnAction(InputAction.CallbackContext inputValue)
    {
        if (inputValue.started)
        {
            OpenClosePanel();
        }
    }


    //Проверка нажатия на клавиатуре клавиши инвентаря

    //Открытие/закрытие инвентаря
    public override void OpenClosePanel()
    {
=======
    public override void OpenClosePanel()
    {
        base.OpenClosePanel();
>>>>>>> Stashed changes:Assets/Scripts/UI/OpenMagicUpButton.cs
        UIScript uIScript = GetComponentInParent<UIScript>();
        if (GetComponentInParent<UIScript>().CheckNotOpen(magicUpPanel.gameObject))
        {
            magicUpPanel.gameObject.SetActive(true);
            magicUpPanel.DrawPanel();
            uIScript.ExpandPanel(magicUpPanel.gameObject, transform.localPosition);
        }
    }
}
