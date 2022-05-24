using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalQuest : MonoBehaviour
{
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    // DialogueChoise dialogueChoise;
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    public QuestScriptableObject quest;
    [SerializeField] Text text;
    private int id;
    bool isCompleted = false;
    public void DrawActiveQuest(AQuest quest, int newId)
    {
        text.text = quest.quest.questName;
        id = newId;
        StartCoroutine(SetSize());
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        //text.text = dialogueChoise.answer;
        //this.dialogueChoise = dialogueChoise;
        //// Debug.Log(text.gameObject.GetComponent<RectTransform>().sizeDelta);
        //StartCoroutine(SetSize());
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    }
    public void DrawCompletedQuest(CompletedQuest quest, int newId)
    {
        text.text = quest.quest.questName;
        id = newId;
        isCompleted = true;
        StartCoroutine(SetSize());
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        //text.text = dialogueChoise.answer;
        //this.dialogueChoise = dialogueChoise;
        //// Debug.Log(text.gameObject.GetComponent<RectTransform>().sizeDelta);
        //StartCoroutine(SetSize());
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    }

    IEnumerator SetSize()
    {
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
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
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
        yield return new WaitForFixedUpdate();
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(270, text.gameObject.GetComponent<RectTransform>().sizeDelta.y);
    }

<<<<<<< HEAD
=======
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    public void OnClick()
    {
        GameManager.player.GetComponent<QuestsController>().journalPanel.SetDescription(id, isCompleted);
    }
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
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
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
}
