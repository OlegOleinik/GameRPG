using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordCell : ACell
{
    private void Start()
    {
        Image.color = new Color(1, 1, 1, 0);
    }
    public void DrawCell(ItemScriptableObject item)
    {
        this.item = item;
        Image.sprite = item.itemSprite;
        Image.color = new Color(1, 1, 1, 1);
    }
    public override void ClearCell()
    {
        this.item = null;
        Image.sprite = null;
        Image.color = new Color(1, 1, 1, 0);
    }

    public override void OnMouseEnter()
    {
        gameObject.GetComponent<Image>().color = new Color(0.59f, 0.29f, 0.29f, 1);

    }
    public override void OnMouseExit()
    {
        gameObject.GetComponent<Image>().color = new Color(1f, 0.8f, 0.44f, 1);
    }

    //public void OnMouseClick()
    //{
    //    if (item != null)
    //    {
    //        gameObject.GetComponentInParent<InventoryPanel>().ChangeSelected(this);
    //    }

    //}
}
