using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalQuest : MonoBehaviour
{
    // DialogueChoise dialogueChoise;
    public QuestScriptableObject quest;
    [SerializeField] Text text;
    private int id;
    bool isCompleted = false;
    public void DrawActiveQuest(AQuest quest, int newId)
    {
        text.text = quest.quest.questName;
        id = newId;
        StartCoroutine(SetSize());
        //text.text = dialogueChoise.answer;
        //this.dialogueChoise = dialogueChoise;
        //// Debug.Log(text.gameObject.GetComponent<RectTransform>().sizeDelta);
        //StartCoroutine(SetSize());
    }
    public void DrawCompletedQuest(CompletedQuest quest, int newId)
    {
        text.text = quest.quest.questName;
        id = newId;
        isCompleted = true;
        StartCoroutine(SetSize());
        //text.text = dialogueChoise.answer;
        //this.dialogueChoise = dialogueChoise;
        //// Debug.Log(text.gameObject.GetComponent<RectTransform>().sizeDelta);
        //StartCoroutine(SetSize());
    }

    IEnumerator SetSize()
    {
        // We should only read the screen buffer after rendering is complete
        //Debug.Log(text.gameObject.GetComponent<RectTransform>().sizeDelta.y);
        yield return new WaitForFixedUpdate();
       // Debug.Log(text.gameObject.GetComponent<RectTransform>().sizeDelta.y);

        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(270, text.gameObject.GetComponent<RectTransform>().sizeDelta.y);
    }

    //public void SetCompleted()
    //{
    //    GetComponent<Image>().color = Color.red;
    //}

    public void OnClick()
    {
        GameManager.player.GetComponent<QuestsController>().journalPanel.SetDescription(id, isCompleted);
    }
    //IEnumerator SetSize()
    //{
    //    // We should only read the screen buffer after rendering is complete
    //    yield return new WaitForEndOfFrame();
    //    gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(text.gameObject.GetComponent<RectTransform>().sizeDelta.x + 20, 30);
    //}

    //public void OnClick()
    //{

    //}
}
