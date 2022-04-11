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
        ui.GetComponent<Canvas>().worldCamera = player.GetComponentInChildren<Camera>();
    }

    public void LoadGame()
    {
        Debug.Log("Load");
    }

    public void Exit()
    {
        GameManager.ExitGame();

    }
}
