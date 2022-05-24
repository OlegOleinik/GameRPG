using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
public class SavedGamesPanel : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [SerializeField] GameObject savedGame;
    private void Start()
    {
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
        gameObject.SetActive(false);
    }

    public void ShowResaveGames()
    {
        gameObject.SetActive(true);
<<<<<<< Updated upstream
=======
        if (!Directory.Exists(Application.persistentDataPath + "/Saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Saves");
        }
>>>>>>> Stashed changes
        DirectoryInfo di = new DirectoryInfo(Application.persistentDataPath + "/Saves/");
        FileInfo[] files = di.GetFiles("*.json");
        ClearGames();
        Instantiate(savedGame, content.transform).GetComponent<SavedGameButton>().ShowGameForResave(this);
        foreach (var item in files)
        {
            Instantiate(savedGame, content.transform).GetComponent<SavedGameButton>().ShowGameForResave(item.Name, this);
        }
    }

    public void ShowLoadGames()
    {
        gameObject.SetActive(true);
<<<<<<< Updated upstream

=======
        if (!Directory.Exists(Application.persistentDataPath + "/Saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Saves");
        }
>>>>>>> Stashed changes
        DirectoryInfo di = new DirectoryInfo(Application.persistentDataPath + "/Saves/");
        FileInfo[] files = di.GetFiles("*.json");
        ClearGames();
        foreach (var item in files)
        {
            Instantiate(savedGame, content.transform).GetComponent<SavedGameButton>().ShowGameForLoad(item.Name);
        }
    }

    private void ClearGames()
    {
        foreach (var item in content.GetComponentsInChildren<SavedGameButton>())
        {
<<<<<<< Updated upstream
            GameObject.Destroy(item.gameObject);
=======
            Destroy(item.gameObject);
>>>>>>> Stashed changes
        }
    }
}
