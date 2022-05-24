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
<<<<<<< HEAD
    [SerializeField] private GameObject currentGlobalLight;
    [SerializeField] private GameObject loadGamePanel;

    public void NewGame()
    {
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======

    [SerializeField] private GameObject currentGlobalLight;
    [SerializeField] private GameObject loadGamePanel;
>>>>>>> Stashed changes
=======

    [SerializeField] private GameObject currentGlobalLight;
    [SerializeField] private GameObject loadGamePanel;
>>>>>>> Stashed changes
=======
    [SerializeField] private GameObject currentGlobalLight;
    [SerializeField] private GameObject loadGamePanel;
>>>>>>> Stashed changes

    public void NewGame()
    {
<<<<<<< Updated upstream
        
        GameObject player = Instantiate(playerPrefab);
        GameObject ui = Instantiate(UIPrefab);
        Instantiate(globalLightPrefab);
        SceneManager.LoadScene("0.0");
        Destroy(currentGlobalLight);
        ui.GetComponent<Canvas>().worldCamera = player.GetComponentInChildren<Camera>();
        Instantiate(globalLightPrefab);

=======
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
        SpawnPlayer();
        SceneManager.LoadScene("NGStartScene");
        Destroy(currentGlobalLight);
        Instantiate(globalLightPrefab);
<<<<<<< HEAD
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    }

    public void LoadGame(string txt)
    {
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
        GameObject player = Instantiate(playerPrefab);
        GameObject ui = Instantiate(UIPrefab);
        Destroy(currentGlobalLight);
        ui.GetComponent<Canvas>().worldCamera = player.GetComponentInChildren<Camera>();
=======
        SpawnPlayer();
        Destroy(currentGlobalLight);
>>>>>>> Stashed changes
        Instantiate(globalLightPrefab);
        StartCoroutine(Load(txt));
    }

    IEnumerator Load(string txt)
    {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        Debug.Log("Load");
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
        yield return new WaitForEndOfFrame();
        GameManager.player.GetComponent<SaveLoadController>().Load(txt);
    }

    public void LoadGameButton()
    {
<<<<<<< Updated upstream
=======
        GameManager.ClickPlay();
>>>>>>> Stashed changes
        loadGamePanel.SetActive(!loadGamePanel.activeInHierarchy);
        if (loadGamePanel.activeInHierarchy)
        {
            loadGamePanel.GetComponent<MenuLoadPanel>().ShowLoadGames();
        }
<<<<<<< Updated upstream
    }

    public void StartTestLocation()
    {
        GameObject player = Instantiate(playerPrefab);
        GameObject ui = Instantiate(UIPrefab);
        SceneManager.LoadScene("TestLocation");
        Destroy(currentGlobalLight);
        ui.GetComponent<Canvas>().worldCamera = player.GetComponentInChildren<Camera>();
        Instantiate(globalLightPrefab);
        
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
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
=======
    [SerializeField] private GameObject currentGlobalLight;
    [SerializeField] private GameObject loadGamePanel;

    public void NewGame()
    {
        SpawnPlayer();
        SceneManager.LoadScene("NGStartScene");
        Destroy(currentGlobalLight);
        Instantiate(globalLightPrefab);
    }

    public void LoadGame(string txt)
    {
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
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
<<<<<<< HEAD
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
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
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    }

    public void Exit()
    {
<<<<<<< HEAD
        GameManager.ClickPlay();
        GameManager.ExitGame();
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        GameManager.ExitGame();

=======
        GameManager.ClickPlay();
        GameManager.ExitGame();
>>>>>>> Stashed changes
=======
        GameManager.ClickPlay();
        GameManager.ExitGame();
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    }
}
