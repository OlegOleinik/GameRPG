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
<<<<<<< HEAD
    private bool isInterlocutorActive = false;
    private bool isPlayerActive = false;
    ADialogueSentence currentDialogueSentence;
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

    private bool isInterlocutorActive = false;
    private bool isPlayerActive = false;

    ADialogueSentence currentDialogueSentence;

=======
    private bool isInterlocutorActive = false;
    private bool isPlayerActive = false;
    ADialogueSentence currentDialogueSentence;
>>>>>>> Stashed changes
=======
    private bool isInterlocutorActive = false;
    private bool isPlayerActive = false;
    ADialogueSentence currentDialogueSentence;
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    private bool isTalking = false;

    private void Start()
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
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
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
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
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
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
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
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
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
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    }

    public void StartDialog(ADialogueSentence sentence, Sprite interlocutorSprite)
    {
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
        if (!isTalking)
        {
            isTalking = true;
            gameObject.SetActive(true);
            currentDialogueSentence = sentence;
            SetText();
<<<<<<< HEAD
            interlocutorPic.sprite = interlocutorSprite;
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

=======
            interlocutorPic.sprite = interlocutorSprite;
>>>>>>> Stashed changes
=======
            interlocutorPic.sprite = interlocutorSprite;
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
            bool isBranching = currentDialogueSentence.type == "Branching";

            SetBranching(isBranching);
            SetActiveInterlocutor(!isBranching);
<<<<<<< HEAD
        }
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

        }

=======
        }
>>>>>>> Stashed changes
=======
        }
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    }

    public void StopDialog()
    {
        isTalking = false;
        currentDialogueSentence = null;
<<<<<<< HEAD
        SetSpritesUnactive();
        gameObject.SetActive(false);
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        //ClearBranching();
        SetSpritesUnactive();
        gameObject.SetActive(false);

       // GameManager.ResumeGame();
=======
        SetSpritesUnactive();
        gameObject.SetActive(false);
>>>>>>> Stashed changes
=======
        SetSpritesUnactive();
        gameObject.SetActive(false);
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    }

    private void SetSpritesUnactive()
    {
        playerPic.color = Color.gray;
        playerPic.gameObject.transform.localScale = new Vector3(494, 494, 1);
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
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
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream



=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
            if (isPlayerActive)
            {
                StartCoroutine(0.2f.Tweeng((u) => playerPic.color = u, Color.white, Color.gray));
                StartCoroutine(0.2f.Tweeng((u) => playerPic.gameObject.transform.localScale = u, new Vector3(594, 594, 1), new Vector3(494, 494, 1)));
            }
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            

            //StartCoroutine(0.2f.Tweeng((u) => playerPic.gameObject.transform.localScale = u, Color.gray, Color.white));
            //playerPic.color = Color.gray;
            //playerPic.gameObject.transform.localScale = new Vector3(494, 494, 1);

            //interlocutorPic.color = Color.white;
            //interlocutorPic.gameObject.transform.localScale = new Vector3(594, 594, 1);
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
            isInterlocutorActive = true;
            isPlayerActive = false;
        }
        else if(!setActive && !isPlayerActive)
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
            StartCoroutine(0.2f.Tweeng((u) => playerPic.color = u, Color.gray, Color.white));
            StartCoroutine(0.2f.Tweeng((u) => playerPic.gameObject.transform.localScale = u, new Vector3(494, 494, 1), new Vector3(594, 594, 1)));
            if (isInterlocutorActive)
            {
                StartCoroutine(0.2f.Tweeng((u) => interlocutorPic.color = u, Color.white, Color.gray));
                StartCoroutine(0.2f.Tweeng((u) => interlocutorPic.gameObject.transform.localScale = u, new Vector3(594, 594, 1), new Vector3(494, 494, 1)));
            }
            isInterlocutorActive = false;
            isPlayerActive = true;
<<<<<<< HEAD
        }
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            //playerPic.color = Color.white;
            //playerPic.gameObject.transform.localScale = new Vector3(594, 594, 1);

            //interlocutorPic.color = Color.gray;
            //interlocutorPic.gameObject.transform.localScale = new Vector3(494, 494, 1);
        }

=======
        }
>>>>>>> Stashed changes
=======
        }
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    }


    private void SetText()
    {
        interlocutorName.text = currentDialogueSentence.interlocutorName;
        text.text = currentDialogueSentence.sentence;
    }
}
