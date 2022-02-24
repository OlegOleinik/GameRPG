using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{

    public GameObject player;
    [SerializeField] private List<GameObject> panels;
    private void Awake()
    {
        player = GameManager.player;
        DontDestroyOnLoad(gameObject);
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
        foreach (var item in panels)
        {
            if(item.activeInHierarchy==true && item==panel)
            {
                item.SetActive(false);
                ResumeGame();
                return false;
            }
            else if(item.activeInHierarchy == true && item != panel)
            {
                item.SetActive(false);
                return true;
            }
        }
        PauseGame();
        return true;
    }
    
}
