using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalLightController : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
