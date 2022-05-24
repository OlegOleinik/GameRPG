using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsController : MonoBehaviour
{
    public List<AQuest> activeQuests = new List<AQuest>();
    public List<CompletedQuest> completedQuests = new List<CompletedQuest>();
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
    public delegate void OnQuestEdit();
    public OnQuestEdit onRoosterKilled;
    public OnQuestEdit onSkeletonKilled;
    public OnQuestEdit onPlantKilled;
    public OnQuestEdit onDefeatStartRooster;
    public OnQuestEdit onMerchantFinishQuest;
    public OnQuestEdit onFirstTalkWithPotionMerchant;
    public OnQuestEdit onFinishRoosterRevenge;
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
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
    }

    private bool IsQuestStarted(GameObject quest)
    {
        foreach (var item in activeQuests)
        {
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
           

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
            if (item.GetType() == quest.GetComponent<AQuest>().GetType())
            {
                return true;
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
        }
        foreach (var item in completedQuests)
        {
            if (item.type == quest.GetComponent<AQuest>().GetType())
            {
                return true;
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
        }
        return false;
    }

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
    public void OnFirstTalkWithPotionMerchant()
    {
        onFirstTalkWithPotionMerchant?.Invoke();
    }
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76

    public void OnMerchantFinishQuest()
    {
        onMerchantFinishQuest?.Invoke();
    }
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76

    public void OnFinishRoosterRevenge()
    {
        onFinishRoosterRevenge?.Invoke();
    }
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
}
