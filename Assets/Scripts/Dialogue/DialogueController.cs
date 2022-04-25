using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] Text interlocutorName;
    [SerializeField] Text text;
    [SerializeField] SpriteRenderer playerPic;
    [SerializeField] SpriteRenderer interlocutorPic;
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject scrollView;
    [SerializeField] GameObject answersBox;
    [SerializeField] GameObject answerPrefab;

    private bool isInterlocutorActive = false;
    private bool isPlayerActive = false;

    ADialogueSentence currentDialogueSentence;

    private bool isTalking = false;

    private void Start()
    {

        nextButton.SetActive(false);
        scrollView.SetActive(false);
        SetSpritesUnactive();
        StartCoroutine(SetNotActive());
    }

    IEnumerator SetNotActive()
    {
        yield return new WaitForEndOfFrame();
        gameObject.SetActive(false);
    }

    public void NextSentence()
    {
        if (currentDialogueSentence!=null)
        {
            (currentDialogueSentence as NarrativeDialogueSentence).DoChoise();
            currentDialogueSentence = (currentDialogueSentence as NarrativeDialogueSentence).nextSentence;
            SetText();



            bool isBranching = currentDialogueSentence.type == "Branching";

            SetBranching(isBranching);
            SetActiveInterlocutor(!isBranching);

        }
    }

    public void SetAnswer(ADialogueSentence sentence)
    {
        currentDialogueSentence = sentence;
        SetText();

        bool isBranching = currentDialogueSentence.type == "Branching";

        SetBranching(isBranching);
        SetActiveInterlocutor(!isBranching);
    }

    private void ClearBranching()
    {
        foreach (Transform child in answersBox.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void SetBranching(bool isBranching)
    {
        nextButton.SetActive(!isBranching);
        scrollView.SetActive(isBranching);
        if (isBranching)
        {
            ClearBranching();
            foreach (var item in (currentDialogueSentence as BranchingDialogueSentence).dialogueChoises)
            {
                GameObject newAnswer = Instantiate(answerPrefab, answersBox.transform);
                newAnswer.GetComponent<Answer>().SetText(item);
            }
        }
        else
        {
            //ClearBranching();
        }
    }

    public void StartDialog(ADialogueSentence sentence)
    {
        //GameManager.PauseGame();
        if (!isTalking)
        {
            isTalking = true;
            gameObject.SetActive(true);
            currentDialogueSentence = sentence;
            SetText();

            bool isBranching = currentDialogueSentence.type == "Branching";

            SetBranching(isBranching);
            SetActiveInterlocutor(!isBranching);

        }

    }

    public void StopDialog()
    {
        isTalking = false;
        currentDialogueSentence = null;
        //ClearBranching();
        SetSpritesUnactive();
        gameObject.SetActive(false);

       // GameManager.ResumeGame();
    }

    private void SetSpritesUnactive()
    {
        playerPic.color = Color.gray;
        playerPic.gameObject.transform.localScale = new Vector3(494, 494, 1);

        interlocutorPic.color = Color.gray;
        interlocutorPic.gameObject.transform.localScale = new Vector3(494, 494, 1);
        isInterlocutorActive = false;
        isPlayerActive = false;
    }

    public void SetActiveInterlocutor(bool setActive)
    {
        //ÊÎÐÓÒÈÍÛ ÊÎÐÓÒÈÍÛ ÁÎËÜØÅ ÊÎÐÓÒÈÍ!!! Ñîêðàòèòü â îáùåì
        if (setActive && !isInterlocutorActive)
        {
            StartCoroutine(0.2f.Tweeng((u) => interlocutorPic.color = u, Color.gray, Color.white));
            StartCoroutine(0.2f.Tweeng((u) => interlocutorPic.gameObject.transform.localScale = u, new Vector3(494, 494, 1), new Vector3(594, 594, 1)));



            if (isPlayerActive)
            {
                StartCoroutine(0.2f.Tweeng((u) => playerPic.color = u, Color.white, Color.gray));
                StartCoroutine(0.2f.Tweeng((u) => playerPic.gameObject.transform.localScale = u, new Vector3(594, 594, 1), new Vector3(494, 494, 1)));
            }
            

            //StartCoroutine(0.2f.Tweeng((u) => playerPic.gameObject.transform.localScale = u, Color.gray, Color.white));
            //playerPic.color = Color.gray;
            //playerPic.gameObject.transform.localScale = new Vector3(494, 494, 1);

            //interlocutorPic.color = Color.white;
            //interlocutorPic.gameObject.transform.localScale = new Vector3(594, 594, 1);
            isInterlocutorActive = true;
            isPlayerActive = false;
        }
        else if(!setActive && !isPlayerActive)
        {

            StartCoroutine(0.2f.Tweeng((u) => playerPic.color = u, Color.gray, Color.white));
            StartCoroutine(0.2f.Tweeng((u) => playerPic.gameObject.transform.localScale = u, new Vector3(494, 494, 1), new Vector3(594, 594, 1)));
            if (isInterlocutorActive)
            {
                StartCoroutine(0.2f.Tweeng((u) => interlocutorPic.color = u, Color.white, Color.gray));
                StartCoroutine(0.2f.Tweeng((u) => interlocutorPic.gameObject.transform.localScale = u, new Vector3(594, 594, 1), new Vector3(494, 494, 1)));
            }
            isInterlocutorActive = false;
            isPlayerActive = true;
            //playerPic.color = Color.white;
            //playerPic.gameObject.transform.localScale = new Vector3(594, 594, 1);

            //interlocutorPic.color = Color.gray;
            //interlocutorPic.gameObject.transform.localScale = new Vector3(494, 494, 1);
        }

    }


    private void SetText()
    {
        interlocutorName.text = currentDialogueSentence.interlocutorName;
        text.text = currentDialogueSentence.sentence;
    }
}
