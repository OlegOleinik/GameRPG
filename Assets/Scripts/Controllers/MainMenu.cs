using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject UIPrefab;
    [SerializeField] private GameObject globalLightPrefab;
    [SerializeField] private GameObject currentGlobalLight;
    [SerializeField] private GameObject loadGamePanel;
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button loadGameButton;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("isTestFinished") || PlayerPrefs.GetInt("isTestFinished") != 1)
        {
            newGameButton.interactable = false;
            loadGameButton.interactable = false;
        }
        else
        {
            newGameButton.interactable = true;
            loadGameButton.interactable = true;
        }
    }
    public void NewGame()
    {
        SpawnPlayer();
        SceneManager.LoadScene("NGStartScene");
        Destroy(currentGlobalLight);
        Instantiate(globalLightPrefab);
    }

    public void LoadGame(string txt)
    {
        SpawnPlayer();
        Destroy(currentGlobalLight);
        Instantiate(globalLightPrefab);
        StartCoroutine(Load(txt));
    }

    IEnumerator Load(string txt)
    {
        yield return new WaitForEndOfFrame();
        GameManager.player.GetComponent<SaveLoadController>().Load(txt);
    }

    public void LoadGameButton()
    {
        GameManager.ClickPlay();
        loadGamePanel.SetActive(!loadGamePanel.activeInHierarchy);
        if (loadGamePanel.activeInHierarchy)
        {
            loadGamePanel.GetComponent<MenuLoadPanel>().ShowLoadGames();
        }
    }

    public void StartTestLocation()
    {
        SpawnPlayer();
        Destroy(currentGlobalLight);
        SceneManager.LoadScene("TestLocation");
        Instantiate(globalLightPrefab);
    }

    private void SpawnPlayer()
    {
        if (GameManager.player == null)
        {
            GameObject player = Instantiate(playerPrefab);
            GameManager.SetNewPlayerLink(player);
            GameObject ui = Instantiate(UIPrefab);
            GameManager.SetNewUILink(ui);
            ui.GetComponent<Canvas>().worldCamera = player.GetComponentInChildren<Camera>();
        }
        else
        {
            GameManager.player.transform.position = Vector3.zero;
            GameManager.player.SetActive(true);
            GameManager.UI.SetActive(true);
            GameManager.player.GetComponent<SaveLoadController>().SetPlayerDefault();
            GameManager.player.GetComponent<PlayerInput>().enabled = true;
        }
    }

    public void Exit()
    {
        GameManager.ClickPlay();
        GameManager.ExitGame();
    }
}
