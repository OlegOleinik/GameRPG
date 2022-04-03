using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OpenSpecPanelButton : AButton
{


    public SpecsPanel specsPanel;

    public override void OpenClosePanel()
    {
        if (GetComponentInParent<UIScript>().CheckNotOpen(specsPanel.gameObject))
        {
            specsPanel.gameObject.SetActive(true);
            specsPanel.SetText();
        }
    }
}
