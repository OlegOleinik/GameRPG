using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantWeaponDialogueController : ADialogueNPCController
{
    [SerializeField] GameObject killSkeletonsQuest;
    private Merchant merchant;

    private void Start()
    {
        merchant = npc as Merchant;
        (dialogueSentences[0] as BranchingDialogueSentence).dialogueChoises[0].onChoise += StartQuest3Skeletons;
        (dialogueSentences[1] as NarrativeDialogueSentence).onChoise += GameManager.player.GetComponent<QuestsController>().OnMerchantFinishQuest;
        (dialogueSentences[2] as BranchingDialogueSentence).dialogueChoises[0].onChoise += merchant.OpenShop;
        (dialogueSentences[3] as BranchingDialogueSentence).dialogueChoises[0].onChoise += StartQuest3Skeletons;
        (dialogueSentences[4] as NarrativeDialogueSentence).onChoise += SetStartSentence;
    }

    private void SetStartSentence()
    {
        GameManager.player.GetComponent<NPCController>().SetStartSentence(merchant.nPCid, dialogueSentences[3]);
    }

    private void OnDestroy()
    {
        (dialogueSentences[0] as BranchingDialogueSentence).dialogueChoises[0].onChoise -= StartQuest3Skeletons;
        (dialogueSentences[1] as NarrativeDialogueSentence).onChoise -= GameManager.player.GetComponent<QuestsController>().OnMerchantFinishQuest;
        (dialogueSentences[2] as BranchingDialogueSentence).dialogueChoises[0].onChoise -= merchant.OpenShop;
        (dialogueSentences[3] as BranchingDialogueSentence).dialogueChoises[0].onChoise -= StartQuest3Skeletons;
        (dialogueSentences[4] as NarrativeDialogueSentence).onChoise -= SetStartSentence;
    }

    private void StartQuest3Skeletons()
    {
        GameManager.player.GetComponent<QuestsController>().AddQuest(Instantiate(killSkeletonsQuest));
    }
}
