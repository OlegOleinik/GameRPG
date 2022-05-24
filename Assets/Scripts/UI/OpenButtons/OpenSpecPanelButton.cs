using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class OpenSpecPanelButton : AButton
{
    public SpecsPanel specsPanel;
    public override void OpenClosePanel()
    {
        base.OpenClosePanel();
        UIScript uIScript = GetComponentInParent<UIScript>();
        if (GetComponentInParent<UIScript>().CheckNotOpen(specsPanel.gameObject))
        {
            specsPanel.gameObject.SetActive(true);
            specsPanel.SetButtons();
            uIScript.ExpandPanel(specsPanel.gameObject, transform.localPosition);
        }
    }
}
