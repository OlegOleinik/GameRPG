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
<<<<<<< Updated upstream

        //{ System.DateTime.Now.ToString("yyyy/MM/dd_HH:mm:ss")}
=======
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
    }
}
