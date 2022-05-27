using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AQuest : MonoBehaviour
{
    public int stage;
    public QuestScriptableObject quest;
    public QuestsController questsController;
    [SerializeField] private int rewardEP;
    [SerializeField] private int rewardCoin;
    [SerializeField] private ItemScriptableObject[] rewardItems;
    public delegate string GetTaskDesc();
    public GetTaskDesc taskDesc;

    private GameObject questObject;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        questsController = GameManager.player.GetComponent<QuestsController>();
    }

    private void Start()
    {
        questObject = gameObject;
    }
    public void SetStage(int stage)
    {
        StartCoroutine(SetStageOnLoad(stage));
    }

    public abstract IEnumerator SetStageOnLoad(int stage);
    public string GetDescription()
    {
        return quest.stagesDescription[stage];
    }
    public string GetQuestName()
    {
        return quest.questName;
    }
    public string GetTask()
    {
        return taskDesc?.Invoke();
    }
    public void SetStageVar(int newStage)
    {
        if (newStage < quest.stagesDescription.Length)
        {
            stage = newStage;
        }
    }

    public void SetQuestCompleted()
    {
        GetReward();
        questsController.SetQuestCompleted(this, new CompletedQuest(this));
        Destroy(questObject);
    }

    public void GetReward()
    {
        Player player = GameManager.player.GetComponent<Player>();
        player.money += rewardCoin;
        player.AddExperience(rewardEP);
        foreach (var item in rewardItems)
        {
            questsController.dropedItem.DropItem(item, player.transform.position);
        }
    }
}

public class CompletedQuest
{
    public QuestScriptableObject quest;
    public System.Type type;
    public CompletedQuest(AQuest quest)
    {
        this.quest = quest.quest;
        type = quest.GetType();
    }
}
