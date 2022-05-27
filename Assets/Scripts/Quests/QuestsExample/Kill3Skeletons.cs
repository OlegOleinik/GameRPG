using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill3Skeletons : AQuest
{
    private int skeletonCount;
    [SerializeField] private ADialogueSentence talkToComplete;
    [SerializeField] private ADialogueSentence talkNotEnough;
    [SerializeField] private ADialogueSentence shopAble;

    public override IEnumerator SetStageOnLoad(int stage)
    {
        yield return new WaitForEndOfFrame();
        switch (stage)
        {
            case 0:
                questsController.onSkeletonKilled += Stage0;
                taskDesc += GetStage0Task;
                SetStageVar(0);
                break;
            case 1:
                SetStageVar(1);
                taskDesc += GetStage1Task;
                questsController.onMerchantFinishQuest += Stage1;
                GameManager.player.GetComponent<NPCController>().SetStartSentence(0, shopAble);
                break;
            default:
                break;
        }
    }
    public void Start()
    {
        GameManager.player.GetComponent<NPCController>().SetStartSentence(1, talkNotEnough);
        questsController.onSkeletonKilled += Stage0;
        taskDesc += GetStage0Task;
    }
    private string GetStage0Task()
    {
        return $"Выполнено {skeletonCount}/3 Скелетов";
    }

    private string GetStage1Task()
    {
        return "Поговорить с торговцем оружием";
    }

    private string GetStage2Task()
    {
        return "Выполнено";
    }

    private void Stage0()
    {
        skeletonCount++;
        if(skeletonCount >= 3)
        {
            questsController.onSkeletonKilled -= Stage0;
            SetStageVar(1);
            taskDesc -= GetStage0Task;
            taskDesc += GetStage1Task;
            questsController.onMerchantFinishQuest += Stage1;
            GameManager.player.GetComponent<NPCController>().SetStartSentence(0, talkToComplete);
        }
    }

    private void Stage1()
    {
        questsController.onMerchantFinishQuest -= Stage1;
        SetStageVar(2);
        taskDesc -= GetStage1Task;
        taskDesc += GetStage2Task;
        SetQuestCompleted();
        GameManager.player.GetComponent<NPCController>().SetStartSentence(0, shopAble);
    }
}
