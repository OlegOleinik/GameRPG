using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static bool isGamePaused;
    public static GameObject player = GameObject.FindGameObjectWithTag("Player");
    public static GameObject UI = GameObject.Find("UI");

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
        end();
        vary(zz);
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
        end();
        vary(zz);
    }
}
