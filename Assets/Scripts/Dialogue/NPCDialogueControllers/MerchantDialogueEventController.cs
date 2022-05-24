using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantDialogueEventController : MonoBehaviour
{
    [SerializeField] private Merchant merchant;
    [SerializeField] ADialogueSentence[] branchingDialogueSentences;
    [SerializeField] GameObject kill3RoostersQuest;

    private void Start()
    {
        (branchingDialogueSentences[1] as BranchingDialogueSentence).dialogueChoises[0].onChoise += merchant.OpenShop;
        (branchingDialogueSentences[1] as BranchingDialogueSentence).dialogueChoises[0].onChoise += StartQuest3Rooster;
        (branchingDialogueSentences[0] as NarrativeDialogueSentence).onChoise += SetStartSentence;
        (branchingDialogueSentences[2] as NarrativeDialogueSentence).onChoise += GameManager.player.GetComponent<QuestsController>().OnMerchantFinishQuest;
    }

    private void SetStartSentence()
    {
        GameManager.player.GetComponent<NPCController>().SetStartSentence(merchant.nPCid, branchingDialogueSentences[1]);
    }
    private void OnDestroy()
    {
        (branchingDialogueSentences[1] as BranchingDialogueSentence).dialogueChoises[0].onChoise -= StartQuest3Rooster;
        (branchingDialogueSentences[1] as BranchingDialogueSentence).dialogueChoises[0].onChoise -= merchant.OpenShop;
        (branchingDialogueSentences[0] as NarrativeDialogueSentence).onChoise -= SetStartSentence;
        if (GameManager.player != null)
        {
            (branchingDialogueSentences[2] as NarrativeDialogueSentence).onChoise -= GameManager.player.GetComponent<QuestsController>().OnMerchantFinishQuest;

        }
    }

    private void StartQuest3Rooster()
    {
 
        GameManager.player.GetComponent<QuestsController>().AddQuest(Instantiate(kill3RoostersQuest));
    }
}
