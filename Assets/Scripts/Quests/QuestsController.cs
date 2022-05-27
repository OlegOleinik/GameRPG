using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsController : MonoBehaviour
{
    public List<AQuest> activeQuests = new List<AQuest>();
    public List<CompletedQuest> completedQuests = new List<CompletedQuest>();
<<<<<<< Updated upstream
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    //public AQuest[] quests;

    public delegate void OnQuestEdit();
    public OnQuestEdit onRoosterKilled;
    public OnQuestEdit onMerchantFinishQuest;
=======
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
>>>>>>> Stashed changes
    public delegate void OnQuestEdit();
    public OnQuestEdit onRoosterKilled;
    public OnQuestEdit onSkeletonKilled;
    public OnQuestEdit onPlantKilled;
    public OnQuestEdit onDefeatStartRooster;
    public OnQuestEdit onMerchantFinishQuest;
    public OnQuestEdit onFirstTalkWithPotionMerchant;
    public OnQuestEdit onFinishRoosterRevenge;
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
<<<<<<< Updated upstream
<<<<<<< HEAD
        activeQuests.Remove(quest);
        completedQuests.Add(completed);
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
       // Debug.Log(quest);
        //Debug.Log(completedQuests);


        activeQuests.Remove(quest);
        completedQuests.Add(completed);
     //   journalPanel.SetCompletedQuest(quest);
        //quest.GetReward();
=======
        activeQuests.Remove(quest);
        completedQuests.Add(completed);
>>>>>>> Stashed changes
=======
        activeQuests.Remove(quest);
        completedQuests.Add(completed);
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
        activeQuests.Remove(quest);
        completedQuests.Add(completed);
>>>>>>> Stashed changes
    }

    private bool IsQuestStarted(GameObject quest)
    {
        foreach (var item in activeQuests)
        {
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
            if (item.GetType() == quest.GetComponent<AQuest>().GetType())
            {
                return true;
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
        foreach (var item in completedQuests)
        {
            if (item.type == quest.GetComponent<AQuest>().GetType())
            {
                return true;
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
        return false;
    }

<<<<<<< Updated upstream
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    //public void OnRoosterDie()
    //{
    //    onRoosterKilled?.Invoke();
    //}
=======
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
>>>>>>> Stashed changes
    public void OnFirstTalkWithPotionMerchant()
    {
        onFirstTalkWithPotionMerchant?.Invoke();
    }
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

    public void OnMerchantFinishQuest()
    {
        onMerchantFinishQuest?.Invoke();
    }
<<<<<<< Updated upstream
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
>>>>>>> Stashed changes

    public void OnFinishRoosterRevenge()
    {
        onFinishRoosterRevenge?.Invoke();
    }
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
}
