using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenMagicUpButton : AButton
{

    public MagicUpPanel magicUpPanel;

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
        UIScript uIScript = GetComponentInParent<UIScript>();
        if (GetComponentInParent<UIScript>().CheckNotOpen(magicUpPanel.gameObject))
        {
            magicUpPanel.gameObject.SetActive(true);
            magicUpPanel.DrawPanel();
            uIScript.ExpandPanel(magicUpPanel.gameObject, transform.localPosition);
        }
    }
}
