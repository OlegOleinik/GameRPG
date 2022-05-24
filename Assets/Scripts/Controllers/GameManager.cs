using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static bool isGamePaused;
    public static GameObject player = GameObject.FindGameObjectWithTag("Player");
    public static GameObject UI = GameObject.FindGameObjectWithTag("UI");
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======

    private static AudioSource clickSourse = GameObject.Find("ClickSound").GetComponent<AudioSource>();

>>>>>>> Stashed changes
=======

    private static AudioSource clickSourse = GameObject.Find("ClickSound").GetComponent<AudioSource>();

>>>>>>> Stashed changes
    public static Color cellColorDefault = new Color(0.925f, 0.91f, 0.8f, 0.57f);
    public static Color cellColorOnMouse = new Color(0.59f, 0.29f, 0.29f, 0.57f);

    public delegate void EndCorutine();

<<<<<<< Updated upstream
<<<<<<< Updated upstream

<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes
    public static void SetNewPlayer(GameObject newPlayer)
=======
=======
>>>>>>> Stashed changes
    public delegate void GamePauseResume();
    public static event GamePauseResume OnGamePause;
    public static event GamePauseResume OnGameResume;

    //public static void FindNewRefs()
    //{
    //    player = GameObject.FindGameObjectWithTag("Player");
    //    UI = GameObject.FindGameObjectWithTag("UI");
    //}

    public static void SetNewPlayerLink(GameObject newPlayer)
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    {
        player = newPlayer;
    }

<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    public static void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes

    public static void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0;
=======
=======
>>>>>>> Stashed changes
    public static void SetNewUILink(GameObject newUI)
    {
        UI = newUI;
    }

    public static void ClickPlay()
    {
        clickSourse.Play();
    }


    public static void ExitGame()
    {
        Application.Quit();
    }


    public static void PauseGame()
    {
        
        isGamePaused = true;
        Time.timeScale = 0;
        OnGamePause?.Invoke();
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }

    //Возобновить
    public static void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
        OnGameResume?.Invoke();
>>>>>>> Stashed changes
=======
        OnGameResume?.Invoke();
>>>>>>> Stashed changes
    }



<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    public static IEnumerator Tweeng(this float duration,
    System.Action<float> vary, float aa, float zz, EndCorutine end)
    {
        float sT = Time.time;
        float eT = sT + duration;

        while (Time.time < eT)
        {
            float t = (Time.time - sT) / duration;
            vary(Mathf.SmoothStep(aa, zz, t));
            yield return null;
        }
        
        vary(zz);
        end();
    }

    public static IEnumerator Tweeng(this float duration,
    System.Action<float> vary, float aa, float zz)
    {
        float sT = Time.time;
        float eT = sT + duration;

        while (Time.time < eT)
        {
            float t = (Time.time - sT) / duration;
            vary(Mathf.SmoothStep(aa, zz, t));
            yield return null;
        }
        vary(zz);
    }
    public static IEnumerator Tweeng(this float duration,
          System.Action<Vector3> vary, Vector3 aa, Vector3 zz, EndCorutine end)
    {
        float sT = Time.time;
        float eT = sT + duration;

        while (Time.time < eT)
        {
            float t = (Time.time - sT) / duration;
            vary(Vector3.Lerp(aa, zz, t));
            yield return null;
        }
        
        vary(zz);
        end();
    }



    public static IEnumerator Tweeng(this float duration,
      System.Action<Vector3> vary, Vector3 aa, Vector3 zz)
    {
        float sT = Time.unscaledTime;
        float eT = sT + duration;

        while (Time.unscaledTime < eT)
        {
            float t = (Time.unscaledTime - sT) / duration;
            vary(Vector3.Lerp(aa, zz, t));
            yield return null;
        }
        vary(zz);
    }
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes



    public static IEnumerator Tweeng(this float duration,
  System.Action<Color> vary, Color aa, Color zz)
    {
        float sT = Time.time;
        float eT = sT + duration;

        while (Time.time < eT)
        {
            float t = (Time.time - sT) / duration;
            vary(Color.Lerp(aa, zz, t));
            yield return null;
        }
        vary(zz);
    }
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
=======
>>>>>>> Stashed changes


    public static IEnumerator Tweeng(this float duration,
 System.Action<Color> vary, Color aa, Color zz, EndCorutine end)
    {
        float sT = Time.time;
        float eT = sT + duration;

        while (Time.time < eT)
        {
            float t = (Time.time - sT) / duration;
            vary(Color.Lerp(aa, zz, t));
            yield return null;
        }
        vary(zz);
        end();
    }
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
}
