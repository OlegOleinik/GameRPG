using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AButton : MonoBehaviour
{


    private void Update()
    {
        CheckKeyboardPress();
    }
    public abstract void CheckKeyboardPress();
    // Start is called before the first frame update
    public void PauseGame()
    {
        GameManager.isGamePaused = true;
        Time.timeScale = 0;
    }

    //Возобновить
    public void ResumeGame()
    {
        GameManager.isGamePaused = false;
        Time.timeScale = 1;
    }
}
