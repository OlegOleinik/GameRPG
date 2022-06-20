using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JournalPanel : APanel
{
    [SerializeField] private Text text;
    [SerializeField] private GameObject questList;
    [SerializeField] private GameObject journalQuestPrefab;
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
    }

    public void SetDescription(int id, bool isCompleted)
    {
        GameManager.ClickPlay();
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
    }

    public override void OpenPanel()
    {
        DrawQuestPanel();
    }
}
