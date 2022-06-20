using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoosterRevenge : AQuest
{
    [SerializeField] private ADialogueSentence talkToComplete;
    [SerializeField] private ADialogueSentence talkNotEnough;
    [SerializeField] private ADialogueSentence shopAble;
    private Inventory inventory;
    private int currentCount = 0;

    public void Start()
    {
        inventory = GameManager.player.GetComponent<Inventory>();
        inventory.onItemChange += CheckFeathers;
        CheckFeathers();
    }

    private void CheckFeathers()
    {
        currentCount = 0;
        foreach (var item in inventory.inventorySlots)
        {

            if (item.ItemScriptableObject.itemName == "Перо")
            {
                currentCount += item.count;
            }
        }
        if (currentCount >= 3)
        {
            SetStageVar(1);
            taskDesc -= GetStage0Task;
            taskDesc += GetStage1Task;
            questsController.onFinishRoosterRevenge += Stage1;
            GameManager.player.GetComponent<NPCController>().SetStartSentence(13, talkToComplete);
            return;
        }
        else
        {
            SetStageVar(0);
            taskDesc -= GetStage1Task;
            taskDesc += GetStage0Task;
            questsController.onFinishRoosterRevenge -= Stage1;
            GameManager.player.GetComponent<NPCController>().SetStartSentence(13, talkNotEnough);
            return;
        }
    }

    private void Stage1()
    {
        inventory.onItemChange -= CheckFeathers;
        questsController.onFinishRoosterRevenge -= Stage1;
        int deletedCount = 0;
        for (int i = 0; i < inventory.inventorySlots.Count; i++)
        {
            if (inventory.inventorySlots[i].ItemScriptableObject.itemName == "Перо")
            {
                if (inventory.inventorySlots[i].count >= 3)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        inventory.DeliteItem(i);
                    }
                }
                else
                {
                    for (int j = 0; j < inventory.inventorySlots[i].count && deletedCount < 3; j++)
                    {
                        inventory.DeliteItem(i);
                        deletedCount++;
                    }
                }
            }
        }
        SetStageVar(2);
        taskDesc -= GetStage1Task;
        taskDesc += GetStage2Task;
        SetQuestCompleted();
        GameManager.player.GetComponent<NPCController>().SetStartSentence(13, shopAble);
    }

    private string GetStage0Task()
    {
        return $"Собрано {currentCount}/3 перьев петуха.\nНужно продолжать работу.";
    }

    private string GetStage1Task()
    {
        return $"Собрано {currentCount}/3 перьев петуха.\nВремя возвращаться назад.";
    }

    private string GetStage2Task()
    {
        return $"Выполнено";
    }
    public override IEnumerator SetStageOnLoad(int stage)
    {
        yield return new WaitForEndOfFrame();
        CheckFeathers();
    }
}
