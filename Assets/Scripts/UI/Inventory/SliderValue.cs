using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderValue : MonoBehaviour
{
    public void SetValue(Slider slider)
    {
        GameManager.ClickPlay();
        gameObject.GetComponent<Text>().text = slider.value.ToString();
    }
}
