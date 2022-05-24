using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitGame : MonoBehaviour
{

    private void Start()
    {
        SceneManager.LoadScene("StartMenu");

        //При первом старте белый экран. Это должно исправить
        if (!Directory.Exists(Application.persistentDataPath + "/Saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Saves");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
