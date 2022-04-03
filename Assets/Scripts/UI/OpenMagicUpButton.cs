using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMagicUpButton : AButton
{

    public MagicUpPanel magicUpPanel;


    //�������� ������� �� ���������� ������� ���������

    //��������/�������� ���������
    public override void OpenClosePanel()
    {
        if (GetComponentInParent<UIScript>().CheckNotOpen(magicUpPanel.gameObject))
        {
            magicUpPanel.gameObject.SetActive(true);
            magicUpPanel.DrawPanel();
        }
    }
}
