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
<<<<<<< Updated upstream:Assets/Scripts/UI/OpenSpecPanelButton.cs
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            uIScript.ExpandPanel(specsPanel.gameObject, transform.localPosition);
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
            uIScript.ExpandPanel(specsPanel.gameObject, transform.localPosition);
>>>>>>> Stashed changes:Assets/Scripts/UI/OpenButtons/OpenSpecPanelButton.cs
        }
    }
}
