using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalQuest : MonoBehaviour
{
<<<<<<< Updated upstream
    // DialogueChoise dialogueChoise;
=======
>>>>>>> Stashed changes
    public QuestScriptableObject quest;
    [SerializeField] Text text;
    private int id;
    bool isCompleted = false;
    public void DrawActiveQuest(AQuest quest, int newId)
    {
        text.text = quest.quest.questName;
        id = newId;
        StartCoroutine(SetSize());
<<<<<<< Updated upstream
        //text.text = dialogueChoise.answer;
        //this.dialogueChoise = dialogueChoise;
        //// Debug.Log(text.gameObject.GetComponent<RectTransform>().sizeDelta);
        //StartCoroutine(SetSize());
=======
>>>>>>> Stashed changes
    }
    public void DrawCompletedQuest(CompletedQuest quest, int newId)
    {
        text.text = quest.quest.questName;
        id = newId;
        isCompleted = true;
        StartCoroutine(SetSize());
<<<<<<< Updated upstream
        //text.text = dialogueChoise.answer;
        //this.dialogueChoise = dialogueChoise;
        //// Debug.Log(text.gameObject.GetComponent<RectTransform>().sizeDelta);
        //StartCoroutine(SetSize());
=======
>>>>>>> Stashed changes
    }

    IEnumerator SetSize()
    {
<<<<<<< Updated upstream
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

=======
        yield return new WaitForFixedUpdate();
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(270, text.gameObject.GetComponent<RectTransform>().sizeDelta.y);
    }

>>>>>>> Stashed changes
    public void OnClick()
    {
        GameManager.player.GetComponent<QuestsController>().journalPanel.SetDescription(id, isCompleted);
    }
<<<<<<< Updated upstream
    //IEnumerator SetSize()
    //{
    //    // We should only read the screen buffer after rendering is complete
    //    yield return new WaitForEndOfFrame();
    //    gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(text.gameObject.GetComponent<RectTransform>().sizeDelta.x + 20, 30);
    //}

    //public void OnClick()
    //{

    //}
=======
>>>>>>> Stashed changes
}
