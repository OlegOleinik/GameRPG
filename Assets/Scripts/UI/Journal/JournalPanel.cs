using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JournalPanel : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private GameObject questList;
    [SerializeField] private GameObject journalQuestPrefab;
<<<<<<< Updated upstream
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    //[SerializeField] private GameObject completedQuestPrefab;

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

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
=======
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
>>>>>>> Stashed changes
    public void AddNewQuest()
    {
        Instantiate(journalQuestPrefab, questList.transform);
    }

    public void SetDescription(int id, bool isCompleted)
    {
        GameManager.ClickPlay();
<<<<<<< Updated upstream
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
>>>>>>> Stashed changes
    }

    public void DrawQuestPanel()
    {
        JournalQuest[] journalQuests = questList.GetComponentsInChildren<JournalQuest>();
        int count = 0;
<<<<<<< Updated upstream
<<<<<<< HEAD
        for (int i = 0; i < questsController.activeQuests.Count; i++)
        {
            journalQuests[count++].DrawActiveQuest(questsController.activeQuests[i], i);
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

        //for (int i = journalQuests.Length; i < (questsController.activeQuests.Count + questsController.completedQuests.Count); i++)
        //{
        //    Instantiate(journalQuestPrefab, questList.transform);
        //}

        for (int i = 0; i < questsController.activeQuests.Count; i++)
        {
            journalQuests[count++].DrawActiveQuest(questsController.activeQuests[i], i);

=======
        for (int i = 0; i < questsController.activeQuests.Count; i++)
        {
            journalQuests[count++].DrawActiveQuest(questsController.activeQuests[i], i);
>>>>>>> Stashed changes
=======
        for (int i = 0; i < questsController.activeQuests.Count; i++)
        {
            journalQuests[count++].DrawActiveQuest(questsController.activeQuests[i], i);
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
        for (int i = 0; i < questsController.activeQuests.Count; i++)
        {
            journalQuests[count++].DrawActiveQuest(questsController.activeQuests[i], i);
>>>>>>> Stashed changes
        }
        for (int i = 0; i < questsController.completedQuests.Count; i++)
        {
            journalQuests[count++].DrawCompletedQuest(questsController.completedQuests[i], i);
<<<<<<< Updated upstream
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
>>>>>>> Stashed changes
        }
        if (journalQuests.Length > 0)
        {
            journalQuests[0].OnClick();
        }
<<<<<<< Updated upstream
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

       // SetDescription(journalQuests[0].id)

        //foreach (var item in questsController.activeQuests)
        //{
        //}
        //foreach (var item in questsController.completedQuests)
        //{
        //    journalQuests[count++].DrawCompletedQuest(item, );
        //}

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
>>>>>>> Stashed changes
    }
}
