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
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
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
=======
    //public bool isUpdate = true;
    private void Awake()
>>>>>>> Stashed changes
=======
    //public bool isUpdate = true;
    private void Awake()
>>>>>>> Stashed changes
    {
        text = gameObject.GetComponentInChildren<Text>().text;
        button = GetComponent<Button>();
    }
    public void SetMax(string stat)
    {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        isUpdate = false;
=======
       // isUpdate = false;
>>>>>>> Stashed changes
=======
       // isUpdate = false;
>>>>>>> Stashed changes
        button.interactable = false;
        gameObject.GetComponentInChildren<Text>().text = text + $": max({stat})";
=======
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76

    private void Awake()
    {
        text = gameObject.GetComponentInChildren<Text>().text;
        button = GetComponent<Button>();
<<<<<<< HEAD
    }

=======
>>>>>>> Stashed changes
    }
    public void OnClick()
=======

<<<<<<< Updated upstream
    private void Awake()
>>>>>>> Stashed changes
    {
        text = gameObject.GetComponentInChildren<Text>().text;
        button = GetComponent<Button>();
    }

<<<<<<< Updated upstream

    public void SetText(string stat)
    {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
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
=======
        button.interactable = true;
        gameObject.GetComponentInChildren<Text>().text = text + $": {stat}";
>>>>>>> Stashed changes
=======
        button.interactable = true;
        gameObject.GetComponentInChildren<Text>().text = text + $": {stat}";
>>>>>>> Stashed changes
=======
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    public void SetMax(string stat)
    {
        button.interactable = false;
        gameObject.GetComponentInChildren<Text>().text = text + $": max({stat})";
    }

<<<<<<< HEAD
=======
=======
    public void SetMax(string stat)
    {
        button.interactable = false;
        gameObject.GetComponentInChildren<Text>().text = text + $": max({stat})";
    }

>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    public void OnClick()
    {
        GetComponentInParent<SpecsPanel>().IncreaseSpec(id, up);
    }

    public void SetText(string stat)
    {
        button.interactable = true;
        gameObject.GetComponentInChildren<Text>().text = text + $": {stat}";
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    }
}