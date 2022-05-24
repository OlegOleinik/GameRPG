using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill3Roosters : AQuest
{
    private int roosterCount;
    [SerializeField] private ADialogueSentence completedQuestSentence;
    [SerializeField] private ADialogueSentence baseQuestSentence;



    public override IEnumerator SetStageOnLoad(int stage)
    {
        yield return new WaitForEndOfFrame();
        switch (stage)
        {
            case 0:
                questsController.onRoosterKilled += Stage0;
                taskDesc += GetStage0Task;
                SetStageVar(0);
                break;
            case 1:
                SetStageVar(1);
                taskDesc += GetStage1Task;
                questsController.onMerchantFinishQuest += Stage1;
                GameManager.player.GetComponent<NPCController>().SetStartSentence(0, completedQuestSentence);
                break;
            default:
                break;
        }
    }


    //public override void SetStage(int stage)
    //{
    //    throw new System.NotImplementedException();
    //}

    //public override string GetTask()
    //{
    //    //switch (stage)
    //    //{
    //    //    case 0:
    //    //        break;
    //    //    case 1:
    //    //        break;
    //    //    default:
    //    //        break;
    //    //}
    //}

    public void Start()
    {
        questsController.onRoosterKilled += Stage0;
        taskDesc += GetStage0Task;
    }

    private string GetStage0Task()
    {
        return $"Completed {roosterCount}/3 roosters";
    }

    private string GetStage1Task()
    {
        return "Talk with merchant";
    }

    private string GetStage2Task()
    {
        return "Task completed!";
    }



    private void Stage0()
    {
        roosterCount++;
        if(roosterCount >= 3)
        {
            questsController.onRoosterKilled -= Stage0;
            SetStageVar(1);
            taskDesc -= GetStage0Task;
            taskDesc += GetStage1Task;
            questsController.onMerchantFinishQuest += Stage1;
            GameManager.player.GetComponent<NPCController>().SetStartSentence(0, completedQuestSentence);
        }
    }

    private void Stage1()
    {
        questsController.onMerchantFinishQuest -= Stage1;
        SetStageVar(2);
        taskDesc -= GetStage1Task;
        taskDesc += GetStage2Task;
        // questsController.SetQuestCompleted(this);
        SetQuestCompleted();
        GameManager.player.GetComponent<NPCController>().SetStartSentence(0, baseQuestSentence);
    }
}
