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
<<<<<<< Updated upstream

    private bool isInterlocutorActive = false;
    private bool isPlayerActive = false;

    ADialogueSentence currentDialogueSentence;

=======
    private bool isInterlocutorActive = false;
    private bool isPlayerActive = false;
    ADialogueSentence currentDialogueSentence;
>>>>>>> Stashed changes
    private bool isTalking = false;

    private void Start()
    {
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        if (currentDialogueSentence!=null)
        {
            (currentDialogueSentence as NarrativeDialogueSentence).DoChoise();
            currentDialogueSentence = (currentDialogueSentence as NarrativeDialogueSentence).nextSentence;
            SetText();



            bool isBranching = currentDialogueSentence.type == "Branching";

            SetBranching(isBranching);
            SetActiveInterlocutor(!isBranching);

=======
        ADialogueSentence next = (currentDialogueSentence as NarrativeDialogueSentence).nextSentence;
        (currentDialogueSentence as NarrativeDialogueSentence).DoChoise();
        if (next != null)
        {
            GameManager.ClickPlay();
            currentDialogueSentence = next;
            SetText();
            bool isBranching = currentDialogueSentence.type == "Branching";
            SetBranching(isBranching);
            SetActiveInterlocutor(!isBranching);
        }
        else
        {
            StopDialog();
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        else
        {
            //ClearBranching();
        }
    }

    public void StartDialog(ADialogueSentence sentence)
    {
        //GameManager.PauseGame();
=======
    }

    public void StartDialog(ADialogueSentence sentence, Sprite interlocutorSprite)
    {
>>>>>>> Stashed changes
        if (!isTalking)
        {
            isTalking = true;
            gameObject.SetActive(true);
            currentDialogueSentence = sentence;
            SetText();
<<<<<<< Updated upstream

=======
            interlocutorPic.sprite = interlocutorSprite;
>>>>>>> Stashed changes
            bool isBranching = currentDialogueSentence.type == "Branching";

            SetBranching(isBranching);
            SetActiveInterlocutor(!isBranching);
<<<<<<< Updated upstream

        }

=======
        }
>>>>>>> Stashed changes
    }

    public void StopDialog()
    {
        isTalking = false;
        currentDialogueSentence = null;
<<<<<<< Updated upstream
        //ClearBranching();
        SetSpritesUnactive();
        gameObject.SetActive(false);

       // GameManager.ResumeGame();
=======
        SetSpritesUnactive();
        gameObject.SetActive(false);
>>>>>>> Stashed changes
    }

    private void SetSpritesUnactive()
    {
        playerPic.color = Color.gray;
        playerPic.gameObject.transform.localScale = new Vector3(494, 494, 1);
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream



=======
>>>>>>> Stashed changes
            if (isPlayerActive)
            {
                StartCoroutine(0.2f.Tweeng((u) => playerPic.color = u, Color.white, Color.gray));
                StartCoroutine(0.2f.Tweeng((u) => playerPic.gameObject.transform.localScale = u, new Vector3(594, 594, 1), new Vector3(494, 494, 1)));
            }
<<<<<<< Updated upstream
            

            //StartCoroutine(0.2f.Tweeng((u) => playerPic.gameObject.transform.localScale = u, Color.gray, Color.white));
            //playerPic.color = Color.gray;
            //playerPic.gameObject.transform.localScale = new Vector3(494, 494, 1);

            //interlocutorPic.color = Color.white;
            //interlocutorPic.gameObject.transform.localScale = new Vector3(594, 594, 1);
=======
>>>>>>> Stashed changes
            isInterlocutorActive = true;
            isPlayerActive = false;
        }
        else if(!setActive && !isPlayerActive)
        {
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
            StartCoroutine(0.2f.Tweeng((u) => playerPic.color = u, Color.gray, Color.white));
            StartCoroutine(0.2f.Tweeng((u) => playerPic.gameObject.transform.localScale = u, new Vector3(494, 494, 1), new Vector3(594, 594, 1)));
            if (isInterlocutorActive)
            {
                StartCoroutine(0.2f.Tweeng((u) => interlocutorPic.color = u, Color.white, Color.gray));
                StartCoroutine(0.2f.Tweeng((u) => interlocutorPic.gameObject.transform.localScale = u, new Vector3(594, 594, 1), new Vector3(494, 494, 1)));
            }
            isInterlocutorActive = false;
            isPlayerActive = true;
<<<<<<< Updated upstream
            //playerPic.color = Color.white;
            //playerPic.gameObject.transform.localScale = new Vector3(594, 594, 1);

            //interlocutorPic.color = Color.gray;
            //interlocutorPic.gameObject.transform.localScale = new Vector3(494, 494, 1);
        }

=======
        }
>>>>>>> Stashed changes
    }


    private void SetText()
    {
        interlocutorName.text = currentDialogueSentence.interlocutorName;
        text.text = currentDialogueSentence.sentence;
    }
}
