using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
<<<<<<< Updated upstream
=======
using UnityEngine.UI;
>>>>>>> Stashed changes

public class UIScript : MonoBehaviour
{

    [SerializeField] private List<GameObject> panels;
<<<<<<< Updated upstream
    [SerializeField] public ShopController shopController;
    [SerializeField] private GameObject closeButton;
=======
    public ShopController shopController;
    [SerializeField] private GameObject closeButton;
    public DialogueController dialogueController;
    [SerializeField] private GameObject saveUnlocked;
    [SerializeField] private Button saveButton;
>>>>>>> Stashed changes

    private void Start()
    {
        saveButton.interactable = false;
        saveUnlocked.SetActive(false);
        DontDestroyOnLoad(gameObject);
        shopController.gameObject.SetActive(false);
        closeButton.SetActive(false);
<<<<<<< Updated upstream
=======
        StartCoroutine(SetPanelsNotActive());

    }
    IEnumerator SetPanelsNotActive()
    {
        yield return new WaitForEndOfFrame();
        CloseAllPanels();
>>>>>>> Stashed changes
    }
    public MagicUpPanel GetMagicUpPanel()
    {
        return panels[3].GetComponent<MagicUpPanel>();
    }



    public void SetSaveActive()
    {
        saveUnlocked.SetActive(true);
        saveButton.interactable = true;
    }

    public void SetSaveDisable()
    {
        saveUnlocked.SetActive(false);
        saveButton.interactable = false;

    }
    //public void PauseGame()
    //{
    //    GameManager.isGamePaused = true;
    //    Time.timeScale = 0;
    //}

    //Возобновить
    //public void ResumeGame()
    //{
    //    GameManager.isGamePaused = false;
    //    Time.timeScale = 1;
    //}

    public void CloseAllPanels()
    {
        foreach (var item in panels)
        {
            item.SetActive(false);
        }
        closeButton.SetActive(false);
        GameManager.ResumeGame();
    }

<<<<<<< Updated upstream
    public void CloseAllPanels()
    {
        foreach (var item in panels)
        {
            item.SetActive(false);
        }
        closeButton.SetActive(false);
        ResumeGame();
    }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> Stashed changes
    public void ExpandPanel(GameObject panel, Vector2 startPos)
    {
        StartCoroutine(0.1f.Tweeng((u) => panel.transform.localPosition = u, startPos, Vector2.zero));
        StartCoroutine(0.1f.Tweeng((u) => panel.transform.localScale = u, Vector3.zero, Vector3.one));
    }

<<<<<<< Updated upstream
    public void ExitGame(InputAction.CallbackContext inputValue)
    {
        GameManager.ExitGame();
    }


=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
    //public void ExitGame(InputAction.CallbackContext inputValue)
    //{
    //    GameManager.ExitGame();
    //}


>>>>>>> Stashed changes
    public bool CheckNotOpen(GameObject panel)
    {
        bool res = true;
        foreach (var item in panels)
        {
            if(item.activeInHierarchy==true && item==panel)
            {
                item.SetActive(false);
                closeButton.SetActive(false);
<<<<<<< Updated upstream
                ResumeGame();
=======
                GameManager.ResumeGame();
>>>>>>> Stashed changes
                res = false;
            }
            else if(item.activeInHierarchy == true && item != panel)
            {
                item.SetActive(false);
            }
        }

        if (res)
        {
            closeButton.SetActive(true);
<<<<<<< Updated upstream
            PauseGame();
=======
            GameManager.PauseGame();
>>>>>>> Stashed changes
        }

        return res;
    }
    
}
