using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenJournalButton : AButton
{
    public JournalPanel journal;

    public override void OpenClosePanel()
    {
        base.OpenClosePanel();
        UIScript uIScript = GetComponentInParent<UIScript>();
        if (uIScript.CheckNotOpen(journal.gameObject))
        {
            journal.gameObject.SetActive(true);
            journal.DrawQuestPanel();
            uIScript.ExpandPanel(journal.gameObject, transform.localPosition);
        }
    }
}
