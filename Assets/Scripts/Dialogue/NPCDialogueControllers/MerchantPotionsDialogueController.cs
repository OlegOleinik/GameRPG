using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantPotionsDialogueController : ADialogueNPCController
{
    [SerializeField] GameObject roosterRevenge;
    private Merchant merchant;

    private void Start()
    {
        merchant = npc as Merchant;
        (dialogueSentences[0] as NarrativeDialogueSentence).onChoise += GameManager.player.GetComponent<QuestsController>().OnFirstTalkWithPotionMerchant;
        (dialogueSentences[1] as NarrativeDialogueSentence).onChoise += StartQuestRoosterRevenge;
        (dialogueSentences[2] as NarrativeDialogueSentence).onChoise += GameManager.player.GetComponent<QuestsController>().OnFinishRoosterRevenge;
        (dialogueSentences[3] as BranchingDialogueSentence).dialogueChoises[0].onChoise += merchant.OpenShop;
    }

    private void OnDestroy()
    {
        (dialogueSentences[0] as NarrativeDialogueSentence).onChoise -= GameManager.player.GetComponent<QuestsController>().OnFirstTalkWithPotionMerchant;
        (dialogueSentences[1] as NarrativeDialogueSentence).onChoise -= StartQuestRoosterRevenge;
        (dialogueSentences[2] as NarrativeDialogueSentence).onChoise -= GameManager.player.GetComponent<QuestsController>().OnFinishRoosterRevenge;
        (dialogueSentences[3] as BranchingDialogueSentence).dialogueChoises[0].onChoise -= merchant.OpenShop;
    }

    private void StartQuestRoosterRevenge()
    {
        GameManager.player.GetComponent<QuestsController>().AddQuest(Instantiate(roosterRevenge));
    }
}
