using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject UIPrefab;


    //private void Start()
    //{
    //    NewGame();
    //}
    public void NewGame()
    {
        
        GameObject player = Instantiate(playerPrefab);
        GameObject ui = Instantiate(UIPrefab);
        SceneManager.LoadScene("0.0");
        ui.GetComponent<Canvas>().worldCamera = player.GetComponentInChildren<Camera>();
    }

    public void LoadGame()
    {
        print("Load");
    }

    public void Exit()
    {
        Application.Quit();
        print("Exit");
    }
}
