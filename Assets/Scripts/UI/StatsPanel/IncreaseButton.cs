using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseButton : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private float up;
    private string text;
    private Button button;

    private void Awake()
    {
        text = gameObject.GetComponentInChildren<Text>().text;
        button = GetComponent<Button>();
    }

    public void SetMax(string stat)
    {
        button.interactable = false;
        gameObject.GetComponentInChildren<Text>().text = text + $": max({stat})";
    }

    public void OnClick()
    {
        GetComponentInParent<SpecsPanel>().IncreaseSpec(id, up);
    }

    public void SetText(string stat)
    {
        button.interactable = true;
        gameObject.GetComponentInChildren<Text>().text = text + $": {stat}";
    }
}
