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
    //Загрузка области вокруг текущей сцены
    private void LoadAddictiveWorld()
    {
        //Player player = collision.GetComponent<Player>();
        //player.moveSpeed /= 2;
        //collision.GetComponent<Rigidbody2D>().mass *= 5;

        //this.gameObject.scene.name;
        string[] sceneCoords = gameObject.scene.name.Split('.');


        //double x = System.Math.Ceiling(player.transform.position.x / 24);
        //double y = System.Math.Ceiling(player.transform.position.y / 24);
        int x = System.Convert.ToInt32(sceneCoords[0]);
        int y = System.Convert.ToInt32(sceneCoords[1]);
        for (int i = -2; i < 3; i++)
        {
            for (int j = -2; j < 3; j++)
            {
                if (System.Math.Abs(i)==2 || System.Math.Abs(j) == 2)
                {
                    CheckAndUnloadScene($"{x + i}.{y + j}");
                }
                else
                {
                    CheckAndLoadScene($"{x + i}.{y + j}");
                }
                   
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

        
        //(SceneManager.GetSceneByName(name).IsValid())
        if ((SceneUtility.GetBuildIndexByScenePath(name)>=0) && (!SceneManager.GetSceneByName(name).isLoaded))
        {
            SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        }
    }
}
