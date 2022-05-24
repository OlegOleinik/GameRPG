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
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        // Debug.Log(text.gameObject.GetComponent<RectTransform>().sizeDelta);
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
        StartCoroutine(SetSize());
    }

    IEnumerator SetSize()
    {
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        // We should only read the screen buffer after rendering is complete
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
        yield return new WaitForEndOfFrame();
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2 (text.gameObject.GetComponent<RectTransform>().sizeDelta.x + 20, 30);
    }

    public void OnClick()
    {
<<<<<<< HEAD
        GameManager.ClickPlay();
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
        GameManager.ClickPlay();
>>>>>>> Stashed changes
=======
        GameManager.ClickPlay();
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
        DialogueController dialogueController = GameManager.UI.GetComponent<UIScript>().dialogueController;
        if (dialogueChoise.nextSentence != null)
        {
            dialogueController.SetAnswer(dialogueChoise.nextSentence);
        }
        else
        {
            dialogueController.StopDialog();
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
        dialogueChoise.DoChoise();
    }
}
