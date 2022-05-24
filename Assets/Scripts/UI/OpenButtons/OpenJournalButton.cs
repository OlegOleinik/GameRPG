using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenJournalButton : AButton
{
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
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
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    public JournalPanel journal;

    public override void OpenClosePanel()
    {
        base.OpenClosePanel();
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
        UIScript uIScript = GetComponentInParent<UIScript>();
        if (uIScript.CheckNotOpen(journal.gameObject))
        {
            journal.gameObject.SetActive(true);
            journal.DrawQuestPanel();
            uIScript.ExpandPanel(journal.gameObject, transform.localPosition);
        }
    }
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
}
