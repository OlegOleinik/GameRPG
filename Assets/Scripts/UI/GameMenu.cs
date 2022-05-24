using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
        gameObject.SetActive(true);
        GameManager.ClickPlay();
        GameManager.PauseGame();
    }

    public void OpenSavePanel()
    {
        GameManager.ClickPlay();

        savedGamesPanel.ShowResaveGames();
    }

    public void OpenLoadPanel()
    {
        GameManager.ClickPlay();

        savedGamesPanel.ShowLoadGames();

    }

    public void MainMenu()
    {

        GetComponentInParent<UIScript>().ExitToMenu();
        

    }

    void OnDisable()
    {
        GameManager.ClickPlay();
        savedGamesPanel.gameObject.SetActive(false);
    }

    public void Exit()
    {
        GameManager.ClickPlay();

        GameManager.ExitGame();
    }
}
