using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Answer : MonoBehaviour
{
    DialogueChoise dialogueChoise;
    [SerializeField] Text text;
    public void SetText(DialogueChoise dialogueChoise)
    {
        text.text = dialogueChoise.answer;
        this.dialogueChoise = dialogueChoise;
        // Debug.Log(text.gameObject.GetComponent<RectTransform>().sizeDelta);
        StartCoroutine(SetSize());
    }

    IEnumerator SetSize()
    {
        // We should only read the screen buffer after rendering is complete
        yield return new WaitForEndOfFrame();
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2 (text.gameObject.GetComponent<RectTransform>().sizeDelta.x + 20, 30);
    }

    public void OnClick()
    {
        DialogueController dialogueController = GameManager.UI.GetComponent<UIScript>().dialogueController;
        if (dialogueChoise.nextSentence != null)
        {
            dialogueController.SetAnswer(dialogueChoise.nextSentence);
        }
        else
        {
            dialogueController.StopDialog();
        }

        dialogueChoise.DoChoise();
    }
}
