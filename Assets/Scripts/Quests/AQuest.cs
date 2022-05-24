using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AQuest : MonoBehaviour
{
    public int stage;
    public QuestScriptableObject quest;
    public QuestsController questsController;
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

    [SerializeField] private int rewardEP;
    [SerializeField] private int rewardCoin;
    [SerializeField] private ItemScriptableObject[] rewardItems;


    public delegate string GetTaskDesc();
    public GetTaskDesc taskDesc;
=======
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    [SerializeField] private int rewardEP;
    [SerializeField] private int rewardCoin;
    [SerializeField] private ItemScriptableObject[] rewardItems;
    public delegate string GetTaskDesc();
    public GetTaskDesc taskDesc;

    private GameObject questObject;

<<<<<<< HEAD
=======
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        questsController = GameManager.player.GetComponent<QuestsController>();
    }

<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    private void Start()
    {
        questObject = gameObject;
    }
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    public void SetStage(int stage)
    {
        StartCoroutine(SetStageOnLoad(stage));
    }

<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
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
<<<<<<< HEAD
        GetReward();
        questsController.SetQuestCompleted(this, new CompletedQuest(this));
        Destroy(questObject);
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        
        GetReward();
        questsController.SetQuestCompleted(this, new CompletedQuest(this));
        Destroy(gameObject);
=======
        GetReward();
        questsController.SetQuestCompleted(this, new CompletedQuest(this));
        Destroy(questObject);
>>>>>>> Stashed changes
=======
        GetReward();
        questsController.SetQuestCompleted(this, new CompletedQuest(this));
        Destroy(questObject);
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    }

    public void GetReward()
    {
        Player player = GameManager.player.GetComponent<Player>();
        player.money += rewardCoin;
        player.AddExperience(rewardEP);
<<<<<<< HEAD
        foreach (var item in rewardItems)
        {
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
      //  Debug.Log(rewardItems);
        foreach (var item in rewardItems)
        {
            //Debug.Log(player.GetComponent<InventoryPanel>().dropedItem);
            //Debug.Log(item);
            //Debug.Log(player.transform.position);
            //player.GetComponent<InventoryPanel>().dropedItem.DropItem(item, player.transform.position);
=======
        foreach (var item in rewardItems)
        {
>>>>>>> Stashed changes
=======
        foreach (var item in rewardItems)
        {
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
            questsController.dropedItem.DropItem(item, player.transform.position);
        }
    }
}

<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
public class CompletedQuest
{
    public QuestScriptableObject quest;
    public System.Type type;
    public CompletedQuest(AQuest quest)
    {
        this.quest = quest.quest;
        type = quest.GetType();
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    }
}
