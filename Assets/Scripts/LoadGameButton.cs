using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadGameButton : MonoBehaviour
{
    [SerializeField] private Text text;
    private MenuLoadPanel menuLoadPanel;
    public void ShowGameForLoad(string txt, MenuLoadPanel menuLoadPanel)
    {
        text.text = txt;
        this.menuLoadPanel = menuLoadPanel;
        //button.onClick.AddListener(LoadGame);
    }


    public void LoadGame()
    {
        menuLoadPanel.LoadGame(text.text);
    }
}
