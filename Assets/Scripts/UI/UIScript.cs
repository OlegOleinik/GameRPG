using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{

    [SerializeField] private List<GameObject> panels;
    [SerializeField] public ShopController shopController;
    [SerializeField] private GameObject closeButton;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        shopController.gameObject.SetActive(false);
        closeButton.SetActive(false);
    }
    public void PauseGame()
    {
        GameManager.isGamePaused = true;
        Time.timeScale = 0;
    }

    //Возобновить
    public void ResumeGame()
    {
        GameManager.isGamePaused = false;
        Time.timeScale = 1;
    }

    public void CloseAllPanels()
    {
        foreach (var item in panels)
        {
            item.SetActive(false);
        }
        closeButton.SetActive(false);
        ResumeGame();
    }
    public bool CheckNotOpen(GameObject panel)
    {
        bool res = true;
        foreach (var item in panels)
        {
            if(item.activeInHierarchy==true && item==panel)
            {
                item.SetActive(false);
                closeButton.SetActive(false);
                ResumeGame();
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
            PauseGame();
        }

        return res;
    }
    
}
