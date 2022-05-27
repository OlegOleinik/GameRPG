using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTestLoc : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPrefs.SetInt("isTestFinished", 1);
    }
}
