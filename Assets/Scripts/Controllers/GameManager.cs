using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static bool isGamePaused;
    public static GameObject player = GameObject.FindGameObjectWithTag("Player");
    public static GameObject UI = GameObject.Find("UI");
    public static Color cellColorDefault = new Color(0.925f, 0.91f, 0.8f, 0.57f);
    public static Color cellColorOnMouse = new Color(0.59f, 0.29f, 0.29f, 0.57f);

    public delegate void EndCorutine();
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
}
