using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalQuest : MonoBehaviour
{
    public QuestScriptableObject quest;
    [SerializeField] Text text;
    private int id;
    bool isCompleted = false;
    public void DrawActiveQuest(AQuest quest, int newId)
    {
        text.text = quest.quest.questName;
        id = newId;
        StartCoroutine(SetSize());
    }
    public void DrawCompletedQuest(CompletedQuest quest, int newId)
    {
        text.text = quest.quest.questName;
        id = newId;
        isCompleted = true;
        StartCoroutine(SetSize());
    }

    IEnumerator SetSize()
    {
        yield return new WaitForFixedUpdate();
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(270, text.gameObject.GetComponent<RectTransform>().sizeDelta.y);
    }

    public void OnClick()
    {
        GameManager.player.GetComponent<QuestsController>().journalPanel.SetDescription(id, isCompleted);
    }
}
