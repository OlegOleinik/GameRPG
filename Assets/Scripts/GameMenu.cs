using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private SavedGamesPanel savedGamesPanel;
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void OpenCloseMenu(InputAction.CallbackContext inputValue)
    {
        if (inputValue.phase == InputActionPhase.Started && GameManager.UI.GetComponent<UIScript>().CheckNotOpen(gameObject))
        {
            OpenMenu();
        }
    }

    public void OpenMenu()
    {

       // GameManager.UI.GetComponent<UIScript>().CloseAllPanels();
        gameObject.SetActive(true);
        GameManager.PauseGame();
    }


    public void OpenSavePanel()
    {
        savedGamesPanel.ShowResaveGames();
    }
    public void OpenLoadPanel()
    {
        savedGamesPanel.ShowLoadGames();

    }

    public void MainMenu()
    {
       
    }



    void OnDisable()
    {
        savedGamesPanel.gameObject.SetActive(false);
    }


    public void Exit()
    {
        GameManager.ExitGame();
    }
}
