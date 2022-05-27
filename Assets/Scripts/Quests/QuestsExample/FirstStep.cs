using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStep : AQuest
{
    [SerializeField] private ADialogueSentence firstTalk;
    [SerializeField] private ADialogueSentence startRoosterRevengeTalk;
    public void Start()
    {
        questsController.onDefeatStartRooster += Stage0;
        taskDesc += GetStage0Task;
    }
    private string GetStage0Task()
    {
        return $"Этот петух не выглядит очень сильным. Сегодня у меня будет ужин!";
    }

    private string GetStage1Task()
    {
        return $"Этот петух оказался сильнее. На обратном пути мне встретилась торговка зельями. Стоит поговорить с ней.";
    }

    private string GetStage2Task()
    {
        return $"Выполнено";
    }

    private void Stage0()
    {
        questsController.onDefeatStartRooster -= Stage0;
        SetStageVar(1);
        taskDesc -= GetStage0Task;
        taskDesc += GetStage1Task;
        questsController.onFirstTalkWithPotionMerchant += Stage1;
        GameManager.player.GetComponent<NPCController>().SetStartSentence(13, firstTalk);
    }

    private void Stage1()
    {
        questsController.onFirstTalkWithPotionMerchant -= Stage1;
        SetStageVar(2);
        taskDesc -= GetStage1Task;
        taskDesc += GetStage2Task;
        SetQuestCompleted();
        GameManager.player.GetComponent<NPCController>().SetStartSentence(13, startRoosterRevengeTalk);
    }

    public override IEnumerator SetStageOnLoad(int stage)
    {
        yield return new WaitForEndOfFrame();
        switch (stage)
        {
            case 0:
                questsController.onDefeatStartRooster += Stage0;
                taskDesc += GetStage0Task;
                SetStageVar(0);
                break;
            case 1:
                SetStageVar(1);
                taskDesc += GetStage1Task;
                questsController.onFirstTalkWithPotionMerchant += Stage1;
                break;
            default:
                break;
        }
    }
}
