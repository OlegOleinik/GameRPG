using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsController : MonoBehaviour
{
    public List<AQuest> activeQuests = new List<AQuest>();
    public List<CompletedQuest> completedQuests = new List<CompletedQuest>();
    public delegate void OnQuestEdit();
    public OnQuestEdit onRoosterKilled;
    public OnQuestEdit onSkeletonKilled;
    public OnQuestEdit onPlantKilled;
    public OnQuestEdit onDefeatStartRooster;
    public OnQuestEdit onMerchantFinishQuest;
    public OnQuestEdit onFirstTalkWithPotionMerchant;
    public OnQuestEdit onFinishRoosterRevenge;
    public DropedItem dropedItem;
    public JournalPanel journalPanel;

    private void Start()
    {
        journalPanel = GameManager.UI.GetComponentInChildren<JournalPanel>();
    }
    public void AddQuest(GameObject newQuest)
    {
        //Да, объект создается, а если не нужен, то уничтожается. Это просто защита. В игре такого возникать не должно
        if (!IsQuestStarted(newQuest))
        {
            AQuest quest = newQuest.GetComponent<AQuest>();
            activeQuests.Add(quest);
            journalPanel.AddNewQuest();
            return;
        }
        Destroy(newQuest);
    }

    public void ClearPanel()
    {
        journalPanel.ClearPanel();
    }

    public void AddCompletedQuest(CompletedQuest newCompletedQuest)
    {
           
            completedQuests.Add(newCompletedQuest);
            journalPanel.AddNewQuest();
            return;
    }

    public void SetQuestCompleted(AQuest quest, CompletedQuest completed)
    {
        activeQuests.Remove(quest);
        completedQuests.Add(completed);
    }

    private bool IsQuestStarted(GameObject quest)
    {
        foreach (var item in activeQuests)
        {
            if (item.GetType() == quest.GetComponent<AQuest>().GetType())
            {
                return true;
            }
        }
        foreach (var item in completedQuests)
        {
            if (item.type == quest.GetComponent<AQuest>().GetType())
            {
                return true;
            }
        }
        return false;
    }

    public void OnFirstTalkWithPotionMerchant()
    {
        onFirstTalkWithPotionMerchant?.Invoke();
    }

    public void OnMerchantFinishQuest()
    {
        onMerchantFinishQuest?.Invoke();
    }

    public void OnFinishRoosterRevenge()
    {
        onFinishRoosterRevenge?.Invoke();
    }
}
