using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
public class MenuLoadPanel : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [SerializeField] GameObject loadGame;
    [SerializeField] MainMenu mainMenu;
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowLoadGames()
    {
        gameObject.SetActive(true);

        DirectoryInfo di = new DirectoryInfo(Application.persistentDataPath + "/Saves/");
        FileInfo[] files = di.GetFiles("*.json");
        ClearGames();
        foreach (var item in files)
        {
            Instantiate(loadGame, content.transform).GetComponent<LoadGameButton>().ShowGameForLoad(item.Name, this);
        }
    }

    public void LoadGame(string txt)
    {
        mainMenu.LoadGame(txt);
    }

    private void ClearGames()
    {
        foreach (var item in content.GetComponentsInChildren<LoadGameButton>())
        {
            Destroy(item.gameObject);
        }
    }
}

