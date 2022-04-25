using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class OpenSpecPanelButton : AButton
{


    public SpecsPanel specsPanel;

    public override void OnAction(InputAction.CallbackContext inputValue)
    {
        if (inputValue.started)
        {
            OpenClosePanel();
        }
    }

    public override void OpenClosePanel()
    {
        UIScript uIScript = GetComponentInParent<UIScript>();
        if (GetComponentInParent<UIScript>().CheckNotOpen(specsPanel.gameObject))
        {
            specsPanel.gameObject.SetActive(true);
            specsPanel.SetButtons();
            uIScript.ExpandPanel(specsPanel.gameObject, transform.localPosition);
        }
    }
}
