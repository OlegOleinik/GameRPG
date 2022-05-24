using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class OpenSpecPanelButton : AButton
{
    public SpecsPanel specsPanel;
<<<<<<< Updated upstream:Assets/Scripts/UI/OpenButtons/OpenSpecPanelButton.cs

    public override void OnAction(InputAction.CallbackContext inputValue)
    {
        if (inputValue.started)
        {
            OpenClosePanel();
        }
    }

    public override void OpenClosePanel()
    {
=======
    public override void OpenClosePanel()
    {
        base.OpenClosePanel();
>>>>>>> Stashed changes:Assets/Scripts/UI/OpenSpecPanelButton.cs
        UIScript uIScript = GetComponentInParent<UIScript>();
        if (GetComponentInParent<UIScript>().CheckNotOpen(specsPanel.gameObject))
        {
            specsPanel.gameObject.SetActive(true);
            specsPanel.SetButtons();
            uIScript.ExpandPanel(specsPanel.gameObject, transform.localPosition);
        }
    }
}
