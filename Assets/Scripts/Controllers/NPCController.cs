using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour/*, ISerializationCallbackReceiver*/
{
    public NPCState[] nPCs;
    DialogueController dialogueController;

    // private Dictionary<ANPC, NPCState> nPCs;

    // [SerializeField] private List<ANPC> nPC;
    // [SerializeField] private List<NPCState> States;

    //public void OnBeforeSerialize()
    //{

    //}

    //public void OnAfterDeserialize()
    //{
    //  //  nPCs = new Dictionary<ANPC, NPCState>();

    //   // for (int i = 0; i != System.Math.Min(nPC.Count, States.Count); i++)
    //     //   nPCs.Add(nPC[i], States[i]);
    //}

    private void Start()
    {
        dialogueController = GameManager.UI.GetComponentInChildren<DialogueController>();
    }


    public void StopDialog()
    {
        dialogueController.StopDialog();
    }

    public void StartDialogue(int i)
    {
        dialogueController.StartDialog(GetSentence(i));
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
}