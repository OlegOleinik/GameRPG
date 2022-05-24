using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenMagicUpButton : AButton
{
    public MagicUpPanel magicUpPanel;

    public override void OpenClosePanel()
    {
        base.OpenClosePanel();
        UIScript uIScript = GetComponentInParent<UIScript>();
        if (GetComponentInParent<UIScript>().CheckNotOpen(magicUpPanel.gameObject))
        {
            magicUpPanel.gameObject.SetActive(true);
            magicUpPanel.DrawPanel();
            uIScript.ExpandPanel(magicUpPanel.gameObject, transform.localPosition);
        }
    }
}
