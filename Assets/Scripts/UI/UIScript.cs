using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{

    [SerializeField] private List<GameObject> panels;
    [SerializeField] public ShopController shopController;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        shopController.gameObject.SetActive(false);
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
    public bool CheckNotOpen(GameObject panel)
    {
        bool res = true;
        foreach (var item in panels)
        {
            if(item.activeInHierarchy==true && item==panel)
            {
                item.SetActive(false);
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
            PauseGame();
        }

        return res;
    }
    
}
