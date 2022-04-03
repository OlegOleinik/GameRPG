using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MagicCell : AMagicCell
{
    public bool selected = false;
    private int _id;
    //public MagicScriptableObject spell;
    //[SerializeField]private Image Image;

    public int id
    {
        get
        {
            return _id;
        }
        set
        {
            _id = value;
        }
    }
    public void DrawCell(MagicScriptableObject spell)
    {
        this.magic = spell;
        Image.sprite = spell.spellSprite;
        Image.color = new Color(1, 1, 1, 1);
    }
    //Очистка клетки, а также очистка сохранения предмета и id. СТОИТ РАЗБИТЬ НА 2 МЕТОДА
    public override void ClearCell()
    {
        magic = null;
        Image.sprite = null;
        Image.color = new Color(1, 1, 1, 0);
    }
    public override void OnMouseEnter()
    {
        if (!selected)
        {
            SetEnterColor();
        }

    }
    public override void OnMouseExit()
    {
        if (!selected)
        {
            SetDefaultColor();
        }
    }
    public override void SetEnterColor()
    {
        Color color = GameManager.cellColorOnMouse;
        gameObject.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 1f);
    }

    public override void SetDefaultColor()
    {
        Color color = GameManager.cellColorDefault;
        gameObject.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 1f);
    }
    public void OnMouseClick()
    {

        gameObject.GetComponentInParent<MagicCellsPanel>().ChangeSelected(this);

    }
}
