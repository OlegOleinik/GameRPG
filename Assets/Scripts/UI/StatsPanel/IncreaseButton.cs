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
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    private void Awake()
=======
    private void Start()
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
    private void Start()
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
    private void Start()
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
    private void Start()
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
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
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        gameObject.GetComponentInChildren<Text>().text = text + $": {stat}";
=======
        gameObject.GetComponentInChildren<Text>().text = text +$": {stat}";
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
        gameObject.GetComponentInChildren<Text>().text = text +$": {stat}";
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
        gameObject.GetComponentInChildren<Text>().text = text +$": {stat}";
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
=======
        gameObject.GetComponentInChildren<Text>().text = text +$": {stat}";
>>>>>>> 8ce4fe0d612e05eb15dae5fa935cfca087edf203
    }
}
