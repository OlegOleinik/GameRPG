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
<<<<<<< Updated upstream:Assets/Scripts/Controllers/GroundSceneLoad.cs


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DestroyFarWorld();
        }

    }


    private void DestroyFarWorld()
    {
        //saved.DoSave($"{Mathf.Round(gameObject.transform.position.x / 24)}.{Mathf.Round(gameObject.transform.position.y / 24)}");
        string[] sceneCoords = gameObject.scene.name.Split('.');
        int pX =  (int)Mathf.Round(GameManager.player.transform.position.x / 24);
        int pY = (int)Mathf.Round(GameManager.player.transform.position.y / 24);

        Debug.Log(pX + " " + pY);
        Debug.Log(System.Math.Round(gameObject.transform.position.x / 24) + " " + Mathf.Round(gameObject.transform.position.y / 24));


        int x = System.Convert.ToInt32(sceneCoords[0]);
        int y = System.Convert.ToInt32(sceneCoords[1]);
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
               // Debug.Log((x + i) + " " + (y + j));
                if  /*((i != 0 && j != 0) && */(((Mathf.Abs(pX - (x + i))) > 1) || (((Mathf.Abs(pY - (y + j))) > 1)))
                {
                   
                    CheckAndUnloadScene($"{x + i}.{y + j}");

                }

            }
        }
    }


    //Загрузка области вокруг текущей сцены
    private void LoadAddictiveWorld()
    {
        //Player player = collision.GetComponent<Player>();
        //player.moveSpeed /= 2;
        //collision.GetComponent<Rigidbody2D>().mass *= 5;
=======
>>>>>>> Stashed changes:Assets/Scripts/GroundSceneLoad.cs


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
<<<<<<< Updated upstream:Assets/Scripts/Controllers/GroundSceneLoad.cs
                //if (System.Math.Abs(i)==2 || System.Math.Abs(j) == 2)
                //{
                //    CheckAndUnloadScene($"{x + i}.{y + j}");
                ////}
                //else
                //{
                    CheckAndLoadScene($"{x + i}.{y + j}");
                //}
                   
=======
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
>>>>>>> Stashed changes:Assets/Scripts/GroundSceneLoad.cs
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
