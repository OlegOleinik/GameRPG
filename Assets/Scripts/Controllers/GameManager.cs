using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static bool isGamePaused;
    public static GameObject player = GameObject.FindGameObjectWithTag("Player");
    public static GameObject UI = GameObject.FindGameObjectWithTag("UI");

    private static AudioSource clickSourse = GameObject.Find("ClickSound").GetComponent<AudioSource>();

    public static Color cellColorDefault = new Color(0.925f, 0.91f, 0.8f, 0.57f);
    public static Color cellColorOnMouse = new Color(0.59f, 0.29f, 0.29f, 0.57f);

    public delegate void EndCorutine();

    public delegate void GamePauseResume();
    public static event GamePauseResume OnGamePause;
    public static event GamePauseResume OnGameResume;

    public static void SetNewPlayerLink(GameObject newPlayer)
    {
        player = newPlayer;
    }

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
    }

    //�����������
    public static void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1;
        OnGameResume?.Invoke();
    }



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
}
