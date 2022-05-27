using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public NPCState[] nPCs;
    public DialogueController dialogueController;

    private void Start()
    {
        dialogueController = GameManager.UI.GetComponentInChildren<DialogueController>();
    }

    public void StopDialog()
    {
        dialogueController.StopDialog();
    }

    public void StartDialogue(int i, Sprite interlocutorSprite)
    {
        dialogueController.StartDialog(GetSentence(i), interlocutorSprite);
    }

    public void SetStartSentence(int i, ADialogueSentence sentence)
    {
        nPCs[i].startDialogueSentence = sentence;
    }

    public ADialogueSentence GetSentence(int i)
    {
        return nPCs[i].startDialogueSentence;
    }
}
[System.Serializable]
public class NPCState
{
    public bool isDead;
    public ADialogueSentence startDialogueSentence;
    [SerializeField] private ADialogueSentence defaultDialogueSentence;

    public void SetDefault()
    {
        isDead = false;
        startDialogueSentence = defaultDialogueSentence;
    }
}