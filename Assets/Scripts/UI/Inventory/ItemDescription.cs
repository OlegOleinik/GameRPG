using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemDescription : MonoBehaviour
{
    public void SetDescription(string text)
    {
        gameObject.GetComponent<Text>().text = text;
    }

    public void ClearDescription()
    {
        gameObject.GetComponent<Text>().text = "";
    }
}
