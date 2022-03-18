using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseButton : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private float up;
    private string text;
    public void OnClick()
    {
        GetComponentInParent<SpecsPanel>().IncreaseSpec(id, up);
    }

    private void Start()
    {
        text = gameObject.GetComponentInChildren<Text>().text;
    }
    public void SetText(string stat)
    {
        gameObject.GetComponentInChildren<Text>().text = text + stat;
    }
}
