using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ACell : MonoBehaviour
{

    public Image Image;
    public abstract void ClearCell();
    public abstract void OnMouseEnter();
    public abstract void OnMouseExit();

    public virtual void SetEnterColor()
    {
        gameObject.GetComponent<Image>().color = GameManager.cellColorOnMouse;
    }
   
    public virtual void SetDefaultColor()
    {
        gameObject.GetComponent<Image>().color = GameManager.cellColorDefault;
    }
}
