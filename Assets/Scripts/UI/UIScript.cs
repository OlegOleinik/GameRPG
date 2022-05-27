using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
<<<<<<< Updated upstream
<<<<<<< HEAD
using UnityEngine.SceneManagement;
using UnityEngine.UI;
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
using UnityEngine.UI;
>>>>>>> Stashed changes
=======
using UnityEngine.UI;
>>>>>>> Stashed changes
=======
using UnityEngine.SceneManagement;
using UnityEngine.UI;
>>>>>>> Stashed changes
=======
using UnityEngine.SceneManagement;
using UnityEngine.UI;
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
using UnityEngine.SceneManagement;
using UnityEngine.UI;
>>>>>>> Stashed changes

public class UIScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> panels;
<<<<<<< Updated upstream
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    [SerializeField] public ShopController shopController;
    [SerializeField] private GameObject closeButton;
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
>>>>>>> Stashed changes
    public ShopController shopController;
    [SerializeField] private GameObject closeButton;
    public DialogueController dialogueController;
    [SerializeField] private GameObject saveUnlocked;
    [SerializeField] private Button saveButton;
<<<<<<< Updated upstream
<<<<<<< HEAD
    [SerializeField] private GameObject deathMessage;
    private bool isOpenBlocked = false;
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
    [SerializeField] private GameObject deathMessage;
    private bool isOpenBlocked = false;
>>>>>>> Stashed changes
=======
    [SerializeField] private GameObject deathMessage;
    private bool isOpenBlocked = false;
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
    [SerializeField] private GameObject deathMessage;
    private bool isOpenBlocked = false;
>>>>>>> Stashed changes

    private void Start()
    {
        saveButton.interactable = false;
        saveUnlocked.SetActive(false);
        DontDestroyOnLoad(gameObject);
        shopController.gameObject.SetActive(false);
        closeButton.SetActive(false);
<<<<<<< Updated upstream
<<<<<<< HEAD
        StartCoroutine(SetPanelsNotActive());
        deathMessage.SetActive(false);
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes
        StartCoroutine(SetPanelsNotActive());

=======
        StartCoroutine(SetPanelsNotActive());
        deathMessage.SetActive(false);
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
        StartCoroutine(SetPanelsNotActive());
        deathMessage.SetActive(false);
>>>>>>> Stashed changes
    }
    IEnumerator SetPanelsNotActive()
    {
        yield return new WaitForEndOfFrame();
        CloseAllPanels();
<<<<<<< Updated upstream
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    }
    public MagicUpPanel GetMagicUpPanel()
    {
        return panels[3].GetComponent<MagicUpPanel>();
    }

<<<<<<< HEAD
    public void SetDeathMessage(string enemy, int money, int lvl, string weapon)
    {
        CloseAllPanels();
        isOpenBlocked = true;
        deathMessage.SetActive(true);
        string txt = $"End of the way\nHeroic death in battle with the enemy: {enemy}\n\nlvl: {lvl}\nMoney: {money}\nWeapon: {weapon}";
        deathMessage.GetComponentInChildren<Text>().text = txt;
    }
=======
<<<<<<< Updated upstream


    public void SetSaveActive()
    {
        saveUnlocked.SetActive(true);
        saveButton.interactable = true;
    }
=======
    }
    public MagicUpPanel GetMagicUpPanel()
    {
        return panels[3].GetComponent<MagicUpPanel>();
    }



    public void SetSaveActive()
    {
        saveUnlocked.SetActive(true);
        saveButton.interactable = true;
=======
        StartCoroutine(SetPanelsNotActive());
        deathMessage.SetActive(false);
    }
    IEnumerator SetPanelsNotActive()
    {
        yield return new WaitForEndOfFrame();
        CloseAllPanels();
=======
    }
    public MagicUpPanel GetMagicUpPanel()
    {
        return panels[3].GetComponent<MagicUpPanel>();
>>>>>>> Stashed changes
    }
    public MagicUpPanel GetMagicUpPanel()
    {
        return panels[3].GetComponent<MagicUpPanel>();
>>>>>>> Stashed changes
    }
>>>>>>> Stashed changes

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

<<<<<<< Updated upstream
<<<<<<< Updated upstream
    //Возобновить
    //public void ResumeGame()
    //{
    //    GameManager.isGamePaused = false;
    //    Time.timeScale = 1;
    //}

    public void CloseAllPanels()
<<<<<<< Updated upstream
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
=======
    {
=======
    public void SetDeathMessage(string enemy, int money, int lvl, string weapon)
    {
        CloseAllPanels();
        isOpenBlocked = true;
        deathMessage.SetActive(true);
        string txt = $"End of the way\nHeroic death in battle with the enemy: {enemy}\n\nlvl: {lvl}\nMoney: {money}\nWeapon: {weapon}";
        deathMessage.GetComponentInChildren<Text>().text = txt;
    }
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76

    public void ExitToMenu()
    {
        Destroy(GameObject.Find("Global Light 2D(Clone)"));
        CloseAllPanels();
        deathMessage.SetActive(false);
        GameManager.player.SetActive(false);
        GameManager.UI.SetActive(false);
        GameManager.ResumeGame();
        isOpenBlocked = false;
        SceneManager.LoadScene("StartMenu");
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

    public void CloseAllPanels()
    {
        GameManager.ClickPlay();
<<<<<<< HEAD
=======
>>>>>>> Stashed changes
=======
    public void SetDeathMessage(string enemy, int money, int lvl, string weapon)
    {
        CloseAllPanels();
        isOpenBlocked = true;
        deathMessage.SetActive(true);
        string txt = $"End of the way\nHeroic death in battle with the enemy: {enemy}\n\nlvl: {lvl}\nMoney: {money}\nWeapon: {weapon}";
        deathMessage.GetComponentInChildren<Text>().text = txt;
    }

    public void ExitToMenu()
    {
        Destroy(GameObject.Find("Global Light 2D(Clone)"));
        CloseAllPanels();
        deathMessage.SetActive(false);
        GameManager.player.SetActive(false);
        GameManager.UI.SetActive(false);
        GameManager.ResumeGame();
        isOpenBlocked = false;
        SceneManager.LoadScene("StartMenu");
    }

=======
    public void SetDeathMessage(string enemy, int money, int lvl, string weapon)
    {
        CloseAllPanels();
        isOpenBlocked = true;
        deathMessage.SetActive(true);
        string txt = $"End of the way\nHeroic death in battle with the enemy: {enemy}\n\nlvl: {lvl}\nMoney: {money}\nWeapon: {weapon}";
        deathMessage.GetComponentInChildren<Text>().text = txt;
    }

    public void ExitToMenu()
    {
        Destroy(GameObject.Find("Global Light 2D(Clone)"));
        CloseAllPanels();
        deathMessage.SetActive(false);
        GameManager.player.SetActive(false);
        GameManager.UI.SetActive(false);
        GameManager.ResumeGame();
        isOpenBlocked = false;
        SceneManager.LoadScene("StartMenu");
    }

>>>>>>> Stashed changes
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

    public void CloseAllPanels()
    {
        GameManager.ClickPlay();
<<<<<<< Updated upstream
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
>>>>>>> Stashed changes
        foreach (var item in panels)
        {
            item.SetActive(false);
        }
        closeButton.SetActive(false);
        GameManager.ResumeGame();
    }

    public void ExpandPanel(GameObject panel, Vector2 startPos)
    {
        StartCoroutine(0.1f.Tweeng((u) => panel.transform.localPosition = u, startPos, Vector2.zero));
        StartCoroutine(0.1f.Tweeng((u) => panel.transform.localScale = u, Vector3.zero, Vector3.one));
    }

<<<<<<< Updated upstream
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
    //public void ExitGame(InputAction.CallbackContext inputValue)
    //{
    //    GameManager.ExitGame();
    //}


<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
>>>>>>> Stashed changes
    public bool CheckNotOpen(GameObject panel)
    {
        bool res = true;
        if (isOpenBlocked)
        {
            return false;
        }
        foreach (var item in panels)
        {
            if(item.activeInHierarchy==true && item==panel)
            {
                item.SetActive(false);
                closeButton.SetActive(false);
<<<<<<< Updated upstream
<<<<<<< HEAD
                GameManager.ResumeGame();
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
                ResumeGame();
=======
                GameManager.ResumeGame();
>>>>>>> Stashed changes
=======
                GameManager.ResumeGame();
>>>>>>> Stashed changes
=======
                GameManager.ResumeGame();
>>>>>>> Stashed changes
=======
                GameManager.ResumeGame();
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
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
<<<<<<< HEAD
            GameManager.PauseGame();
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            PauseGame();
=======
            GameManager.PauseGame();
>>>>>>> Stashed changes
=======
            GameManager.PauseGame();
>>>>>>> Stashed changes
=======
            GameManager.PauseGame();
>>>>>>> Stashed changes
=======
            GameManager.PauseGame();
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
            GameManager.PauseGame();
>>>>>>> Stashed changes
        }
        return res;
    }
}
