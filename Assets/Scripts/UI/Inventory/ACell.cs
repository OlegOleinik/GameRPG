using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ACell : MonoBehaviour
{
    public ItemScriptableObject item;
    public Image Image;
    public abstract void ClearCell();
    public abstract void OnMouseEnter();
    public abstract void OnMouseExit();
}
