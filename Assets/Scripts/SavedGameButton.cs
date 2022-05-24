using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavedGameButton : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] Button button;
    public SavedGamesPanel savedGamesPanel;


    public void ResaveGame()
    {
        GameManager.player.GetComponent<SaveLoadController>().Save(text.text);
        savedGamesPanel.ShowResaveGames();
    }

    public void NewSaveGame()
    {
        GameManager.player.GetComponent<SaveLoadController>().Save("Save1_" + System.DateTime.Now.ToString("yyyy/MM/dd_HH-mm-ss") + ".json");
        savedGamesPanel.ShowResaveGames();
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

        //{ System.DateTime.Now.ToString("yyyy/MM/dd_HH:mm:ss")}
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    }
    public void LoadGame()
    {
        GameManager.player.GetComponent<SaveLoadController>().Load(text.text);
    }


    public void ShowGameForLoad(string txt)
    {
        text.text = txt;
        button.onClick.AddListener(LoadGame);
    }
    public void ShowGameForResave(SavedGamesPanel savedGamesPanel)
    {
        this.savedGamesPanel = savedGamesPanel;
        text.text = "New save";
        button.onClick.AddListener(NewSaveGame);
    }

    public void ShowGameForResave(string txt, SavedGamesPanel savedGamesPanel)
    {
        this.savedGamesPanel = savedGamesPanel;
        text.text = txt;
        button.onClick.AddListener(ResaveGame);
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    }
}
