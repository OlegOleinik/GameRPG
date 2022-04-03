using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MagicUpCell : AMagicCell
{

    //public MagicScriptableObject spell;
    [SerializeField] private Text costText;
    [SerializeField] private Text lvlText;
    //[SerializeField] private Image Image;

    public void DrawCell(MagicScriptableObject spell, int lvl)
    {
        this.magic = spell;
        Image.sprite = spell.spellSprite;
        Image.color = new Color(1, 1, 1, 1);
        lvlText.text = System.Convert.ToString(lvl);
        if (lvl == 5)
        {
            costText.text = "Max";
        }
        else
        {
            costText.text = System.Convert.ToString(lvl * 70);
        }

    }
    public override void ClearCell()
    {
        magic = null;
        Image.sprite = null;
        Image.color = new Color(1, 1, 1, 0);
        lvlText.text = "";
        costText.text = "";
    }

    public override void OnMouseEnter()
    {
        SetEnterColor();
    }
    public override void OnMouseExit()
    {

        SetDefaultColor();
    }
    public void OnMouseClick()
    {

        gameObject.GetComponentInParent<MagicUpPanel>().UpSpellLvl(magic);

    }
    //public void DrawCell(MagicScriptableObject spell)
    //{
    //    this.spell = spell;
    //    Image.sprite = spell.spellSprite;
    //    Image.color = new Color(1, 1, 1, 1);
    //}
    //Очистка клетки, а также очистка сохранения предмета и id. СТОИТ РАЗБИТЬ НА 2 МЕТОДА
    //public void ClearCell()
    //{
    //    spell = null;
    //    Image.sprite = null;
    //    Image.color = new Color(1, 1, 1, 0);
    //}
    //public void OnMouseEnter()
    //{
    //    if (!selected)
    //    {
    //        gameObject.GetComponent<Image>().color = new Color(0.59f, 0.29f, 0.29f, 1);
    //    }

    //}
    //public void OnMouseExit()
    //{
    //    if (!selected)
    //    {
    //        gameObject.GetComponent<Image>().color = new Color(1f, 0.7f, 0.44f, 1);
    //    }
    //}
    //public void OnMouseClick()
    //{

    //    gameObject.GetComponentInParent<MagicCellsPanel>().ChangeSelected(this);

    //}
}
