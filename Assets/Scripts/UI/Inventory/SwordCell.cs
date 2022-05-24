using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordCell : AItemCell
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
        SetEnterColor();

    }

    public override void OnMouseExit()
    {
        SetDefaultColor();
    }
}
