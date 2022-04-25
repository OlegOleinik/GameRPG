using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenJournalButton : AButton
{

    public JournalPanel journal;

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
        if (uIScript.CheckNotOpen(journal.gameObject))
        {
            journal.gameObject.SetActive(true);
            journal.DrawQuestPanel();
            uIScript.ExpandPanel(journal.gameObject, transform.localPosition);
        }
    }

}
