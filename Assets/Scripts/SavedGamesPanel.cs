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
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
>>>>>>> Stashed changes
        gameObject.SetActive(false);
    }

    public void ShowResaveGames()
    {
        gameObject.SetActive(true);
<<<<<<< Updated upstream
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
>>>>>>> Stashed changes
        if (!Directory.Exists(Application.persistentDataPath + "/Saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Saves");
        }
<<<<<<< Updated upstream
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
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
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

=======
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
>>>>>>> Stashed changes
        if (!Directory.Exists(Application.persistentDataPath + "/Saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Saves");
        }
<<<<<<< Updated upstream
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
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
<<<<<<< HEAD
            Destroy(item.gameObject);
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            GameObject.Destroy(item.gameObject);
=======
            Destroy(item.gameObject);
>>>>>>> Stashed changes
=======
            Destroy(item.gameObject);
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
            Destroy(item.gameObject);
>>>>>>> Stashed changes
        }
    }
}
