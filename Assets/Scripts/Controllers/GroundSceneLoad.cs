using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GroundSceneLoad : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            LoadAddictiveWorld();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DestroyFarWorld();
        }
    }


    private void DestroyFarWorld()
    {
        string[] sceneCoords = gameObject.scene.name.Split('.');
        int pX =  Mathf.RoundToInt(GameManager.player.transform.position.x / 24);
        int pY = Mathf.RoundToInt(GameManager.player.transform.position.y / 24);
        int x = System.Convert.ToInt32(sceneCoords[0]);
        int y = System.Convert.ToInt32(sceneCoords[1]);
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                if  (((Mathf.Abs(pX - (x + i))) > 1) || (((Mathf.Abs(pY - (y + j))) > 1)))
                {
                   
                    CheckAndUnloadScene($"{x + i}.{y + j}");

                }

            }
        }
    }


    //Загрузка области вокруг текущей сцены
    private void LoadAddictiveWorld()
    {
        string[] sceneCoords = gameObject.scene.name.Split('.');
        int x = System.Convert.ToInt32(sceneCoords[0]);
        int y = System.Convert.ToInt32(sceneCoords[1]);
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                CheckAndLoadScene($"{x + i}.{y + j}");
            }
        }

       
        
    }
    private void CheckAndUnloadScene(string name)
    {
        if ((SceneUtility.GetBuildIndexByScenePath(name) >= 0) && (SceneManager.GetSceneByName(name).isLoaded))
        {
            SceneManager.UnloadSceneAsync(name);
        }
    }
    private void CheckAndLoadScene(string name)
    {
        if ((SceneUtility.GetBuildIndexByScenePath(name)>=0) && (!SceneManager.GetSceneByName(name).isLoaded))
        {
            SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        }
    }
}
