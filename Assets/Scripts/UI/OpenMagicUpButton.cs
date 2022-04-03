using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMagicUpButton : AButton
{

    public MagicUpPanel magicUpPanel;


    //Проверка нажатия на клавиатуре клавиши инвентаря

    //Открытие/закрытие инвентаря
    public override void OpenClosePanel()
    {
        if (GetComponentInParent<UIScript>().CheckNotOpen(magicUpPanel.gameObject))
        {
            magicUpPanel.gameObject.SetActive(true);
            magicUpPanel.DrawPanel();
        }
    }
}
