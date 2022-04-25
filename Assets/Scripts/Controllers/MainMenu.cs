using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject UIPrefab;
    [SerializeField] private GameObject globalLightPrefab;
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


    //private void Start()
    //{
    //    NewGame();
    //}
    public void NewGame()
    {
        
        GameObject player = Instantiate(playerPrefab);
        GameObject ui = Instantiate(UIPrefab);
        Instantiate(globalLightPrefab);
        SceneManager.LoadScene("0.0");
        Destroy(currentGlobalLight);
        ui.GetComponent<Canvas>().worldCamera = player.GetComponentInChildren<Camera>();
        Instantiate(globalLightPrefab);

    }

    public void LoadGame(string txt)
    {
        GameObject player = Instantiate(playerPrefab);
        GameObject ui = Instantiate(UIPrefab);
        Destroy(currentGlobalLight);
        ui.GetComponent<Canvas>().worldCamera = player.GetComponentInChildren<Camera>();
        Instantiate(globalLightPrefab);
        StartCoroutine(Load(txt));
    }

    IEnumerator Load(string txt)
    {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        Debug.Log("Load");
=======
=======
>>>>>>> Stashed changes
        yield return new WaitForEndOfFrame();
        GameManager.player.GetComponent<SaveLoadController>().Load(txt);
    }

    public void LoadGameButton()
    {
        loadGamePanel.SetActive(!loadGamePanel.activeInHierarchy);
        if (loadGamePanel.activeInHierarchy)
        {
            loadGamePanel.GetComponent<MenuLoadPanel>().ShowLoadGames();
        }
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
    }

    public void Exit()
    {
        GameManager.ExitGame();

    }
}
