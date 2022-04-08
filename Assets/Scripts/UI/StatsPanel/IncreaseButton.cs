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
    public bool isUpdate = true;
    private void Start()
    {
        text = gameObject.GetComponentInChildren<Text>().text;
        button = GetComponent<Button>();
    }
    public void SetMax(string stat)
    {
        isUpdate = false;
        button.interactable = false;
        gameObject.GetComponentInChildren<Text>().text = text + $": max({stat})";
    }
    public void OnClick()
    {
        GetComponentInParent<SpecsPanel>().IncreaseSpec(id, up);
    }


    public void SetText(string stat)
    {
        gameObject.GetComponentInChildren<Text>().text = text +$": {stat}";
    }
}
