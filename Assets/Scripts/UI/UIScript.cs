using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> panels;
    public ShopController shopController;
    [SerializeField] private GameObject closeButton;
    public DialogueController dialogueController;
    [SerializeField] private GameObject saveUnlocked;
    [SerializeField] private Button saveButton;
    [SerializeField] private GameObject deathMessage;
    private bool isOpenBlocked = false;

    private void Start()
    {
        saveButton.interactable = false;
        saveUnlocked.SetActive(false);
        DontDestroyOnLoad(gameObject);
        shopController.gameObject.SetActive(false);
        closeButton.SetActive(false);
        StartCoroutine(SetPanelsNotActive());
        deathMessage.SetActive(false);
    }
    IEnumerator SetPanelsNotActive()
    {
        yield return new WaitForEndOfFrame();
        CloseAllPanels();
    }
    public MagicUpPanel GetMagicUpPanel()
    {
        return panels[3].GetComponent<MagicUpPanel>();
    }

    public void SetDeathMessage(string enemy, int money, int lvl, string weapon)
    {
        CloseAllPanels();
        isOpenBlocked = true;
        deathMessage.SetActive(true);
        string txt = $"Конец пути\nГероическая смерть в бою с противником: {enemy}\n\nУровень: {lvl}\nМонет: {money}\nОружие: {weapon}";
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
                GameManager.ResumeGame();
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
            GameManager.PauseGame();
        }
        return res;
    }
}
