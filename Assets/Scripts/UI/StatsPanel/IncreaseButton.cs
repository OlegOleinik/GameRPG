using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseButton : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private float up;
    public void OnClick()
    {
        GetComponentInParent<SpecsPanel>().IncreaseSpec(id, up);
        Debug.Log(1);
    }
}
