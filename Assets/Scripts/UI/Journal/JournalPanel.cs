using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JournalPanel : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private GameObject questList;
    [SerializeField] private GameObject journalQuestPrefab;
    //[SerializeField] private GameObject completedQuestPrefab;

    private QuestsController questsController;

    private void Start()
    {
        questsController = GameManager.player.GetComponent<QuestsController>();

    }

    public void ClearPanel()
    {
        foreach (var item in questList.GetComponentsInChildren<JournalQuest>())
        {
            Destroy(item.gameObject);
        }
        text.text = "No active quests";
    }


    public void AddNewQuest()
    {
        Instantiate(journalQuestPrefab, questList.transform);
        //newJournalQuest.SetQuest(quest);
    }

    ////public void AddJournalQuest(AQuest quest)
    ////{
    ////    //JournalQuest newJournalQuest = Instantiate(journalQuestPrefab, questList.transform).GetComponent<JournalQuest>();
    ////   // string questDescription = $"{quest.quest.questName}\n\n{quest.quest.stagesDescription[quest.stage]}";

    ////   // newJournalQuest.SetQuest(quest);
    ////}

    //public void SetCompletedQuest(AQuest quest)
    //{
    //    foreach (var item in questList.GetComponentsInChildren<JournalQuest>())
    //    {
    //        if (item.quest == quest.quest)
    //        {
    //            item.SetCompleted();
    //            return;
    //        }
    //    }
    //}


    public void SetDescription(int id, bool isCompleted)
    {
        if (isCompleted)
        {
            CompletedQuest completedQuest = questsController.completedQuests[id];
            text.text = $"{completedQuest.quest.questName}\n\n{completedQuest.quest.stagesDescription[completedQuest.quest.stagesDescription.Length-1]}\n\n";
        }
        else
        {
            AQuest quest = questsController.activeQuests[id];
            text.text = $"{quest.GetQuestName()}\n\n{quest.GetDescription()}\n\n{quest.GetTask()}";
        }

    }

    public void DrawQuestPanel()
    {
        JournalQuest[] journalQuests = questList.GetComponentsInChildren<JournalQuest>();
        int count = 0;

        //for (int i = journalQuests.Length; i < (questsController.activeQuests.Count + questsController.completedQuests.Count); i++)
        //{
        //    Instantiate(journalQuestPrefab, questList.transform);
        //}

        for (int i = 0; i < questsController.activeQuests.Count; i++)
        {
            journalQuests[count++].DrawActiveQuest(questsController.activeQuests[i], i);

        }
        for (int i = 0; i < questsController.completedQuests.Count; i++)
        {
            journalQuests[count++].DrawCompletedQuest(questsController.completedQuests[i], i);

        }
        if (journalQuests.Length > 0)
        {
            journalQuests[0].OnClick();
        }

       // SetDescription(journalQuests[0].id)

        //foreach (var item in questsController.activeQuests)
        //{
        //}
        //foreach (var item in questsController.completedQuests)
        //{
        //    journalQuests[count++].DrawCompletedQuest(item, );
        //}

    }
}
