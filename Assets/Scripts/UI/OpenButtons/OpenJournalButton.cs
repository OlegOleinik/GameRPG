using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenJournalButton : AButton
{
<<<<<<< Updated upstream

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
=======
    public JournalPanel journal;

    public override void OpenClosePanel()
    {
        base.OpenClosePanel();
>>>>>>> Stashed changes
        UIScript uIScript = GetComponentInParent<UIScript>();
        if (uIScript.CheckNotOpen(journal.gameObject))
        {
            journal.gameObject.SetActive(true);
            journal.DrawQuestPanel();
            uIScript.ExpandPanel(journal.gameObject, transform.localPosition);
        }
    }
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
}
